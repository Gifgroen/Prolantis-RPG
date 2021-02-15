using UnityEngine;
using UnityEngine.AI;

namespace Gifgroen.Locomotion
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private Camera mainCamera;

        private void OnValidate()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0)) return;
            
            Ray r = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out RaycastHit hit))
            {
                navMeshAgent.destination = hit.point;
            }
        }
    }
}