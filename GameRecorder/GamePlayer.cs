/*
 * Copyright (c) 2026 Yvens R Serpa [https://github.com/YvensFaos/]
 *
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace UUtils.GameRecorder
{
    public abstract class GamePlayer : MonoBehaviour
    {
        [SerializeField]
        private bool playOnStart;
        [SerializeField, ShowIf("playOnStart")]
        private string recordFile;
        [SerializeField, ReadOnly]
        private bool playing;
        [SerializeField, ReadOnly]
        private string[] recordData;
        [SerializeField, ReadOnly]
        private bool pause;
        [SerializeField]
        private bool stepByStep;
        [SerializeField]
        private bool nextStep;

        private Coroutine _playCoroutine;
        
        private void Start()
        {
            if (playOnStart)
            {
                StartPlayingRecord(recordFile);
            }
        }

        public void StartPlayingRecord(string file)
        {
            if (playing) return;
            playing = true;
            _playCoroutine = StartCoroutine(PlayRecordCoroutine(file));
        }

        public void StopPlaying()
        {
            if (!playing) return;
            playing = false;
            StopCoroutine(_playCoroutine);
        }

        private IEnumerator PlayRecordCoroutine(string file)
        {
            recordData = FileHelper.LoadFile(file);
            if (recordData == null)
            {
                playing = false;
                DebugUtils.DebugLogErrorMsg($"Record file {file} is null or empty.");
                yield break;
            }
            
            //Start reading the record file's content
            foreach (var entryText in recordData)
            {
                if (pause) yield return new WaitUntil(() => !pause);
                ExecuteEntry(entryText);
                if (!stepByStep) continue;
                nextStep = false;
                yield return new WaitUntil(() => !nextStep);
            }
            yield return null;
        }

        protected abstract RecordEntry ExecuteEntry(string entryText);

        [Button("Step by Step")]
        private void StepByStepPlayer() => ToggleStepByStep(!stepByStep);
        [Button("Next Step")]
        private void NextStep() => nextStep = true;
        [Button("Pause")]
        private void PausePlaying() => TogglePause(!pause);
        
        private void TogglePause(bool toggle) => pause = toggle;
        private void ToggleStepByStep(bool toggle) => stepByStep = toggle;
    }
}