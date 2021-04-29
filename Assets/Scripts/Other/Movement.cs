using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Other
{
    /// <summary>
    /// Movement helpers
    /// </summary>
    public static class Movement
    {
        /// <summary>
        /// Follows a target
        /// </summary>
        /// <param name="origin">The origin object</param>
        /// <param name="target">The target to follow</param>
        /// <param name="navMeshAgent">The AI navMeshAgent</param>
        public static void FollowTarget(Transform origin, Transform target, NavMeshAgent navMeshAgent)
        {
            Vector3 directionToTarget = origin.position - target.position;
            Vector3 newPosition = origin.position - directionToTarget;
            navMeshAgent.SetDestination(newPosition);
        }
    }
}
