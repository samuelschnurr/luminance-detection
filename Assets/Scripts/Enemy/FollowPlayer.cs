using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public float MaxDistance = 15f;
    public float MaxDetection = 15f;
    private GameObject player;
    private NavMeshAgent follower;
    private bool playerDetected;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        follower = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * MaxDetection, Color.yellow);

        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Player is in distance
        if(distance < MaxDistance)
        {
            RaycastHit hit;

            // Check if a collider is hit
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxDetection))
            {
                // Check if player is hit
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * MaxDetection, Color.red);
                    playerDetected = true;
                }
            }

            if (playerDetected)
            {
                // Follow the player
                Vector3 directionToPlayer = transform.position - player.transform.position;
                Vector3 newPosition = transform.position - directionToPlayer;
                follower.SetDestination(newPosition);
            }
        }
        else
        {
            // Max Distance is reached
            // Focus to player is lost
            playerDetected = false;
        }
    }
}
