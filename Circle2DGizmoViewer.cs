using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Circle2DGizmoViewer : MonoBehaviour
    {
        [SerializeField]
        private CircleCollider2D selfCollider;
        [SerializeField]
        private Color colliderColor = Color.white;
        
        private void Awake()
        {
            AssessUtils.CheckRequirement(ref selfCollider, this);
        }

        private void OnDrawGizmos()
        {
            if (selfCollider == null) return;
    
            Gizmos.color = colliderColor;
            var offset = selfCollider.offset;
            var position = new Vector3(offset.x, offset.y, 0) + transform.position;
            Gizmos.DrawWireSphere(position, selfCollider.radius);
        }
    }
}