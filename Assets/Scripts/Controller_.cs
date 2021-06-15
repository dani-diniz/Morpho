using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_ : MonoBehaviour
{
    /*Player Variables*/
    public float _moveSpeed = 8f;
    public float _gravity = 9.81f;
    public float _jumpSpeed = 3.5f;
    public float _doubleJumpMultiplier = 0.5f;
    /*Player Variables*/

    public GameObject startPoint;
    public GameObject gameOver;
    public GameObject winScreen;

    /*Environment*/
    public bool onIce = false;
    public bool onMud = false;
    /*Environment*/

    public float donwLimit = -199f;

    /*Wind*/
    
    // Camila: constants help making the functions simpler and smaller, further explanations on the functions themselves

    public float randomWind = 15f;
    public float windTime = 5f;
    private float windTimeInitial = 5f;
    private int randomFactor = 0;
    
    /*Wind*/
   
    /*Item Collection UI*/

    public Text pointsText;
    public int points = 0;

    /*Item Collection UI*/

    public float _directionY;

    private bool _canDoubleJump = false;
    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        /*Joana's Player Movement*/
       
        // Joana : Horizontal Input results on sides (right and left) interaction

        float horizontalInput = Input.GetAxis("Horizontal");

        // Joana : Vertical Input results on fowards and backwards interaction

        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        

        _directionY -= _gravity * Time.deltaTime;

        direction.y = _directionY;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);
        
        /*Daniela's Game Over Condition/Instance*/

        if (transform.position.y <= donwLimit)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }

        /*Daniela's Game Over Condition/Instance*/

        _controller.Move(direction * _moveSpeed * Time.deltaTime);

        /*Joana's Player Movement*/

        /*WIND*/

        randomWind -= Time.deltaTime;
        // Camila : all of the following functions are determined by velocity of the wind being under or equal to 0
        if (randomWind <= 0)
        {
            // Camila : wind time should make the player's speed slower

            windTime -= Time.deltaTime;

            // Camila : speed of the player, works as to the determine the resistance in this function
            //such resistance is determined by the randomFactor being under or equal to 4

            if (randomFactor <= 4)
            {
                _moveSpeed = 20f;
            }
            else
            {
                _moveSpeed = 50;
            }

            // Camila : determining the wind time and randomizing of it as wind time goes < 0
            // That randomization shall be determined in intervals of 3 to 20
            // The range of such wind is determined in randomized intervals of 0 to 11

            if (windTime <= 0)
            {
                windTime = windTimeInitial;
                randomWind = Random.Range(3, 20);
                randomFactor = Random.Range(0, 11);
            }
        }

        // Camila: When on "ice" and "mud", wind must not affect the player, so, interactions don't compete with each other

        else
        {
            if (onIce == false && onMud == false)
            {
                _moveSpeed = 50f;
            }
        }

        /*WIND*/

        /*Catarina and Diana's Item Capturing UI*/

        // Catarina and Diana : Update the UI as items get captured

        pointsText.text = "Points: " + points;

        // Catarina and Diana : Consequene of getting all the items

        if (points >= 12)
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }
   
    /*Joana's Jumps*/

    private void Update()
    {   
        // Joana : Regular Jump

        if (_controller.isGrounded)
        {
            _canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpSpeed;

            }
        }
        else
        {
            // Jo : Changes in order to make double jumping possible
            // Jo : Double jump is determined by a multipler, predetermined

            if (Input.GetButtonDown("Jump") && _canDoubleJump)
            {
                _directionY = _jumpSpeed * _doubleJumpMultiplier;
                _canDoubleJump = false;
            }
        }
       
       /*Joana's Jumps*/

    }
}