/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Collections.Generic;
using UnityEngine;

namespace UUtils
{
    [CreateAssetMenu(fileName = "New Scene Builder", menuName = "Utils/Scene Builder", order = 0)]
    public class SceneBuilderScriptableObject : ScriptableObject
    {
        public List<GameObject> prefabList;
    }
}