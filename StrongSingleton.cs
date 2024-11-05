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