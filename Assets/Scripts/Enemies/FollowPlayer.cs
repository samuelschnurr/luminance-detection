using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public float MaxDistance = 15f;
    private GameObject player;
    private NavMeshAgent follower;      

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        follower = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < MaxDistance)
        {
            Vector3 directionToPlayer = transform.position - player.transform.position;
            Vector3 newPosition = transform.position - directionToPlayer;
            follower.SetDestination(newPosition);
        }
    }
}
