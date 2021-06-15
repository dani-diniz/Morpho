using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBlocks : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Controller_ controller;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = player.GetComponent<Rigidbody>();
        controller = player.GetComponent<Controller_>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            controller.onMud = true;
            controller._moveSpeed = 20f;
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
