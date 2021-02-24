using System.Runtime.InteropServices.WindowsRuntime;
using Gifgroen.Core;
using UnityEngine;

namespace Gifgroen.Combat
{
    public class Attacker : MonoBehaviour, IAction
    {
        private static readonly int AttackAnimationId = Animator.StringToHash("attack");

        private static readonly int StopAttackAnimationId = Animator.StringToHash("stopAttack");

        [SerializeField] private Health currentTarget;

        [SerializeField] private float attackDistance = 2f;

        [SerializeField] private ActionScheduler actionScheduler;

        [SerializeField] private Animator animator;

        [SerializeField] private float attackInterval = 2f;

        [SerializeField] private float timeSinceLastAttack;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (currentTarget == null)
            {
                return;
            }

            if (currentTarget.IsDead)
            {
                return;
            }

            Movement.Movement m = GetComponent<Movement.Movement>();
            if (Vector3.Distance(transform.position, currentTarget.transform.position) >= attackDistance)
            {
                m.MoveToDestination(currentTarget.transform.position);
            }
            else
            {
                m.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(currentTarget.transform);
            if (timeSinceLastAttack <= attackInterval)
            {
                return;
            }

            animator.ResetTrigger(StopAttackAnimationId);
            animator.SetTrigger(AttackAnimationId);
            timeSinceLastAttack = 0f;
        }

        public bool CanAttack(Attackable a)
        {
            return a.TryGetComponent(out Health h) && !h.IsDead;
        }

        public void Attack(Attackable a)
        {
            actionScheduler.StartAction(this);
            currentTarget = a.GetComponent<Health>();
        }

        public void Cancel()
        {
            currentTarget = null;
            animator.ResetTrigger(AttackAnimationId);
            animator.SetTrigger(StopAttackAnimationId);
        }

        private void Hit()
        {
            if (currentTarget == null)
            {
                return;
            }

            currentTarget.TakeDamage(5);
        }
    }
}