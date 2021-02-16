using UnityEngine;

namespace Gifgroen.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        
        [SerializeField] private Movement.Movement movement;

        private void Update()
        {
            if (!Input.GetMouseButton(0)) return;

            Ray r = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out RaycastHit hit))
            {
                movement.MoveToDestination(hit.point);
            }
        }
    }
}
