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
	/*Wind*/

	/*Lama & Gelo*/
	private bool onGelo = false;
	private bool onLama = false;
	/*Lama & Gelo*/

	private bool onFloor = true;

	/*Limite -Y*/
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

			speed = 2f;

            if (windTime <= 0)
            {
				windTime = windTimeInitial;
				randomWind = Random.Range(3, 20);
            }
        }
        else
        {
			if (onGelo == false && onLama == false)
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
		//LAMA
		if (collision.CompareTag("Lama"))
		{
			onLama = true;
			speed = 1f;
		}

		//LAMA
		if (collision.CompareTag("Gelo"))
		{
			onGelo = true;
			speed = 10f;
		}
	}

    private void OnTriggerExit(Collider collision)
    {
		//LAMA
		if (collision.CompareTag("Lama"))
		{
			onLama = false;
			speed = 5f;
		}

		//LAMA
		if (collision.CompareTag("Gelo"))
		{
			onLama = false;
			speed = 5f;
		}
	}
}
