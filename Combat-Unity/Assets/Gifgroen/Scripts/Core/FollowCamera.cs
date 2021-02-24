using UnityEngine;

namespace Gifgroen.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform followTarget;

        private void LateUpdate()
        {
            transform.position = followTarget.position;
        }
    }
}
