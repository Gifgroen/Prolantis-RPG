using UnityEngine;

namespace Gifgroen.Combat
{
    public class Health : MonoBehaviour
    {
        private static readonly int DieAnimationId = Animator.StringToHash("die");

        [SerializeField] private float current = 100f;

        [SerializeField] private Animator animator;

        public bool IsDead => current == 0;

        public void TakeDamage(float damage)
        {
            current = Mathf.Max(0, current - damage);
            if (current == 0)
            {
                animator.SetTrigger(DieAnimationId);
            }
        }
    }
}