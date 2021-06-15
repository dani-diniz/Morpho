using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBloks : MonoBehaviour
{
    private GameObject player;

    private CharacterController cc;
    private Controller_ controller;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CharacterController>();
        controller = player.GetComponent<Controller_>();

    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.CompareTag("Player"))
        {
            //create a speed in Y to bounce the player
            float bounce = 4;
            controller._directionY = bounce;

        }
    }
}
