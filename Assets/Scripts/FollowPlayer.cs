using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Daniela : Camera follows GameObject, the player which will be linked to the astronaut in Unity

    public GameObject player;

    // Daniela : Changing the camera's position, so, it provides the desired result instead of the ancor point determined by the player object

    private Vector3 offset = new Vector3(6, 4, -13);

    // Update is called once per frame
    void LateUpdate()
    {
        // Daniela : Accurate camera positioning

        transform.position = player.transform.position + offset;

    }
}