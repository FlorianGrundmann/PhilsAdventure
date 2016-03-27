using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private bool onGround; //If the enemy is standing at an edge
	public bool OnGround{
		get {return onGround;}
	}

	public float groundCheckRadius = 0.1f; //Radius in which a ground is searched
	public LayerMask whatIsGround; //Layer which defines the wall
	public Transform groundCheck; //Point of the ground check
	

	// Update is called once per frame
	void Update () {
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
}
