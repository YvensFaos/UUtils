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
    public class AnimationHelper : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string cachedProperty;

        public void SetCachedProperty(string property)
        {
            cachedProperty = property;
        }

        public void SetBoolean(bool boolean)
        {
            animator.SetBool(cachedProperty, boolean);
        }

        public void SetFloat(float value)
        {
            animator.SetFloat(cachedProperty, value);
        }

        public void SetInt(int value)
        {
            animator.SetInteger(cachedProperty, value);
        }
    }
}