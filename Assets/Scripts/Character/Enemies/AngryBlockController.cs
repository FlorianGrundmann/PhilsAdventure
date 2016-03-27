using UnityEngine;
using System.Collections;

public class AngryBlockController : MonoBehaviour {

	public GameObject groundCheck;

	private bool onGround;
	public float waitOnGround = 1.5f;
	public float waitInAir = 3f;
	private float timeWaited;

	private Vector3 startPosition;
	private Rigidbody2D body;
	private bool returning;
	private float gravityScale;
	public float returnSpeed;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
		startPosition = transform.position;
		gravityScale = body.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		onGround = groundCheck.GetComponent<GroundCheck> ().OnGround;

		if (transform.position.y >= startPosition.y) {
			transform.position = new Vector2(transform.position.x, startPosition.y);
			returning = false;
			if(timeWaited >= waitOnGround){
				timeWaited = 0;
				body.gravityScale = gravityScale;
			}
			timeWaited += Time.deltaTime;
		}

		if (returning) {
			body.velocity = new Vector2(0, returnSpeed);
		}

		if (onGround && !returning) {
			body.gravityScale = 0;
			if(timeWaited >= waitOnGround){
				timeWaited = 0;
				returning = true;
			}
			timeWaited += Time.deltaTime;
		}
	}

}
