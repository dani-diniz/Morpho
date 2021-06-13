using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToCollect : MonoBehaviour
{
    public static int objects = 0;
    // Use this for initialization
    void Awake()
    {
        objects++;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
            objects--;
        gameObject.SetActive(false);
    }
}
