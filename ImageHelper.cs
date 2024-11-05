using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UUtils
{
    public class ImageHelper : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        private Tweener _internalTween;
        
        private void Awake()
        {
            AssessUtils.CheckRequirement(ref image, this);
        }
        
        public void AnimateColorTo(string color)
        {
            //Force adding the # at the start of the hex color string
            if (color[0] != '#')
            {
                color = $"#{color}";
            }
            
            if (!ColorUtility.TryParseHtmlString(color, out var hexColor))
            {
                DebugUtils.DebugLogErrorMsg($"Error while parsing color {color}.");
                return;
            }

            _internalTween?.Kill();
            _internalTween = image.DOColor(hexColor, 0.2f);
        }

        public void AnimateToB3()
        {
            AnimateColorTo("#B3B3B3");
        }
        
        public void AnimateToD4()
        {
            AnimateColorTo("#D4D4D4");
        }

        public void AnimateToWhite()
        {
            AnimateColorTo("#FFFFFF");
        }

        public void AnimateToBlack()
        {
            AnimateColorTo("#000000");
        }

        public void AnimateColorTo(Vector3 color)
        {
            _internalTween?.Kill();
            _internalTween = image.DOColor(new Color(color.x, color.y, color.z, 1.0f), 0.2f);
        }
        
        public void AnimateColorTo(Color color)
        {
            _internalTween?.Kill();
            _internalTween = image.DOColor(color, 0.2f);
        }

        public void ChangeSpriteTo(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}