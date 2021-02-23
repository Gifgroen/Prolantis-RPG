using Gifgroen.Core;
using UnityEngine;

namespace Gifgroen.Combat
{
    public class Attacker : MonoBehaviour, IAction
    {
        [SerializeField] private Transform currentTarget;

        [SerializeField] private float attackDistance = 2f;

        [SerializeField] private ActionScheduler actionScheduler;

        [SerializeField] private Animator animator;

        
        private static readonly int AttackTriggerKey = Animator.StringToHash("attack");
        
        [SerializeField] private float attackInterval = 2f;

        [SerializeField] private float timeSinceLastAttack;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

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
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack <= attackInterval)
            {
                return;
            }

            animator.SetTrigger(AttackTriggerKey);
            timeSinceLastAttack = 0f;
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

        void Hit()
        {
            if (currentTarget != null && currentTarget.TryGetComponent(out Health health))
            {
                health.TakeDamage(5);
            }
        }
    }
}