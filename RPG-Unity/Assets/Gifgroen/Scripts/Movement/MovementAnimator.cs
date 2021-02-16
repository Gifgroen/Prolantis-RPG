using UnityEngine;
using UnityEngine.AI;

namespace Gifgroen.Movement
{
    public class MovementAnimator : MonoBehaviour
    {
        private static readonly int ForwardSpeedId = Animator.StringToHash("forwardSpeed");

        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private Animator animator;

        private void Update()
        {
            Vector3 forwardSpeed = transform.InverseTransformDirection(navMeshAgent.velocity);
            animator.SetFloat(ForwardSpeedId, forwardSpeed.z);
        }
    }
}