using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollision : MonoBehaviour
{
    private GameObject player;
    private Controller_ controller;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<Controller_>();
        cc = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cc.velocity.y > 0f)
            {
                //turns the collision off
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                //turns the collision on
                GetComponent<Collider>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cc.velocity.y > 0)
            {
                //turns the collision off
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                //turns the collision on
                GetComponent<Collider>().enabled = true;
            }
        }
    }

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
