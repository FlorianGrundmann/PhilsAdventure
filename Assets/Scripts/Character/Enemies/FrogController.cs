using UnityEngine;
using System.Collections;

public class FrogController : MonoBehaviour {

	private bool moveRight; //If enemy is moving right
	
	public float jumpVelocityX;
	public float jumpVelocityY;
	public bool jumpBack;
	private bool isJumping;
	private float waitToJump = 3;
	private float waited;

	private Animator animator;
	
	private bool atWall; //If the the enemy is hitting a wall
	private bool atEdge; //If the enemy is standing at an edge
	public float wallCheckRadius = 0.1f; //Radius in which a wall is searched
	public bool returnAtEdge; //Wheather or not the enemy returns if it is at an edge
	public float groundCheckRadius = 0.1f; //Radius in which a ground is searched
	public LayerMask whatIsWall; //Layer which defines the wall
	public LayerMask whatIsEnemy; //Layer which defines enemies
	public Transform wallCheck; //Point of the wall check
	public Transform groundCheck; //Point of the ground check
	
	private Rigidbody2D body; //Physical body of the enemy
	
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("isJumping", isJumping);
		//Check for a wall or an edge
		atWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		if(!atWall)
			atWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsEnemy);
		atEdge = !Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsWall);
		
		//If enemy is hitting a wall turn
		if (atWall) {
			moveRight = !moveRight;
		} else if (returnAtEdge && atEdge) //If enemy should return at an edge and he is at one return
			moveRight = !moveRight;
		
		if(waited >= waitToJump && jumpBack)
			moveRight = !moveRight;
		if(!atEdge){
			if(waited >= waitToJump){
				body.velocity += new Vector2(0, jumpVelocityY);
				waited = 0;
			} 
			else {
				isJumping = false;
				waited += Time.deltaTime;
			}
		}else
			isJumping = true;
		
		if (moveRight) {
			transform.localScale = new Vector3 (-1, 1, 1);
			if(isJumping)
				body.velocity = new Vector2 (jumpVelocityX, body.velocity.y );
			else
				body.velocity = new Vector2 (0, body.velocity.y );
		} else {
			transform.localScale = new Vector3 (1, 1, 1);
			if(isJumping)
				body.velocity = new Vector2 (-jumpVelocityX, body.velocity.y);
			else
				body.velocity = new Vector2 (0, body.velocity.y );
			
		}
	}

}
