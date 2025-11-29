/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using UnityEngine;

namespace UUtils
{
    public static class LayerHelper
    {
        public static bool CheckLayer(LayerMask mask, int layer) => (mask.value & (1 << layer)) > 0;
    }
}
