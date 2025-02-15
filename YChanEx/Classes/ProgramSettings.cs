﻿namespace YChanEx;

using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Contains usability methods governing the application events.
/// </summary>
internal static class ProgramSettings {

    public static bool SaveThreads(this List<ThreadInfo> Data){
        try {
            List<string> Files = new();
            if (Directory.Exists($"{Config.Settings.SavedThreadsPath}")) {
                DirectoryInfo ExistingFiles = new(Config.Settings.SavedThreadsPath);
                Files = ExistingFiles.GetFiles("*.thread.json", SearchOption.TopDirectoryOnly)
                    .Select(x => x.FullName)
                    .ToList();
            }

            if (Data.Count > 0) {
                if (!Directory.Exists(Config.Settings.SavedThreadsPath)) {
                    Directory.CreateDirectory(Config.Settings.SavedThreadsPath);
                }
                for (int i = 0; i < Data.Count; i++) {
                    if (Files.Contains(Data[i].SavedThreadJson, out int Index))
                        Files.RemoveAt(Index);
                    if (Data[i].ThreadModified)
                        File.WriteAllText($"{Data[i].SavedThreadJson}", Data[i].Data.JsonSerialize());
                }

                if (Files.Count > 0) {
                    for (int i = 0; i < Files.Count; i++) {
                        if (File.Exists(Files[i]))
                            File.Delete(Files[i]);
                    }
                }
            }
            return true;
        }
        catch { throw; }
    }

    public static bool SaveThread(this ThreadInfo Thread) {
        try {
            if (!Directory.Exists(Config.Settings.SavedThreadsPath)) {
                Directory.CreateDirectory(Config.Settings.SavedThreadsPath);
            }
            if (Thread.ThreadModified) {
                File.WriteAllText($"{Thread.SavedThreadJson}", Thread.Data.JsonSerialize());
                Thread.ThreadModified = false;
            }
            return true;
        }
        catch { throw; }
    }

    public static List<ThreadData> LoadThreads(this List<ThreadData> list, out List<string> FilePaths) {
        list = new();
        FilePaths = new();

        List<FileInfo> SavedFiles = new();
        DirectoryInfo ScanningDirectory;
        if (Directory.Exists($"{Config.Settings.SavedThreadsPath}")) {
            ScanningDirectory = new($"{Config.Settings.SavedThreadsPath}");
            SavedFiles = SavedFiles
                .Concat(ScanningDirectory
                    .GetFiles("*.thread.json", SearchOption.TopDirectoryOnly))
                .ToList();
        }

        if (SavedFiles.Count > 0) {
            for (int i = 0; i < SavedFiles.Count; i++) {
                list.Add(File.ReadAllText(SavedFiles[i].FullName).JsonDeserialize<ThreadData>());
                FilePaths.Add(SavedFiles[i].FullName);
            }
        }

        return list;
    }

}