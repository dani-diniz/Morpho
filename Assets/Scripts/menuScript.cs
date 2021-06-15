using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    
    // Catarina : In order to develop a Game Over screen, we need to set areas as gameover and start

    public GameObject player;
    public GameObject start;
    public GameObject gameOver;
    
    // Cat : As you press Retry, the Characheter Controller is disabled
    // Cat : With a small delay, the player is transfered to the start
    // Cat : And, the Characheter Controller enabled again

    public void Retry()
    {
        CharacterController cr = player.GetComponent<CharacterController>();
        cr.enabled = false;
        Time.timeScale = 1;
        player.transform.position = start.transform.position;
        cr.enabled = true;
        gameOver.SetActive(false);

    }
    
    // Cat : If the quit button is pressed, the unity application shuts off

    public void Quit()
    {
        Application.Quit();
    }

}
