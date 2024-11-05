using UnityEngine;

namespace UUtils
{
    [RequireComponent(typeof(Collider))]
    public abstract class AgnosticCollisionSolver : MonoBehaviour
    {
        [SerializeField]
        private bool allowRegularCollisions = true;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!allowRegularCollisions) return;
            Solve(other.gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!allowRegularCollisions) return;
            Solve(other.gameObject);
        }

        public abstract void Solve(GameObject collidedWith);

        private void OnTriggerExit(Collider other)
        {
            if (!allowRegularCollisions) return;
            SolveExit(other.gameObject);
        }

        private void OnCollisionExit(Collision other)
        {
            if (!allowRegularCollisions) return;
            SolveExit(other.gameObject);
        }

        public virtual void SolveExit(GameObject exitWith) { }
    }
}
