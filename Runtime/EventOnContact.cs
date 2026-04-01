/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UUtils
{
    [RequireComponent(typeof(Collider2D))]
    public class EventOnContact : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent callEvent;
    
        [Header("Call On Contact with Objects with Tag")]
        [SerializeField]
        private bool callOnTag;
        [SerializeField]
        private List<string> tagsToCall;
    
        [Header("Call On Contact with Objects from Specific Layers")]
        [SerializeField]
        private bool callOnLayer;
        [SerializeField]
        private LayerMask layerToCall;

        private void OnTriggerEnter2D(Collider2D other)
        {
            SolveContact(other.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            SolveContact(other.gameObject);
        }

        private void SolveContact(GameObject other)
        {
            if (callOnTag)
            {
                var findIndex = tagsToCall.FindIndex(other.CompareTag);
                if (findIndex != -1)
                {
                    callEvent.Invoke();
                }
            }

            if (!callOnLayer) return;
            if (((1 << other.layer) & layerToCall) != 0)
            {
                callEvent.Invoke();
            }
        }
    }
}