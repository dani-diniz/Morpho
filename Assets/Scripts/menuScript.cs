using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{

    public GameObject player;
    public GameObject start;
    public GameObject gameOver;
    
    public void Retry()
    {
        CharacterController cr = player.GetComponent<CharacterController>();
        cr.enabled = false;
        Time.timeScale = 1;
        player.transform.position = start.transform.position;
        cr.enabled = true;
        gameOver.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }

}
