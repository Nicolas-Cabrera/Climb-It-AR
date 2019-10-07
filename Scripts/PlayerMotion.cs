using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{

	public float moveSpeed = 5.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;
	public VirtualJooyStick moveJoystick;
    Animator animPlayer;
    GameObject player;

    //jumping
    public float jumpForce = 7;
    public bool canJump = false;

	private Rigidbody controller;
	private Transform camTransform;

	// Use this for initialization
	void Start () 
	{
        controller = GetComponent<Rigidbody> ();
		controller.maxAngularVelocity = terminalRotationSpeed;
		controller.drag = drag;

        animPlayer = GetComponent<Animator>();

        camTransform = Camera.main.transform;
        animPlayer.SetBool("isIdle", true);
	}

    public void OnCollisionEnter(Collision other)// collinding with the terrain 
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    public void OnCollisionExit(Collision other)// stops player from jumping when in the air
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }


    public void Jump_Button()// jumping with on screen button
    {
        if (canJump == true)
        {
            controller.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void onAxeButton()
    {
        animPlayer.SetTrigger("isCutting");
        Debug.Log("Axe activated");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");


       //getaxis
        if (dir.magnitude > 1)
            dir.Normalize();

       if (moveJoystick.InputDirection != Vector3.zero || dir.z != 0)//overrights keyboard input
        {
            dir = moveJoystick.InputDirection;
            animPlayer.SetBool("isWalking", true);
            animPlayer.SetBool("isIdle", false);
        }
        else
        {
            animPlayer.SetBool("isWalking", false);
            animPlayer.SetBool("isIdle", true);
        }
       

        //rotating with camera
        Vector3 rotatedDir = camTransform.TransformDirection(dir);
        rotatedDir = new Vector3(rotatedDir.x, 0, rotatedDir.z);
        rotatedDir = rotatedDir.normalized * dir.magnitude;

        controller.AddForce(rotatedDir * moveSpeed);// moves the player

        if (dir.x != 0 || dir.z != 0)
        {
            controller.MoveRotation(Quaternion.LookRotation(dir));
        }
       


        /*if (dir.z > 0 | dir.z < 0) // rotates player with the camera
         if(camTransform)//player rotates with camera 
         {
             Quaternion turnAngle = Quaternion.Euler(0, camTransform.eulerAngles.y, 0);
             controller.rotation = Quaternion.Slerp(controller.rotation, turnAngle, Time.deltaTime * 5f);
         }  */
    }
}
