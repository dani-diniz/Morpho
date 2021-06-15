using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBlocks : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Controller_ controller;

    // Diana : As the player has a Rigidbody now and this function is coorelated to the player controller 
    // Di: These lines were added
    // Di : Simillar to Camila's commentary as the codes are very simillar just the behavouir changes

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = player.GetComponent<Rigidbody>();
        controller = player.GetComponent<Controller_>();

    }

    // Di : We replaced the code that was on the player into this is one, as it provides a better view of the individual codes
    // Di : So, instead of a the dependent tag being the mud, the functions are now dependent on the player
    // Di : The function is still based on the player being inside the "Mud" collider or outside of it
    // Di : Being on the "Mud" or "Sticky Area" slows the velocity of the player, giving the felling of the player being dragged

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            controller.onMud = true;
            controller._moveSpeed = 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.onMud = false;
            controller._moveSpeed = 50f;
        }
    }

}
