using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(+200, 10, 20);

    // Update is called once per frame
    void Update()
    {
        //Camera following the player
        transform.position = player.transform.position + offset;

    }
}