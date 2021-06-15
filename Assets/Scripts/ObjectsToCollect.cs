using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToCollect : MonoBehaviour
{
    private GameObject player;
    private Controller_ controller;

    // Diana : We figured out an easier way to collect the object as we didn't desire to the Level Change any longer
    // Di : This way is also more simple

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<Controller_>();

    }

    // Di : As soon as the player collects the intended objects, they are supposed to destroy themselves and result on points

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            // Di : Increases the int value of points
            controller.points++;
            // Di : Destroys the game object
            Destroy(gameObject);
        }
    }

}
