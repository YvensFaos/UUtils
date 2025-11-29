/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UUtils.Editor
{
    public static class GetAllScriptableObjectsOfType
    {
        public static List<T> Get<T>()
        {
            var results = new List<T>();
            var assetPaths = Directory.GetFiles(Application.dataPath, "*.asset", SearchOption.AllDirectories)
                .Where(path => !path.Contains("/Editor/"))
                .Select(path => path[(Application.dataPath.Length - "Assets".Length)..])
                .ToArray();

            foreach (var assetPath in assetPaths)
            {
                var obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
                if (obj != null && obj is T objT)
                {
                    results.Add(objT);
                }
            }
            return results;
        }
    }
}