using UnityEngine;

public class Player : MonoBehaviour {

    public Transform groundCheckTransform;
    public float jumpHeight = 15f;
    public LayerMask groundLayer;
    private IMove jumping;
    private IDirectionalMove walk;
    public float movingSpeed = 5f;

	// Use this for initialization
	void Start () {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        //Vector2 groundCheckPos = new Vector2(groundCheckTransform.position.x, groundCheckTransform.position.y);
        GroundChecker groundCheck = new GroundChecker(groundCheckTransform, 0.1f, groundLayer);
        jumping = new DoubleJumping(body, groundCheck, jumpHeight);
        walk = new Movement(body, movingSpeed, new Vector3(1, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (InputChecker.RightPressed)
        {
            walk.Move(new Vector3(1, 0, 0));
            Debug.Log("Right button pressed");
        }
        if (InputChecker.CancelPressed)
            Debug.Log("Cancel button pressed");
        if (InputChecker.JumpPressed)
        {
            Debug.Log("Jump button pressed");
            jumping.Move();
        }
        if (InputChecker.LeftPressed)
            Debug.Log("Left button pressed");
        if (InputChecker.MagicPressed)
            Debug.Log("Magic button pressed");

        
    }
}
