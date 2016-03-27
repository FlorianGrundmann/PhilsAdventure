using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, ITrackableByCamera {

	private Rigidbody2D body; //the physical body of game object
	private LevelManager levelManager;
	private HealthSystem healthSys;


	//Movement
	public bool inputEnabled = true; //If false, the character can't move
	public float moveSpeed = 5f; //absolut speed value
	private float moveVelocity = 0f; //the actual speed of the character
	private Vector2 currentVelocityVector;

	//Jumping
	//public AudioClip jumpingSound;
	public float jumpHeight = 15f;
	public Transform groundCheck;
	public LayerMask ground;
	private float groundCheckRadius = 0.1f;
	private bool grounded;
	public bool IsOnGround{
		get { return grounded; }
	}
	public bool enableDoubleJump = true;
	private bool doubleJumped = false;

	//Animations
	private Animator animator;
	private bool isWalking;
	private bool isJumping;
	private bool isCrouching;
	private bool isFacingRight = true;
	public bool IsFacingRight{
		get {return isFacingRight;}
	}
	//private bool isHurt;

	//Knockback
	public bool knockBackEnabled;
	public float knockBackLength = 0.5f;
	public float knockBackVelocity = 1f;
	private float knockBackCount;
	private bool knockFromRight;

	//Invincibility
	private InvincibleController inviController;
	public bool invincibleOnHit = true;

	//Magic
	//private bool magicActivated;
	private BoxPointer boxPointer;
	public GameObject boxPointerObject;

	//Death
	public float waitAfterDeath = 1f;
	private float deathTimeCountdown;
	private bool stayOnPosition;

	//Sounds
	private PlayerSoundController soundController;

	//Talking
	public LayerMask npcLayer;
	public bool talkingAllowed = true;

	// Use this for initialization
	void Start () {
		soundController = GetComponent<PlayerSoundController> ();

		healthSys = GetComponent<HealthSystem> ();
		levelManager = FindObjectOfType<LevelManager> ();

		inviController = GetComponent<InvincibleController> ();

		body = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		boxPointer = boxPointerObject.GetComponent<BoxPointer> ();
	}
	

	// Update is called once per frame
	void Update () {


		CheckIfOnGround ();
		if(inputEnabled)
			ExecuteInputs (); //If there are no inputs, stop the character, else move
		SetAnimatorValues ();
		ExecuteKnockBack ();
		if (stayOnPosition)
			body.velocity = Vector2.zero;
 
	
	}

	//##################
	//# Public Methods #
	//##################

	public void Respawn(){
		Vector3 targetPos = levelManager.GetRespawnPointPosition (gameObject);
		gameObject.transform.position = targetPos;
		FindObjectOfType<CameraController> ().JumpTo (targetPos);
		levelManager.PlayerDeathReset();
	}

	public void KnockBack(bool fromRight){
		if (knockBackEnabled) {
			knockBackCount = knockBackLength;
			this.knockFromRight = fromRight;
			animator.SetBool("isHurt", true);
			inputEnabled = false;
		}
	}

	public void Hit(int dmg, bool fromRight){
		if(!inviController.invincible){
			healthSys.DoDamage (dmg);
		}
		if (healthSys.CurrentLifePoints <= 0) {
			Kill(fromRight);
		} else {
			if (invincibleOnHit)
				inviController.MakeInvincible();
			KnockBack (fromRight);
		}

	}

	public void Kill(bool fromRight){
		StartCoroutine (ExecuteDeath(fromRight));
	}

	private IEnumerator ExecuteDeath(bool fromRight){
		levelManager.ToBadTextActive (true);
		stayOnPosition = true;
		healthSys.CurrentLifePoints = 0;
		levelManager.PauseMusic ();
		soundController.PlayDeathSound ();
		body.velocity = Vector2.zero;
		inputEnabled = false;
		animator.SetBool("isHurt", true);
		FindObjectOfType<CameraController> ().follow = false;
		body.isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponentInChildren<HurtEnemyOnContact>().enabled = false;
		yield return new WaitForSeconds(2);
		stayOnPosition = false;
		body.isKinematic = false;
		if (fromRight)
			body.velocity = new Vector2 (-knockBackVelocity, knockBackVelocity);
		else
			body.velocity = new Vector2 (knockBackVelocity, knockBackVelocity);
		yield return new WaitForSeconds (2);
		body.velocity = Vector2.zero;
		inputEnabled = true;
		animator.SetBool("isHurt", false);
		GetComponentInChildren<HurtEnemyOnContact>().enabled = true;
		FindObjectOfType<CameraController> ().follow = true;
		levelManager.ToBadTextActive (false);
		Respawn ();
		GetComponent<BoxCollider2D> ().enabled = true;
		healthSys.FillHealth ();
		levelManager.PlayMusic ();
	}

	//###################
	//# Private Methods #
	//###################

	private void ExecuteDeathAnimation(){
		deathTimeCountdown -= Time.deltaTime;
		if (deathTimeCountdown <= 0) {
			Respawn();
		}
	}

	private void ExecuteKnockBack(){
		if (knockBackCount > 0) {
			if (knockFromRight)
				body.velocity = new Vector2 (-knockBackVelocity, knockBackVelocity);
			else
				body.velocity = new Vector2 (knockBackVelocity, knockBackVelocity);
			currentVelocityVector = body.velocity;
			knockBackCount -= Time.deltaTime;
			if(knockBackCount <= 0 && healthSys.CurrentLifePoints > 0){
 				inputEnabled = true;
				animator.SetBool("isHurt",false);
			}
		}
	}

	private void SetAnimatorValues (){
		if (isFacingRight)
			transform.localScale = new Vector3 (1, 1, 1);
		else
			transform.localScale = new Vector3 (-1, 1, 1);
		if (!stayOnPosition) {
			animator.SetBool ("isWalking", isWalking);
			animator.SetBool ("isJumping", isJumping);
			animator.SetBool ("isCrouching", isCrouching);
		}
	}

	//Checks if player is standing on ground
	private void CheckIfOnGround(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, ground);
		isJumping = !grounded;
	}


	private void ExecuteInputs(){
		//isCrouching = false;
		ChangeVelocity (); //includes stopping, if there is no input

		if (Input.GetButton ("Magic")) {
			boxPointer.pointerActivated = true;
			boxPointer.PointerPositionY = Input.GetAxisRaw ("Vertical");
			if (Input.GetButtonDown ("Jump")){
				DoMagic();
			}

		} else {
			if(boxPointer.pointerActivated){
				boxPointer.pointerActivated = false;

			}
			if (Input.GetButtonDown ("Jump")) {
				Collider2D npc = Physics2D.OverlapCircle(transform.position, 1, npcLayer);
				if(npc != null){
					Speak speech = npc.GetComponent<Speak>();
					if (speech != null){
						bool speaking = speech.ShowText();
						stayOnPosition = speaking;
					} else Jump();
				}
				else {
					Jump();
				}
			} 
			else if((Input.GetAxisRaw ("Vertical") == -1) && (Input.GetAxisRaw ("Horizontal") == 0)){
				isCrouching = true;
			} else isCrouching = false;
		}
	}

	//Handles the player movement
	private void ChangeVelocity(){
		moveVelocity = Input.GetAxisRaw ("Horizontal") * moveSpeed;
		if (moveVelocity != 0) {
			isWalking = true;
			if (moveVelocity > 0)
				isFacingRight = true;
			else
				isFacingRight = false;
		} else {
			isWalking = false;
		}
		body.velocity = new Vector2 (moveVelocity, body.velocity.y);
	}

	//Handles the player jumping
	private void Jump(){
		if (grounded) {
			body.velocity = new Vector2 (body.velocity.x, jumpHeight);
			doubleJumped = false;
			isJumping = true;
		} else if (!doubleJumped && enableDoubleJump) {
			body.velocity = new Vector2 (body.velocity.x, jumpHeight*2/3);
			doubleJumped = true;
		}
	}

	private void DoMagic(){
		boxPointer.UsePointer ();
	}




}
