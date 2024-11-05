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

        private void Awake()
        {
            ControlSingleton();
        }
    }
}