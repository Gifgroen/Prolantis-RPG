using System;
using UnityEngine;

namespace Gifgroen.Core
{
    public class Health : MonoBehaviour
    {
        private static readonly int DieAnimationId = Animator.StringToHash("die");

        [SerializeField] private float current = 100f;

        [SerializeField] private Animator animator;

        private ActionScheduler actionScheduler;
        public bool IsDead => current == 0;

        private void Start()
        {
            actionScheduler = GetComponent<ActionScheduler>();
        }

        public void TakeDamage(float damage)
        {
            current = Mathf.Max(0, current - damage);
            if (current == 0)
            {
                animator.SetTrigger(DieAnimationId);
                actionScheduler.CancelCurrentAction();
            }
        }
    }
}