using Gifgroen.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Gifgroen.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour, IAction
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private ActionScheduler actionScheduler;

        private void OnValidate()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
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