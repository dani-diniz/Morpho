using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyBlocks : MonoBehaviour
{
    private GameObject player;
    private CharacterController cc;
    private Controller_ controller;

    // Camila : As the player has a Rigidbody now and this function is coorelated to the player controller 
    // Cami : These lines were added 
    // Cami : Simillar to Diana's commentary as the codes are very simillar just the behavouir changes

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<Controller_>();

    }

    // Cami : We replaced the code that was on the player into this is one, as it provides a better view of the individual codes
    // Cami : So, instead of a the dependent tag being the ice, the functions are now dependent on the player
    // Cami : The function is still based on the player being inside the "Ice" collider or outside of it
    // Cami : Being on the "Ice" or "Slippery Area" increases the velocity of the player, giving the felling of the player being pushed/slipping

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Increase speed of the player if collides
            controller.onIce = true;
            controller._moveSpeed = 80f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Speed back to normal
            controller.onIce = false;
            controller._moveSpeed = 50f;
        }
    }
}
