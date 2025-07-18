using UnityEngine;

namespace UUtils
{
    public class ParticleStopper : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particles;
        
        private void Awake()
        {
            AssessUtils.CheckRequirement(ref particles, this);
        }

        public void ParticleFullStop()
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}