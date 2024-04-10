using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllAndriod : MonoBehaviour
{
	public float speedMove;
    private float gravityForce;
    private Vector3 moveVector;
	
	private CharacterController ch_controller;
	public Joystick joy;
	
	void Start()
    {
		Time.timeScale = 1.0f;
        ch_controller = GetComponent<CharacterController>();
	}
	
	private void FixedUpdate()
    {
        MovePlayer();
        GamingGravity();
    }
	
	private void MovePlayer()
    {
        moveVector = Vector3.zero;
        moveVector.x = joy.Horizontal;
        moveVector.z = joy.Vertical;

        moveVector.y = gravityForce;

        moveVector = transform.right * moveVector.x + transform.forward * moveVector.z + transform.up * moveVector.y;

        ch_controller.Move(moveVector * speedMove * Time.deltaTime);
    }
    
    private void GamingGravity()
    {
        if(!ch_controller.isGrounded)
        {
            gravityForce -= 10f * Time.deltaTime;
        }
        else
        {
            gravityForce = -1f;
        }
    }
}
