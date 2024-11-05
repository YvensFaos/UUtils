using UnityEngine;

namespace Utils
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