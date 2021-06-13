using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private CharacterController controller;

	public float speed = 600.0f;
	public float turnSpeed = 400.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	public GameObject startPoint;

	/*Wind*/
	public float randomWind = 15f;
	public float windTime = 5f;
	private float windTimeInitial = 5f;
	private int randomFactor = 0;
	/*Wind*/

	/*Mud & Ice*/
	private bool onIce = false;
	private bool onMud = false;
	/*Mud & Ice*/

	private bool onFloor = true;

	/*Limit -Y*/
	public float donwLimit = -10f;

	void Start () {
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update ()
	{

		if (Input.GetKey ("w")) {
			anim.SetInteger ("AnimationPar", 1);
		}  else {
			anim.SetInteger ("AnimationPar", 0);
		}

		if(controller.isGrounded){
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			onFloor = true;
		}

        if (Input.GetKeyDown("space") && (onFloor == true))
        {
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

        if (randomWind <= 0)
        {
			windTime -= Time.deltaTime;



			if (randomFactor <= 4)
			{
				speed = 2f;
			}
            else
            {
				speed = 5;
            }

			if (windTime <= 0)
            {
				Debug.Log("Vento");
				windTime = windTimeInitial;
				randomWind = Random.Range(3, 20);
				randomFactor = Random.Range(0, 11);
				Debug.Log(randomFactor);
			}
        }
        else
        {
			if (onIce == false && onMud == false)
            {
				speed = 5f;
            }
        }

		/*WIND*/
		
		
		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}


    private void OnTriggerEnter(Collider collision)
    {
		//Mud
		if (collision.CompareTag("Mud"))
		{
			onMud = true;
			speed = 1f;
		}

		//Ice
		if (collision.CompareTag("Ice"))
		{
			onIce = true;
			speed = 10f;
		}
	}

    private void OnTriggerExit(Collider collision)
    {
		//Mud
		if (collision.CompareTag("Mud"))
		{
			onLama = false;
			speed = 5f;
		}

		//Ice
		if (collision.CompareTag("Ice"))
		{
			onLama = false;
			speed = 5f;
		}
	}
}
