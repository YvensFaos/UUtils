using UnityEngine;

namespace UUtils
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Box2DGizmoViewer : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider2D selfCollider;
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
            var selfColliderOffset = selfCollider.offset;
            var position = new Vector3(selfColliderOffset.x, selfColliderOffset.y, 0) + transform.position;
            var selfColliderSize = selfCollider.size;
            var size = new Vector3(selfColliderSize.x / 2.0f, selfColliderSize.y / 2.0f, 1.0f);
            Gizmos.DrawWireCube(position, size);
        }
    }
}
