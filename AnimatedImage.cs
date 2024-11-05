using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class AnimatedImage : MonoBehaviour
    {
        [SerializeField] 
        private Image image;
        [SerializeField] 
        private RectTransform rect;

        [Header("Animation Properties")] 
        [SerializeField]
        private float scale = 1.05f;
        [SerializeField]
        private float duration = 0.75f;

        private Vector3 _originalScale;
        private Tweener _introTween;
        private Tweener _bounceTween;
        
        private void Awake()
        {
            AssessUtils.CheckRequirement(ref rect, this);
            _originalScale = rect.localScale;
        }

        private void OnEnable()
        {
            _introTween?.Kill();
            var currentColor = image.color;
            currentColor.a = 1.0f;    
            
            var noAlpha = currentColor;
            noAlpha.a = 0.0f;
            image.color = noAlpha;
            _introTween = image.DOColor(currentColor, 0.2f).OnComplete(() =>
            {
                image.color = currentColor;
            });
            
            _bounceTween?.Kill();
            rect.localScale = _originalScale;
            _bounceTween = rect.DOScale(new Vector3(scale,scale,scale), duration).SetLoops(-1, LoopType.Yoyo).OnComplete(() =>
            {
                rect.localScale = _originalScale;
            });
        }

        private void OnDisable()
        {
            _introTween?.Kill();
            _bounceTween?.Kill();
        }
    }
}