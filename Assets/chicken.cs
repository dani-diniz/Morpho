using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chicken : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        agent.SetDestination(player.transform.position);            
    }
}
