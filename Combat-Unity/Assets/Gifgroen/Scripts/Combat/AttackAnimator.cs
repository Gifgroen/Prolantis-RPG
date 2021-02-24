using UnityEngine;

namespace Gifgroen.Combat
{
    public class AttackAnimator : MonoBehaviour
    {


        [SerializeField] private Animator animator;

        private bool _attacking = false;

        public void SetAttacking(bool newAttacking)
        {
            _attacking = newAttacking;
        }
        
        private void Update()
        {
            if (!_attacking)
            {
                return;
            }


        }
        
        public void Hit()
        {
            
        }
    }
}