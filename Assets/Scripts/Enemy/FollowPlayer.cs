using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public float MaxRadius = 15f;
    public float MaxAngle = 45f;
    public float MaxDetection = 15f;
    private GameObject player;
    private NavMeshAgent follower;
    private bool playerDetected;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MaxRadius);
        Vector3 line1 = Quaternion.AngleAxis(MaxAngle, transform.up) * transform.forward * MaxRadius;
        Vector3 line2 = Quaternion.AngleAxis(-MaxAngle, transform.up) * transform.forward * MaxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, line1);
        Gizmos.DrawRay(transform.position, line2);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * MaxRadius);

        if (!playerDetected)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * MaxRadius);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        follower = GetComponent<NavMeshAgent>();
    }    

    public static bool Test(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = Physics.OverlapSphere(checkingObject.position, maxRadius);

        foreach (Collider overlap in overlaps)
        {
            if (overlap.transform == target)
            {
                // Normalize when you only care about the direction but not about the distance
                Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                
                // The height is not a factor in the angle
                directionBetween.y *= 0;

                float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                if(angle <= maxAngle)
                {
                    Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit, maxRadius))
                    {
                        if(hit.transform == target)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    void Update()
    {
        playerDetected = Test(transform, player.transform, MaxAngle, MaxRadius);
        
        //float distance = Vector3.Distance(transform.position, player.transform.position);

        //// Player is in distance
        //if(distance < MaxRadius)
        //{
        //    RaycastHit hit;

        //    // Check if a collider is hit
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxDetection))
        //    {
        //        // Check if player is hit
        //        if (hit.collider.gameObject.CompareTag("Player"))
        //        {
        //            playerDetected = true;
        //        }
        //    }

        //    if (playerDetected)
        //    {
        //        // Follow the player
        //        Vector3 directionToPlayer = transform.position - player.transform.position;
        //        Vector3 newPosition = transform.position - directionToPlayer;
        //        follower.SetDestination(newPosition);
        //    }
        //}
        //else
        //{
        //    // Max Distance is reached
        //    // Focus to player is lost
        //    playerDetected = false;
        //}
    }
}
