/*
 * Copyright (c) 2026 Yvens R Serpa [https://github.com/YvensFaos/]
 *
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using System.IO;

namespace UUtils
{
    public static class FileHelper
    {
        public static string[] LoadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            if (!File.Exists(path)) return null;
            var lines = File.ReadAllLines(path);
            return lines;
        }
    }
}