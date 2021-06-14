using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToCollect : MonoBehaviour
{
    private GameObject player;
    private Controller_ controller;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<Controller_>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            //Increase the int value of points
            controller.points++;
            //Destroy the game object
            Destroy(gameObject);
        }
    }

}
