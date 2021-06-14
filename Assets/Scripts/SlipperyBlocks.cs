using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyBlocks : MonoBehaviour
{
    private GameObject player;
    private CharacterController cc;
    private Controller_ controller;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<Controller_>();

    }

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
