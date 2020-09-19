using Assets.Scripts.Other;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Enemy movement behaviour
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyCamera))]
    public class EnemyMovement : MonoBehaviour
    {
        private GameObject target;
        private NavMeshAgent follower;
        private EnemyCamera followerCamera;
        private bool canFollowTarget;

        void Start()
        {
            target = GameObject.FindWithTag("Player");
            follower = GetComponent<NavMeshAgent>();
            followerCamera = GetComponent<EnemyCamera>();
        }

        void Update()
        {
            if (CanFollowTarget())
            {
                canFollowTarget = true;
            }
        }

        void FixedUpdate()
        {
            if (canFollowTarget)
            {
                canFollowTarget = false;
                Movement.FollowTarget(transform, target.transform, follower);
            }
        }

        private bool CanFollowTarget()
        {
            follower.isStopped = followerCamera.IsFreezed;
            
            if (follower.isStopped)
            {
                return false;
            }

            if (!followerCamera.IsTargetInReminder)
            {
                return false;
            }

            return true;
        }
    }
}
