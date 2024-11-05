using System;
using System.Collections.Generic;

namespace UUtils
{
    [Serializable]
    public class CacheHelper<T> : UnityEngine.Object where T : UnityEngine.Object
    {
        private Dictionary<string, T> _cacheDictionary = new();

        public bool CheckCache(string cachedObjectKey, out T found, List<T> cachedList = null)
        {
            found = null;
            _cacheDictionary ??= new Dictionary<string, T>();
            if (_cacheDictionary.TryGetValue(cachedObjectKey, out var value))
            {
                found = value;
                return true;
            }
            if (cachedList == null) return found != null;
            found = cachedList.Find(o => o.name.Equals(cachedObjectKey));
            if (found == null) return found != null;
            _cacheDictionary.Add(cachedObjectKey, found);
            Count++;
            return found != null;
        }
        
        public int Count { get; private set; }
    }
}