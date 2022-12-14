
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    public float Velocity;
    [Space]

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

	public bool izquierda = false;
	public bool derecha = false;
	public bool arriba = false;
	public bool abajo = false;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float verticalVel;
    private Vector3 moveVector;

	// Use this for initialization
	void Start () {
		//anim = this.GetComponent<Animator> ();
		//cam = Camera.main;
		//controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		InputMagnitude ();

        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 1;
        }
        //moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        //controller.Move(moveVector);


    }

    void PlayerMoveAndRotation() {
		if (izquierda)
		{
			InputX = -1;
			InputZ = 0;
			//InputX = Input.GetAxis("Horizontal"); //derecha 1, izqueirda -1
		}
		if(derecha)
        {
			InputX = 1;
			InputZ = 0;
		}

        if (arriba)
        {
			InputZ = -1;
			InputX = 0;
		}
        if (abajo)
        {
			InputZ = 1;
			InputX = 0;
		}
		//InputZ = Input.GetAxis ("Vertical");


		var forward = new Vector3(0,0,1); 
			//cam.transform.forward;
		var right = cam.transform.right;

		//forward.y = 0f;
		right.y = 0f;

		//forward.Normalize ();
	    right.Normalize ();
		
		if(izquierda || derecha)
        {
			desiredMoveDirection = right * InputX;
		}
		if(arriba || abajo)
        {
			desiredMoveDirection = forward * InputZ;
		}
		//desiredMoveDirection = forward * InputZ + right * InputX;

		if (blockRotationPlayer == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
		}
	}
	
	void InputMagnitude() {
		//Calculate Input Vectors
		if (izquierda)
		{
			InputX = -1;
			InputZ = 0;
			//InputX = Input.GetAxis("Horizontal"); //derecha 1, izqueirda -1
		}
		if (derecha)
		{
			InputX = 1;
			InputZ = 0;
		}

		if (arriba)
		{
			InputZ = 1;
			InputX = 0;
		}
		if (abajo)
		{
			InputZ = -1;
			InputX = 0;
		}


		//InputZ = Input.GetAxis ("Vertical");

		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

		if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		} else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
		}
	}
}
