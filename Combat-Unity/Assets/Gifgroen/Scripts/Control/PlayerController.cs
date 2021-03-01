using System;
using Gifgroen.Combat;
using UnityEngine;
using Gifgroen.Core;

namespace Gifgroen.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Movement.Movement movement;

        [SerializeField] private Attacker attacker;

        [SerializeField] private Health health;

        private void Start()
        {
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (health.IsDead)
            {
                return;
            }
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
                Component t = hit.transform;
                if (!t.TryGetComponent(out Attackable a) || !attacker.CanAttack(a.gameObject))
                {
                    continue;
                }

                if (Input.GetMouseButton(0))
                {
                    attacker.Attack(a.gameObject);
                }

                return true;
            }

            return false;
        }

        private bool InteractWithMovement()
        {
            if (!Physics.Raycast(GetMouseRay(), out RaycastHit hit))
            {
                return false;
            }
            if (Input.GetMouseButton(0))
            {
                movement.StartMoveToDestination(hit.point);
            }

            return true;

        }

        private Ray GetMouseRay()
        {
            return mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}