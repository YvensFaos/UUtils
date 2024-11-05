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