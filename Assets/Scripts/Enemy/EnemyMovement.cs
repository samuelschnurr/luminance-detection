using Assets.Scripts.Other;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Enemy movement behaviour
    /// </summary>
    public class EnemyMovement : MonoBehaviour
    {
        public float MaxAngle = 45f;
        public float MaxDetectionRadius = 15f;
        public float MaxFollowRadius = 45f;
        private GameObject player;
        private NavMeshAgent follower;
        private DetectLight lightDetector;
        private bool isTargetInFieldOfView;
        private bool isTargetInReminder;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, MaxDetectionRadius);

            if (isTargetInReminder)
            {
                Gizmos.DrawWireSphere(transform.position, MaxFollowRadius);
            }

            Gizmos.color = Color.blue;
            Vector3 leftAngle = Quaternion.AngleAxis(-MaxAngle, transform.up) * transform.forward * MaxDetectionRadius;
            Vector3 rightAngle = Quaternion.AngleAxis(MaxAngle, transform.up) * transform.forward * MaxDetectionRadius;
            Gizmos.DrawRay(transform.position, leftAngle);
            Gizmos.DrawRay(transform.position, rightAngle);

            Gizmos.color = Color.black;
            Gizmos.DrawRay(transform.position, transform.forward * MaxDetectionRadius);

            if (isTargetInFieldOfView)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }

            if (player != null)
            {
                Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * MaxDetectionRadius);
            }
        }

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            follower = GetComponent<NavMeshAgent>();
            lightDetector = GetComponent<DetectLight>();
        }

        void Update()
        {
            follower.isStopped = lightDetector.IsFreezed;

            if (follower.isStopped)
            {
                return;
            }

            isTargetInFieldOfView = Vision.IsInFieldOfView(transform, player.transform, MaxAngle, MaxDetectionRadius);

            if (isTargetInFieldOfView)
            {
                isTargetInReminder = true;
            }

            if (isTargetInReminder)
            {
                isTargetInReminder = Movement.FollowTarget(transform, player.transform, follower, MaxFollowRadius);
            }
        }
    }
}
