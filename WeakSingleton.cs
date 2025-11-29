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
    public class WeakSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Singleton

        private static T _singleton;
        public static T GetSingleton() => _singleton;
        private static GameObject _singletonObject;

        private void ControlSingleton()
        {
            if (_singleton != null)
            {
                //Destroy the current singleton, so the new one takes its place
                Destroy(_singletonObject);
            }

            //Set the singleton to be this object
            _singleton = GetComponent<T>();
            _singletonObject = gameObject;
        }

        #endregion

        protected virtual void Awake()
        {
            ControlSingleton();
        }
    }
}