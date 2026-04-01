/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Linq;
using TMPro;
using UnityEngine;

namespace UUtils
{
    /**
    This script changes a UI Text to display the current and average FPS.
    */
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;
    
        [SerializeField]
        private int averageSample;
    
        private float[] _averageValues;
        private int _averageIndex;
    
        public void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            _averageValues = new float[averageSample];
            _averageIndex = 0;
            _averageValues[_averageIndex] = 0;
        }

        public void Update()
        {
            _averageValues[_averageIndex] = Time.deltaTime;
            _averageIndex = (++_averageIndex) % averageSample;
            var fps = 1.0f / Time.deltaTime;
            var averageFps = 1.0f / (_averageValues.Sum(value => value) / averageSample);
            text.text = "FPS: " + fps.ToString("0.0") + " AVG: " + averageFps.ToString("0.0");
        }
    }
}
