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
    public static class AnimateTweenHelper
    {
        public static void Animate(ref RectTransform rectTransform, ref Tweener originalTween,float time, float shakeScaleStrength)
        {
            var rectCopy = rectTransform;
            if (originalTween != null)
            {
                originalTween.Kill();
                rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            originalTween = rectTransform.DOShakeScale(time, shakeScaleStrength).OnComplete(() =>
            {
                rectCopy.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            });
        }
    }
}