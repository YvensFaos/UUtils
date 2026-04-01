/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UUtils
{
    /**
    This script connects an exposed variable from an Audio Mixer to a UI slider.
    */
    public class MixerAudioSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private string exposedVariable;
        [SerializeField] private Slider slider;

        private void Start()
        {
            if (slider == null) return;
            if (mixer.GetFloat(exposedVariable, out var volume))
            {
                slider.value = volume;
            }
        }

        public void ChangeMixerVolume(Slider volume){
            mixer.SetFloat(exposedVariable, volume.value);
        }
    }
}