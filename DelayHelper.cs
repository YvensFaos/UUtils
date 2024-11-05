using System;
using System.Collections;
using UnityEngine;

namespace UUtils
{
    public static class DelayHelper
    {
        public static Coroutine DelayOneFrame(MonoBehaviour caller, Action delayAction)
        {
            return caller.StartCoroutine(DelayOneFrame(delayAction));
        }
        
        private static IEnumerator DelayOneFrame(Action delayAction)
        {
            yield return null;
            delayAction();
        }
    }
}