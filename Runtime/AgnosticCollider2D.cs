using UnityEngine;

namespace UUtils
{
    public abstract class AgnosticCollider2D : MonoBehaviour
    {
        [SerializeField]
        private bool allowRegularCollisions = true;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!allowRegularCollisions) return;
            Solve(other.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!allowRegularCollisions) return;
            Solve(other.gameObject);
        }

        protected abstract void Solve(GameObject collidedWith);

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!allowRegularCollisions) return;
            SolveExit(other.gameObject);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!allowRegularCollisions) return;
            SolveExit(other.gameObject);
        }

        protected virtual void SolveExit(GameObject exitWith) { }
    }
}