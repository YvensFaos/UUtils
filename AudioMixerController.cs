/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using UnityEngine;
using UnityEngine.Audio;

namespace UUtils
{
    public class AudioMixerController : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer mixer;

        private float _currentMasterVolume;

        public void ToggleAllSound(bool toggle)
        {
            if (!toggle)
            {
                mixer.GetFloat("MasterVolume", out _currentMasterVolume);
            }
            mixer.SetFloat("MasterVolume", toggle ? _currentMasterVolume : -80.0f);
        }
    }
}
