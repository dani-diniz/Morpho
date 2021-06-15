using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    // Daniela : Camera follows GameObject, the player which will be linked to the astronaut in Unity

    public GameObject player;
   
    // Dani : Changing the camera's position, so, it provides the desired result instead of the ancor point determined by the player object
    // Dani : However, this was changed in order to achieve a look closer to the one intended

    private Vector3 offset = new Vector3(+200, 10, 20);

    
    void Update()
    {
        // Dani : Camera following the player
        transform.position = player.transform.position + offset;

    }
}