using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Others
{
    /// <summary>
    /// Basic momvement helpers
    /// </summary>
    public class Movement
    {
        /// <summary>
        /// Follows a target
        /// </summary>
        /// <param name="origin">The origin object</param>
        /// <param name="target">The target to follow</param>
        /// <param name="navMeshAgent">The AI navMeshAgent</param>
        /// <param name="maxRadius">The maximum radius until the origin stops to follow the target</param>
        /// <returns>Return true if the origin is following the target, else false</returns>
        public static bool FollowTarget(Transform origin, Transform target, NavMeshAgent navMeshAgent, float maxRadius)
        {
            float distance = Vector3.Distance(origin.position, target.position);

            // Target is in distance
            if (distance <= maxRadius)
            {
                Vector3 directionToTarget = origin.position - target.position;
                Vector3 newPosition = origin.position - directionToTarget;
                navMeshAgent.SetDestination(newPosition);
                return true;
            }

            return false;
        }
    }
}
