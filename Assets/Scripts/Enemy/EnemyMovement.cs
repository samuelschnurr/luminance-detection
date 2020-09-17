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
        public float MaxFollowRadius = 45f;
        public float MaxLightLevel = 6300000;        
        private GameObject target;
        private NavMeshAgent follower;
        private EnemyCamera followerCamera;
        private bool isTargetInReminder;

        private void OnDrawGizmos()
        {
            if (isTargetInReminder)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, MaxFollowRadius);
            }
        }

        void Start()
        {
            target = GameObject.FindWithTag("Player");
            follower = GetComponent<NavMeshAgent>();
            followerCamera = GetComponent<EnemyCamera>();
        }

        void Update()
        {
            follower.isStopped = followerCamera.GetLuminance() > MaxLightLevel;

            if (follower.isStopped)
            {
                return;
            }

            if (followerCamera.IsTargetInFieldOfView)
            {
                isTargetInReminder = true;
            }

            if (isTargetInReminder)
            {
                isTargetInReminder = Movement.FollowTarget(transform, target.transform, follower, MaxFollowRadius);
            }
        }
    }
}
