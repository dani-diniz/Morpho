using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenFollowPlayer : MonoBehaviour
{
    // This code was replaced by putting the chicken as a child of the player object as we were unable to make it jump
    // Daniela : The chicken follows a GameObject, the player, which will be associated to the astronaut in Unity

    public GameObject player;
    private NavMeshAgent agent;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Dani : the movement is determined by transformation on the player's position

        agent.SetDestination(player.transform.position);
        transform.LookAt(player.transform.position);
    }
}
