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
    public abstract class StrongSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Singleton

        private static T _singleton;

        public static T GetSingleton()
        {
            return _singleton != null ? _singleton : null;
        }

        /// <summary>
        /// Sets the singleton usage and return whether the singleton was set or if one already exists.
        /// </summary>
        /// <returns>Returns false if a singleton already exists. Returns true if this object is the singleton.</returns>
        private void ControlSingleton()
        {
            if (_singleton != null)
            {
                //Destroy the new element and interrupt its initialization
                DestroyImmediate(gameObject);
                return;
            }

            //Set the singleton to be this object
            _singleton = GetComponent<T>();
        }

        #endregion

        protected virtual void Awake()
        {
            ControlSingleton();
        }
    }
}