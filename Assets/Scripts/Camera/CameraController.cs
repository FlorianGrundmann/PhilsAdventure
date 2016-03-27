//Script by Florian Grundmann (IndieFlorianG)
//You can use and change this script as you like.
//Credit would be nice, but is not needed

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player; //The player controlled character game object

	private ITrackableByCamera playerComponent; 
	private Transform playerTransform;
	private Vector3 moveTo; //Target vector

	//################################
	//# Adjustable camera properties #
	//################################
	public bool follow = true; //Whether the camera should follow the player
	public float speedX = 12f; //Speed of the camera
	public float speedY = 4f;
	public float yTolerance = 1.3f; //Tolerance in y direction
	public float xTolerance = 0.3f; //Tolerance in x direction

	//########################################
	//# Properties for manuelly looking down #
	//########################################

	//Whether it should be possible to move the camera down by pressing a button
	public bool enableLookingDown = true;
	public float timeUntilMove = 1; //Time in seconds the down button needs to be pressed to move the camera
	public float lookingDownDistance = 3; //How far the camera should move, if looking down
	private float timeButtonPressed; //How long the button down was pressed


	private bool movingRight = true; //Whether the player is on the way right

	//###########################################
	//# Camera trigger area borders and offsets #
	//###########################################
	public GameObject bottomBorder; //Border the player can't come bellow
	public GameObject leftBorder; //Border the player can't cross if he is moving right
	public GameObject leftTolerance; //Only if the player crosses this border he is viewed as moving left
	public GameObject rightBorder; //Border the player can't cross if he is moving left
	public GameObject rightTolerance; //Only if the player crosses this border he is viewed as moving right
	private float yOffset; //Offset of the camera
	private float xOffset; //Offset of the camera

	//########################################################
	//# Properties for stopping the camera at the map border #
	//########################################################
	public bool stopAtMapBorder = true; //Whether the camera should stop at the map borders
	public int pixelPerUnit = 70;
	public GameObject leftMapBorder; //left border of the map
	public GameObject rightMapBorder; //riht border of the map
	public GameObject topMapBorder; //top border of the map
	public GameObject bottomMapBorder; //bottom border of the map
	private Camera cam;


	//The Position of the camera, which can be set manuelly, but may stop at the map border
	public Vector3 Position{
		get{ return transform.position; }
		set{
			if(stopAtMapBorder){
				//Stop at the map border
				float x = value.x;
				float y = value.y;

				Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0,0,cam.nearClipPlane));
				Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1,1,cam.nearClipPlane));
				Vector3 camResWorld = new Vector3(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y, bottomLeft.z);

				if(y + camResWorld.y/2 > topMapBorder.transform.position.y)
					y = topMapBorder.transform.position.y - camResWorld.y/2;
				else if (y - camResWorld.y/2 < bottomMapBorder.transform.position.y)
					y = bottomMapBorder.transform.position.y + camResWorld.y/2;
				if(x + camResWorld.x/2 > rightMapBorder.transform.position.x)
					x = rightMapBorder.transform.position.x - camResWorld.x/2;
				else if (x - camResWorld.x/2 < leftMapBorder.transform.position.x)
					x = leftMapBorder.transform.position.x + camResWorld.x/2;

				transform.position = new Vector3(x, y, value.z);
			}else
				transform.position = value;
		}
	}


	// Use this for initialization
	void Start () {
		cam = gameObject.GetComponent<Camera> ();
		playerTransform = player.transform;
		playerComponent = player.GetComponent<ITrackableByCamera> ();
		//Set the offsets
		yOffset = - bottomBorder.transform.localPosition.y;
		xOffset = leftBorder.transform.localPosition.x;

		//Set camera to start position
		if (follow) {
			moveTo = new Vector3 (playerTransform.position.x - xOffset, playerTransform.position.y + yOffset * 0.9f, transform.position.z);
			Position = moveTo;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			//Update x and y position
			UpdateXDirection();
			UpdateYDirection();
		}
	}

	//Updates the Y postion of the camera
	private void UpdateYDirection(){

		Position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, moveTo.y, transform.position.z), speedY * Time.deltaTime);
		
		//If the player is bellow the bottom border move instantly to him in y direction 
		if (playerTransform.position.y < bottomBorder.transform.position.y) {
			moveTo = new Vector3 (moveTo.x, playerTransform.position.y + yOffset, moveTo.z);
			Position = new Vector3 (transform.position.x, moveTo.y, transform.position.z);
		} 
		
		//If the player is standing on ground, set the target vector
		if (playerComponent.IsOnGround) {
			if (playerTransform.position.y - (moveTo.y - yOffset) > yTolerance) 
				moveTo = new Vector3 (moveTo.x, playerTransform.position.y + yOffset, moveTo.z);
		} 

		//Logic for manuelly looking down
		if(enableLookingDown){
			//If the key down is pressed save the current time
			if(Input.GetKey("down")){
				timeButtonPressed += Time.deltaTime;
			} //If the key is released reset the time
			if (Input.GetKeyUp("down")){
				if(timeButtonPressed >= timeUntilMove)
					moveTo.y += lookingDownDistance;
				timeButtonPressed = 0;
			}
			
			if(timeButtonPressed >= timeUntilMove){
				moveTo.y -= lookingDownDistance;
			}
		}
	}

	//Updates the x postion of the camera
	private void UpdateXDirection(){

		Position = Vector3.MoveTowards (transform.position, new Vector3 (moveTo.x, transform.position.y, transform.position.z), speedX * Time.deltaTime);

		if (movingRight) {
			//If player is far away from the left border (= If the direction changed shortly)
			//move to the player in x direction
			if (playerTransform.position.x > leftBorder.transform.position.x + xTolerance) {
				moveTo = new Vector3 (playerTransform.position.x - xOffset, moveTo.y, moveTo.z);
				
				//If the player just crossed the left border, move instantly to the player in x direction
			}else if (playerTransform.position.x > leftBorder.transform.position.x) {
				moveTo = new Vector3 (playerTransform.position.x - xOffset, moveTo.y, moveTo.z);
				Position = new Vector3 (moveTo.x, transform.position.y, transform.position.z);
			}
			//If the player crossed the left tolerance border, change the direction
			if (playerTransform.position.x < leftTolerance.transform.position.x) {
				movingRight = false;
			}
		} else {
			//If player is far away from the right border (= If the direction changed shortly)
			//move to the player in x direction
			if (playerTransform.position.x < rightBorder.transform.position.x - xTolerance) {
				moveTo = new Vector3 (playerTransform.position.x + xOffset, moveTo.y, moveTo.z);
				//If the player just crossed the right border, move instantly to the player in x direction
			} else if (playerTransform.position.x < rightBorder.transform.position.x) {
				moveTo = new Vector3 (playerTransform.position.x + xOffset, moveTo.y, moveTo.z);
				Position = new Vector3 (moveTo.x, transform.position.y, transform.position.z);
			}
			//If the player crossed the right tolerance border, change the direction
			if (playerTransform.position.x > rightTolerance.transform.position.x) {
				movingRight = true;
			}
		}
	}

	//Move the camera instantly to a target postion
	public void JumpTo(Vector3 targetPos){
		Position = targetPos + new Vector3 (xOffset, yOffset, transform.position.z);
	}

}
