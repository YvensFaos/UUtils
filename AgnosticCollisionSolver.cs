using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AgnosticCollisionSolver : MonoBehaviour
{
    [SerializeField]
    private bool AllowRegularCollisions = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!AllowRegularCollisions) return;
        Solve(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!AllowRegularCollisions) return;
        Solve(other.gameObject);
    }

    public abstract void Solve(GameObject collidedWith);

    private void OnTriggerExit(Collider other)
    {
        if (!AllowRegularCollisions) return;
        SolveExit(other.gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        if (!AllowRegularCollisions) return;
        SolveExit(other.gameObject);
    }

    public virtual void SolveExit(GameObject exitWith) { }
}
