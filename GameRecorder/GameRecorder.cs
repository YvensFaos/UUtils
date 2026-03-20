/*
 * Copyright (c) 2026 Yvens R Serpa [https://github.com/YvensFaos/]
 *
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using NaughtyAttributes;
using UnityEngine;

namespace UUtils.GameRecorder
{
    public class GameRecorder : MonoBehaviour
    {
        [SerializeField]
        private bool recordOnStart;
        [SerializeField, ShowIf("recordOnStart")]
        private string recordedIdentifier;
        
        private Recorder _recorder;

        private void Start()
        {
            if (recordOnStart)
            {
                StartRecording(recordedIdentifier);
            }
        }

        public void StartRecording(string recordingIdentifier)
        {
            _recorder = new Recorder(recordingIdentifier);
        }

        public void RecordNewEntry(RecordEntry entry)
        {
            _recorder?.RecordNewEntry(entry);
        }

        public void StopRecording()
        {
            _recorder?.Stop();
        }
    }
}