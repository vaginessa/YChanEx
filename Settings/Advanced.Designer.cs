﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YChanEx {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Advanced : global::System.Configuration.ApplicationSettingsBase {
        
        private static Advanced defaultInstance = ((Advanced)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Advanced())));
        
        public static Advanced Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Mozilla/5.0 (X11; Linux i686; rv:64.0) Gecko/20100101 Firefox/84.0")]
        public string UserAgent {
            get {
                return ((string)(this["UserAgent"]));
            }
            set {
                this["UserAgent"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DisableScanWhenOpeningSettings {
            get {
                return ((bool)(this["DisableScanWhenOpeningSettings"]));
            }
            set {
                this["DisableScanWhenOpeningSettings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SilenceErrors {
            get {
                return ((bool)(this["SilenceErrors"]));
            }
            set {
                this["SilenceErrors"] = value;
            }
        }
    }
}
