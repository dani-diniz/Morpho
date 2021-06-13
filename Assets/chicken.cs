using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chicken : MonoBehaviour
{

    // Daniela : The chicken follows a GameObject, the player, which will be associated to the astronaut in Unity

    public GameObject player;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        // Daniela : the movement is determined by transformation on the player's position

        transform.LookAt(player.transform.position);
        agent.SetDestination(player.transform.position);
    }
}