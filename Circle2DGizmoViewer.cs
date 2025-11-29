/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using UnityEngine;

namespace UUtils
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Circle2DGizmoViewer : MonoBehaviour
    {
        [SerializeField]
        private CircleCollider2D selfCollider;
        [SerializeField]
        private Color colliderColor = Color.white;
        
        private void Awake()
        {
            AssessUtils.CheckRequirement(ref selfCollider, this);
        }

        private void OnDrawGizmos()
        {
            if (selfCollider == null) return;
    
            Gizmos.color = colliderColor;
            var offset = selfCollider.offset;
            var position = new Vector3(offset.x, offset.y, 0) + transform.position;
            Gizmos.DrawWireSphere(position, selfCollider.radius);
        }
    }
}