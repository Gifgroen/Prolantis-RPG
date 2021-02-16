using UnityEngine;
using UnityEngine.AI;

namespace Gifgroen.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        private void OnValidate()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveToDestination(Vector3 destination)
        {
            navMeshAgent.destination = destination;
        }
    }
}