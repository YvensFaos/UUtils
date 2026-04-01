/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Collections.Generic;
using UnityEngine;

namespace UUtils
{
    public class PlayRandomAudio : MonoBehaviour
    {
        [SerializeField]
        private List<AudioClip> audios;
        [SerializeField]
        private AudioSource audioSource;

        public void PlayRandomClip()
        {
            var randomAudio = RandomHelper<AudioClip>.GetRandomFromList(audios);
            audioSource.PlayOneShot(randomAudio);
        }
    }
}