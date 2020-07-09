using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool slide = false;

	// Update is called once per frame
	void Update () {

		horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (CrossPlatformInputManager.GetButtonDown("Slide"))
		{
			slide = true;
            animator.SetBool("IsSliding", true);
        } else if (CrossPlatformInputManager.GetButtonUp("Slide"))
		{
			slide = false;
            animator.SetBool("IsSliding", false);
        }

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	//public void OnSliding (bool isSliding)
	//{
	//	animator.SetBool("IsSliding", isSliding);
	//}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, slide, jump);
		jump = false;
	}
}
