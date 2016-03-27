using UnityEngine;
using System.Collections;

public class FlyingMovement : MonoBehaviour {

	public float velocity;
	public bool changeLookDirection;

	private Vector2 flyDestination;
	private Vector2 currentFlyDestination;
	public GameObject flyDestinationPoint;
	private bool flyingBack;
	private Vector2 startPosition;
	private Rigidbody2D body;

	//Positions to check in which direction the object should look
	private Vector3 lastPos;
	private Vector3 currentPos;
	private bool moveRight;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		flyDestination = flyDestinationPoint.transform.position;
		currentFlyDestination = flyDestination;

		currentPos = transform.position;
		lastPos = currentPos;
	}
	
	// Update is called once per frame
	void Update () {

		lastPos = currentPos;
		currentPos = transform.position;

		if (currentPos.x - lastPos.x > 0)
			moveRight = true;
		else
			moveRight = false;

		if (moveRight && changeLookDirection) {
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if(changeLookDirection)
				transform.localScale = new Vector3 (1, 1, 1);
		

		transform.position = Vector2.MoveTowards (transform.position, currentFlyDestination, velocity * Time.deltaTime);

		if (transform.position.x == currentFlyDestination.x && transform.position.y == currentFlyDestination.y) {
			if(flyingBack)
				currentFlyDestination = flyDestination;
			else
				currentFlyDestination = startPosition;

			flyingBack = !flyingBack;
		}
	}
}
