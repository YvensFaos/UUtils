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