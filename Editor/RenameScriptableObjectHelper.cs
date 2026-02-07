/*
 * Copyright (c) 2026 Yvens R Serpa [https://github.com/YvensFaos/]
 *
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using System.IO;
using UnityEditor;
using UnityEngine;

namespace UUtils.Editor
{
    public static class RenameScriptableObjectHelper
    {
        public static void RenameAssetFile(ScriptableObject data, string newFileName)
        {
            var path = AssetDatabase.GetAssetPath(data);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("Asset path is invalid!");
                return;
            }

            newFileName = RemoveInvalidFileNameChars(newFileName);

            var directory = Path.GetDirectoryName(path);
            var extension = Path.GetExtension(path);
            if (directory != null)
            {
                var newPath = Path.Combine(directory, newFileName + extension);
                if (path == newPath)
                {
                    Debug.LogWarning("Asset already has this name.");
                    return;
                }

                if (File.Exists(newPath))
                {
                    Debug.LogError($"A file named '{newFileName}' already exists in this folder!");
                    return;
                }
            }

            var result = AssetDatabase.RenameAsset(path, newFileName);
            if (string.IsNullOrEmpty(result))
            {
                Debug.Log($"Asset renamed to: {newFileName}");
                data.name = newFileName;
                EditorUtility.SetDirty(data);
                AssetDatabase.SaveAssets();
            }
            else
            {
                Debug.LogError($"Failed to rename asset: {result}");
            }
        }

        private static string RemoveInvalidFileNameChars(string filename)
        {
            // Remove invalid characters for filenames
            var invalidChars = new string(Path.GetInvalidFileNameChars());
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var c in invalidChars)
            {
                filename = filename.Replace(c.ToString(), "");
            }

            filename = filename.Replace(":", "");
            filename = filename.Replace("/", "");
            filename = filename.Replace("\\", "");
            filename = filename.Replace("?", "");
            filename = filename.Replace("*", "");
            filename = filename.Replace("<", "");
            filename = filename.Replace(">", "");
            filename = filename.Replace("|", "");
            filename = filename.Replace("\"", "");

            filename = filename.Trim();
            if (string.IsNullOrEmpty(filename))
            {
                filename = "Untitled";
            }

            return filename;
        }
    }
}