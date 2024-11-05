using UnityEngine;

namespace UUtils
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererController : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer line;

        private void Awake()
        {
            AssessUtils.CheckRequirement(ref line, this);
        }

        public void SetPointAtIndex(int index, Vector3 position)
        {
            if (index < 0 || index >= line.positionCount) return;
            line.SetPosition(index, position);
        }
    }
}
