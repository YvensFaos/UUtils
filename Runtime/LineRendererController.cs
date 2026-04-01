/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace UUtils
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererController : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer line;

        private Tween _internalTween;

        private void Awake()
        {
            AssessUtils.CheckRequirement(ref line, this);
        }

        public void SetPointAtIndex(int index, Vector3 position)
        {
            if (index < 0 || index >= line.positionCount) return;
            line.SetPosition(index, position);
        }

        public Tween AnimatePointAtIndexTo(int index, Vector3 position, float time, UnityAction callback = null)
        {
            if (index < 0 || index >= line.positionCount) return null;
            line.GetPosition(index);
            var tween = DOTween.To(() => line.GetPosition(index), value => line.SetPosition(index, value), position, time);
            tween.OnComplete(() =>
            {
                callback?.Invoke();
            });
            return tween;
        }

        public void SetColor(Color color)
        {
            line.startColor = color;
            line.endColor = color;
        }

        public void SetStartWidth(float width)
        {
            line.startWidth = width;
        }

        public void SetEndWidth(float width)
        {
            line.endWidth = width;
        }

        public void IncreaseWidth(float increment)
        {
            line.startWidth += increment;
            line.endWidth += increment;
        }

        public Tween IncreaseWidthBy(float increment, float time, UnityAction callback = null)
        {
            _internalTween?.Kill();
            var increaseBy = line.startWidth + increment;
            _internalTween = DOTween.To(() => line.startWidth, value => line.startWidth = value, increaseBy, time).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return _internalTween;
        }

        public void SetWidth(float width)
        {
            SetStartWidth(width);
            SetEndWidth(width);
        }

        public Material GetLineRendererMaterial()
        {
            return line.material;
        }

        public float GetWidth()
        {
            return line.startWidth;
        }

        [Button("Reset Positions")]
        public void ResetPositionsToWorldSpaceLocation()
        {
            for (var i = 0; i < line.positionCount; i++)
            {
                line.SetPosition(i, transform.position);
            }
        }
    }
}
