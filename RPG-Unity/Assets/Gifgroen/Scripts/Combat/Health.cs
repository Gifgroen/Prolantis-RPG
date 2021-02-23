using UnityEngine;

namespace Gifgroen.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float current = 100f;

        public void TakeDamage(float damage)
        {
            current = Mathf.Max(0, current - damage);
            print($"Current = {current}");
        }
    }
}
