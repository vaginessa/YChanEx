﻿// Copyright (c) 2019-2022 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
namespace SoftCircuits.HtmlMonkey;

using System.Text.RegularExpressions;

/// <summary>
/// Defines a selector that describes a node attribute.
/// </summary>
public class AttributeSelector {
    private readonly StringComparison StringComparison;
    private readonly RegexOptions RegexOptions;

    /// <summary>
    /// Gets or sets the name of the attribute to be compared.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the value the attribute should be compared to.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Gets or sets the type of comparison that should be performed
    /// on the attribute value.
    /// </summary>
    public AttributeSelectorMode Mode {
        get => _mode;
        set {
            _mode = value;
            IsMatch = _mode switch {
                AttributeSelectorMode.RegEx => RegExComparer,
                AttributeSelectorMode.Contains => ContainsComparer,
                AttributeSelectorMode.ExistsOnly => ExistsOnlyComparer,
                _ => MatchComparer,
            };
        }
    }
    private AttributeSelectorMode _mode;

    /// <summary>
    /// Compares the given node against this selector attribute.
    /// </summary>
    /// <param name="node">Node to be compared.</param>
    /// <returns>True if the node matches, false otherwise.</returns>
    public Func<HtmlElementNode, bool> IsMatch { get; private set; }

    /// <summary>
    /// Constructs a <see cref="AttributeSelector"></see> instance.
    /// </summary>
    /// <param name="ignoreCase">If <c>true</c>, node comparisons are not case-sensitive. If <c>false</c>,
    /// node comparisons are case-sensitive.</param>
    public AttributeSelector(string name, string? value = null, bool ignoreCase = true) {
        Name = name;
        Value = value;
        Mode = AttributeSelectorMode.Match;
        IsMatch = MatchComparer;
        StringComparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        RegexOptions = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
    }

    #region Matching routines

    /// <summary>
    /// Implements <see cref="SelectorAttributeMode.Match"></see> comparer.
    /// </summary>
    private bool MatchComparer(HtmlElementNode node) {
        if (Value != null) {
            if (node.Attributes.TryGetValue(Name, out HtmlAttribute? attribute) && attribute.Value != null)
                return string.Equals(attribute.Value, Value, StringComparison);
        }
        return false;
    }

    /// <summary>
    /// Implements <see cref="SelectorAttributeMode.RegEx"></see> comparer.
    /// </summary>
    private bool RegExComparer(HtmlElementNode node) {
        if (Value != null) {
            if (node.Attributes.TryGetValue(Name, out HtmlAttribute? attribute) && attribute.Value != null)
                return Regex.IsMatch(attribute.Value, Value, RegexOptions);
        }
        return false;
    }

    /// <summary>
    /// Implements <see cref="SelectorAttributeMode.Contains"></see> comparer.
    /// </summary>
    private bool ContainsComparer(HtmlElementNode node) {
        if (Value != null) {
            if (node.Attributes.TryGetValue(Name, out HtmlAttribute? attribute) && attribute.Value != null)
                return ParseWords(attribute.Value).Any(a => string.Equals(Value, a, StringComparison));
        }
        return false;
    }

    /// <summary>
    /// Implements <see cref="SelectorAttributeMode.ExistsOnly"></see> comparer.
    /// </summary>
    private bool ExistsOnlyComparer(HtmlElementNode node) => node.Attributes.Contains(Name);

    private static IEnumerable<string> ParseWords(string s) {
        bool inWord = false;
        int wordStart = 0;

        for (int i = 0; i < s.Length; i++) {
            if (char.IsWhiteSpace(s[i])) {
                if (inWord) {
                    inWord = false;
                    yield return s[wordStart..i];
                }
            }
            else if (!inWord) {
                inWord = true;
                wordStart = i;
            }
        }

        // Check for last word
        if (inWord)
            yield return s[wordStart..];
    }

    #endregion

    public override string ToString() => $"{Name ?? "(null)"}={Value ?? "(null)"}";
}
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.