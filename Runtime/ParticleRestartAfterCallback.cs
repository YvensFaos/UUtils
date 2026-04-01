/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UUtils
{
    public class ParticleRestartAfterCallback : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particles;
        [SerializeField, Range(1, 10)] private float randomizerTimer;

        private void Awake()
        {
            AssessUtils.CheckRequirement(ref particles, this);
        }

        public void OnParticleSystemStopped()
        {
            StartCoroutine(RestartAfterCoroutine());
        }

        private IEnumerator RestartAfterCoroutine()
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            yield return new WaitUntil(() => particles.isStopped && particles.particleCount == 0);
            yield return new WaitForSeconds(Random.Range(0, randomizerTimer));
            particles.Play();
        }
    }
}