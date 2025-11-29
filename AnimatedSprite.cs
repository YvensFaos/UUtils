/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using DG.Tweening;
using UnityEngine;

namespace UUtils
{
    public class AnimatedSprite : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer sprite;
        [SerializeField] 
        private Transform rect;
        [SerializeField]
        private bool forceAlpha = true;

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
            AssessUtils.CheckRequirement(ref sprite, this);
            AssessUtils.CheckRequirement(ref rect, this);

            _originalScale = rect.localScale;
        }

        private void OnEnable()
        {
            _introTween?.Kill();
            var currentColor = sprite.color;
            if (forceAlpha)
            {
                currentColor.a = 1.0f;    
            }
            
            var noAlpha = currentColor;
            noAlpha.a = 0.0f;
            sprite.color = noAlpha;
            _introTween = sprite.DOColor(currentColor, 0.2f).OnComplete(() =>
            {
                sprite.color = currentColor;
            });
            
            _bounceTween?.Kill();
            rect.localScale = _originalScale;
            _bounceTween = rect.DOScale(new Vector3(scale,scale,scale), duration).SetLoops(-1).OnComplete(() =>
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