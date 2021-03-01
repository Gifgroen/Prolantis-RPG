using Gifgroen.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Gifgroen.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour, IAction
    {
        private static readonly int ForwardSpeedId = Animator.StringToHash("forwardSpeed");

        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private ActionScheduler actionScheduler;

        [SerializeField] private Animator animator;

        [SerializeField] private Health health;

        private void OnValidate()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            navMeshAgent.enabled = !health.IsDead;
            Vector3 forwardSpeed = transform.InverseTransformDirection(navMeshAgent.velocity);
            animator.SetFloat(ForwardSpeedId, forwardSpeed.z);
        }
        
        public void StartMoveToDestination(Vector3 destination)
        {
            actionScheduler.StartAction(this);
            MoveToDestination(destination);
        }

        public void MoveToDestination(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }
    }
}