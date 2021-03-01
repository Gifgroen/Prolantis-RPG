using Gifgroen.Combat;
using Gifgroen.Core;
using UnityEngine;

namespace Gifgroen.Control
{
    public class AiController : MonoBehaviour
    {
        [SerializeField] private float attackRange = 5f;

        [SerializeField] private float suspiciousTime = 5f;

        [SerializeField] private Movement.Movement movement;

        [SerializeField] private Attacker attacker;

        [SerializeField] private Health health;

        [SerializeField] private ActionScheduler actionScheduler;

        [SerializeField] private GameObject player;

        [SerializeField] private Vector3 guardPosition;

        [SerializeField] private float timeSinceLastSeenPlayer;

        [SerializeField] private Path patrolPath;

        [SerializeField] private int currentWaypointIndex = 0;

        [SerializeField] private float arrivalTime = Mathf.Infinity;

        [SerializeField] private float waitTime = 2f;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            guardPosition = transform.position;
        }

        private void Update()
        {
            if (health.IsDead)
            {
                return;
            }

            if (InAttackRange(player) && attacker.CanAttack(player))
            {
                AttackBehaviour();
            }
            else if (timeSinceLastSeenPlayer < suspiciousTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                PatrolBehaviour();
            }

            timeSinceLastSeenPlayer += Time.deltaTime;
            arrivalTime += Time.deltaTime;
        }

        private void SuspicionBehaviour()
        {
            actionScheduler.CancelCurrentAction();
        }

        private void AttackBehaviour()
        {
            attacker.Attack(player);
            timeSinceLastSeenPlayer = 0;
        }


        private void PatrolBehaviour()
        {
            Vector3 nextPosition = guardPosition;
            if (patrolPath != null)
            {
                if (AtWaypoint())
                {
                    arrivalTime = 0;
                    CycleWaypoint();
                }

                nextPosition = GetCurrentWaypoint();
            }

            if (arrivalTime < waitTime)
            {
                return;
            }

            movement.StartMoveToDestination(nextPosition);
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetCurrentWaypoint(currentWaypointIndex);
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.CycleWaypoint(currentWaypointIndex);
        }

        private bool AtWaypoint()
        {
            return Vector3.Distance(transform.position, GetCurrentWaypoint()) < 0.1f;
        }

        private bool InAttackRange(GameObject playerToCheck)
        {
            return Vector3.Distance(transform.position, playerToCheck.transform.position) < attackRange;
        }

        private void OnDrawGizmosSelected()
        {
            GameObject currentPlayer = GameObject.FindWithTag("Player");
            Color color = Gizmos.color;
            Gizmos.color = InAttackRange(currentPlayer) ? Color.red : Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = color;
        }
    }
}