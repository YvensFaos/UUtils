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
