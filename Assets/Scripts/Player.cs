using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	//animation
	private Animator anim;
	//controller
	private CharacterController controller;

	/*Player Movement*/

	// Joana: constants that determine the physics and velocity of the body (player), they also determine where the game starts

	public float speed = 50.0f;
	public float turnSpeed = 400.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 9.81f;
	public GameObject startPoint;

	/*Player Movement*/

	/*Wind*/

	// Camila: constants help making the functions simpler and smaller, further explanations on the functions themselves

	public float randomWind = 15f;
	public float windTime = 5f;
	private float windTimeInitial = 5f;
	private int randomFactor = 0;

	/*Wind*/

	/*Mud & Ice*/

	//Ice/Slippery Floor

	// Camila: bool provides the ability to change the state of the floor

	private bool onIce = false;

	//Mud/Sticky Floor

	// Diana: bool provides the ability to change the state of the floor

	private bool onMud = false;

	/*Mud & Ice*/

	private bool onFloor = true;

	/*Limit -Y*/

	public float donwLimit = -10f;

	/*Limit -Y*/

	void Start()
	{
		//controller

		controller = GetComponent<CharacterController>();

		//animation

		anim = gameObject.GetComponentInChildren<Animator>();

	}

	void Update()
	{

		//animation

		if (Input.GetKey("w"))
		{
			anim.SetInteger("AnimationPar", 1);
		}
		else
		{
			anim.SetInteger("AnimationPar", 0);
		}

		// Joana : walk fowards and backwards through the up and down arrows

		if (controller.isGrounded)
		{
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

			// Joana : player is grounded to the floor

			onFloor = true;
		}

		// Joana: simple jump
		//Space is the key selected for the player to jump 
		//Constrictions are impled in order to avoid the player going too far
		//Jump can be done more than once

		if (Input.GetKeyDown("space") && (onFloor == true))
		{

			// Joana : player is longer grounded to the floor

			onFloor = false;
			moveDirection.x = 7;
			moveDirection.y = 18;

		}


		if (transform.position.y <= donwLimit)
		{
			controller.enabled = false;
			transform.position = startPoint.transform.position;
			controller.enabled = true;
		}

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
				speed = 2f;
			}
			else
			{
				speed = 5;
			}

			// Camila : determining the wind time and randomizing of it as wind time goes < 0
			// That randomization shall be determined in intervals of 3 to 20
			// The range of such wind is determined in randomized intervals of 0 to 11

			if (windTime <= 0)
			{
				Debug.Log("Wind");
				windTime = windTimeInitial;
				randomWind = Random.Range(3, 20);
				randomFactor = Random.Range(0, 11);
				Debug.Log(randomFactor);
			}
		}

		// Camila: When on ice and mud, wind must not affect the player, so, interactions don't compete with each other

		else
		{
			if (onIce == false && onMud == false)
			{
				speed = 5f;
			}
		}

		/*WIND*/

		/*Player Movement*/

		//Joana: Rotation of the player determined by the side arrows

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);

		//Joana: Gravity function in order to make the player behave normally

		moveDirection.y -= gravity * Time.deltaTime;

		/*Player Movement*/
	}

	// Diana : Inside the mud, the velocity is slower than usual

	// Camila : Inside the ice, the velocity is faster than usual

	// Diana and Camila : True and False determine whenether the player is on the mud/ice or not

	private void OnTriggerEnter(Collider collision)
	{
		/*Mud/Sticky Floor*/

		if (collision.CompareTag("Mud"))
		{

			onMud = true;
			speed = 1f;

		}

		/*Mud/Sticky Floor*/

		/*Ice/Slippery Floor*/

		if (collision.CompareTag("Ice"))
		{

			onIce = true;
			speed = 10f;

		}

		/*Ice/Slippery Floor*/
	}

	private void OnTriggerExit(Collider collision)
	{
		/*Mud/Sticky Floor*/

		if (collision.CompareTag("Mud"))
		{

			onMud = false;
			speed = 5f;

		}

		/*Mud/Sticky Floor*/

		/*Ice/Slippery Floor*/

		if (collision.CompareTag("Ice"))
		{

			onIce = false;
			speed = 5f;

		}

		/*Ice/Slippery Floor*/
	}
}
