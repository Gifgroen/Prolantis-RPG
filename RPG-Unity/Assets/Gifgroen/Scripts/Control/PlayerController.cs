using Gifgroen.Combat;
using UnityEngine;

namespace Gifgroen.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Movement.Movement movement;

        [SerializeField] private Attacker attacker;

        private void Update()
        {
            if (InteractWithCombat())
            {
                return;
            }

            if (InteractWithMovement())
            {
                return;
            }

            print("Nothing to do");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] results = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in results)
            {
                Transform t = hit.transform;
                if (!t.TryGetComponent(out Attackable a))
                {
                    continue;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    attacker.Attack(a);
                }

                return true;
            }

            return false;
        }

        private bool InteractWithMovement()
        {
            if (Physics.Raycast(GetMouseRay(), out RaycastHit hit))
            {
                if (Input.GetMouseButton(0))
                {
                    movement.StartMoveToDestination(hit.point);
                }
                return true;
            }

            return false;
        }

        private Ray GetMouseRay()
        {
            return mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}