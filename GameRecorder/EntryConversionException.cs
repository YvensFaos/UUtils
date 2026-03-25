/*
 * Copyright (c) 2026 Yvens R Serpa [https://github.com/YvensFaos/]
 *
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using System;

namespace UUtils.GameRecorder
{
    public class EntryConversionException : Exception
    {
        private readonly string _entry;
        private readonly Type _conversionType;

        public EntryConversionException(string entry, Type conversionType)
        {
            _entry = entry;
            _conversionType = conversionType;
        }
        
        public override string Message => $"Error: Entry conversion with entry [{_entry}]. " +
                                          $"Trying to convert to {_conversionType}.";
    }
}