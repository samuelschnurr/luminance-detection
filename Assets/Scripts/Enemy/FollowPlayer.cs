using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public float MaxAngle = 45f;
    public float MaxDetectionRadius = 15f;    
    public float MaxFollowRadius = 45f;
    private GameObject player;
    private NavMeshAgent follower;
    private bool targetIsInFieldOfView;
    private bool targetIsInReminder;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MaxDetectionRadius);
        Gizmos.DrawWireSphere(transform.position, MaxFollowRadius);

        Gizmos.color = Color.blue;
        Vector3 leftAngle = Quaternion.AngleAxis(-MaxAngle, transform.up) * transform.forward * MaxDetectionRadius;
        Vector3 rightAngle = Quaternion.AngleAxis(MaxAngle, transform.up) * transform.forward * MaxDetectionRadius;
        Gizmos.DrawRay(transform.position, leftAngle);
        Gizmos.DrawRay(transform.position, rightAngle);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * MaxDetectionRadius);

        if (targetIsInFieldOfView)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * MaxDetectionRadius);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        follower = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        targetIsInFieldOfView = IsInFieldOfView(transform, player.transform, MaxAngle, MaxDetectionRadius);

        if (targetIsInFieldOfView)
        {
            targetIsInReminder = true;
        }

        if (targetIsInReminder)
        {
            targetIsInReminder = FollowTarget(transform, player.transform, follower, MaxFollowRadius);
        }
    }

    private static bool IsInFieldOfView(Transform origin, Transform target, float maxAngle, float maxRadius)
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

    private static bool FollowTarget(Transform origin, Transform target, NavMeshAgent navMeshAgent, float maxRadius)
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
