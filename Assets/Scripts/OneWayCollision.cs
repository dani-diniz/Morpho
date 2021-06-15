using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollision : MonoBehaviour
{
    private GameObject player;
    private Controller_ controller;
    private CharacterController cc;
    
    // Camila : What is desired of this code is that this particular platform is acessible through the bottom ad can be existed through a key
    // Cami : Acts almost as if it isn't solid
    // Cami : The previous code for this platforms was wrong as it was done with 2D modifiers that didn't work with 3D objects/models

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<Controller_>();
        cc = player.GetComponent<CharacterController>();
    }
    
    // Cami : Simillar to the Slippery Blocks and Sticky Blocks, this interactin is also connected to the player's controller and collision with the platform

    // Cami : If the player is moving up, the collision turns off (Velocity of y being higher then 0)
    // Cami : When that velocity stops, the collider turns on again as a way to keep the player on the platform

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cc.velocity.y > 0f)
            {
                // Cami : turns the collision off
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                // Cami : turns the collision on
                GetComponent<Collider>().enabled = true;
            }
        }
    }

    // Cami : The same scenario happens when the Player wants to exit the platform

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cc.velocity.y > 0)
            {
                // Cami : turns the collision off
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                // Cami : turns the collision on
                GetComponent<Collider>().enabled = true;
            }
        }
    }

    // Cami : Since this is the only platform that we wanted the player to be able to go down from
    // Cami : E was added as a way to turn the collider off and make the player fall 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //turns the collision off
            if (Input.GetKeyDown("e"))
            {
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
