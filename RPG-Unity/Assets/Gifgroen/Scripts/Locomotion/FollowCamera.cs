using UnityEngine;

namespace Gifgroen.Locomotion
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Transform followTarget;

        private void Update()
        {
            transform.position = followTarget.position;
        }
    }
}
