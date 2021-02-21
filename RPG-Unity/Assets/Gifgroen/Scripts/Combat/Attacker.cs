using Gifgroen.Core;
using UnityEngine;

namespace Gifgroen.Combat
{
    public class Attacker : MonoBehaviour, IAction
    {
        [SerializeField] private Transform currentTarget;

        [SerializeField] private float attackDistance = 2f;

        [SerializeField] private ActionScheduler actionScheduler;
        
        private void Update()
        {
            if (currentTarget == null)
            {
                return;
            }

            Movement.Movement m = GetComponent<Movement.Movement>();
            if (Vector3.Distance(transform.position, currentTarget.position) >= attackDistance)
            {
                m.MoveToDestination(currentTarget.position);
            }
            else
            {
                m.Cancel();
            }
        }

        public void Attack(Attackable a)
        {
            actionScheduler.StartAction(this);
            currentTarget = a.transform;
        }

        public void Cancel()
        {
            currentTarget = null;
        }
    }
}