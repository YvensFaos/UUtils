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
