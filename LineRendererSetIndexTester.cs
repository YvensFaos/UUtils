/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using NaughtyAttributes;
using UnityEngine;

namespace UUtils
{
    public class LineRendererSetIndexTester : MonoBehaviour
    {
        [SerializeField]
        private LineRendererController lineController;
        [SerializeField]
        private int lineRendererIndex;

        private void Awake()
        {
            AssessUtils.CheckRequirement(ref lineController, this);
        }
        
        [Button("Set Index to Position")]
        public void ChangeIndexToPosition()
        {
            lineController.SetPointAtIndex(lineRendererIndex, transform.position);
        }

        [Button("Reset Position")]
        public void ResetPositions()
        {
            lineController.SetPointAtIndex(lineRendererIndex, lineController.transform.position);
        }
    }
}