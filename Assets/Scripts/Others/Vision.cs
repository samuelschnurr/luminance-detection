using UnityEngine;

namespace Assets.Scripts.Others
{
    /// <summary>
    /// Basic vision helpers
    /// </summary>
    public class Vision
    {
        public static bool IsInFieldOfView(Transform origin, Transform target, float maxAngle, float maxRadius)
        {
            // Get all colliders within the radius ob the origin object
            Collider[] overlaps = Physics.OverlapSphere(origin.position, maxRadius);

            foreach (Collider overlap in overlaps)
            {
                if (overlap.transform != target)
                {
                    continue;
                }

                // Normalize when you only care about the direction but not about the distance
                Vector3 directionToTarget = (target.position - origin.position).normalized;

                // The height is not a factor in the field of view angle
                directionToTarget.y *= 0;

                // The angle the origin objects needs, to see the target
                float angle = Vector3.Angle(origin.forward, directionToTarget);

                // The angle is within the field of view of the origin object
                if (angle <= maxAngle)
                {
                    Vector3 distanceToTarget = target.position - origin.position;
                    Ray ray = new Ray(origin.position, distanceToTarget);

                    // Raycast to check if there are obstacles in front of the target
                    if (Physics.Raycast(ray, out RaycastHit hit, maxRadius))
                    {
                        if (hit.transform == target)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
