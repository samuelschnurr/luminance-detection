using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent Follower;
    public GameObject Player;
    public float MaxDistance = 15f;

    void Start()
    {
        Follower = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance < MaxDistance)
        {
            Vector3 directionToPlayer = transform.position - Player.transform.position;
            Vector3 newPosition = transform.position - directionToPlayer;
            Follower.SetDestination(newPosition);
        }
    }
}
