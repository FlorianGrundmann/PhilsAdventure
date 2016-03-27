using UnityEngine;
using System.Collections;

public class BoxPointer : MonoBehaviour {

	public GameObject player;

	private GameObject currentBox; //Box currently in focus

	public bool pointerActivated; //Whether or not the pointer is active

	private bool boxActivated; //Whether or not a box is active
	private bool boxCollected; //Whether or not a box was collected
	private LayerMask boxLayer; //Layer of the boxes

	private int pointerPositionY;
	//The position of the pointer relativ to. It will only be set to -1, 0 or 1
	public float PointerPositionY 
	{
		get { return pointerPositionY;}
		set 
		{
			if (value == 0)
				pointerPositionY = 0;
			else if (value > 0)
				pointerPositionY = 1;
			else if (value < 0)
				pointerPositionY = -1;
		}
	}

	//Name of the particle system, which indicates the selected box
	public string nameOfBoxParticleSystem = "Box Magic";

	//Distance the box will be droped
	public float dropDistanceX = 0; //x = 0 means the box will be placed in front of the character
	public float dropDistanceY = 1; //y = 1 means the box will be placed a tile above the character
	public float grabDistance = 3; //Reach in which a box can be collected




	// Use this for initialization
	void Start () {
		//boxCollider = GetComponent<BoxCollider2D> ();
		boxLayer = LayerMask.GetMask ("Ground");
	}
	
	// Update is called once per frame
	void Update () {

		//Positions the pointer
		transform.localPosition = new Vector3(transform.localPosition.x , pointerPositionY);

		if (pointerActivated) { //If the pointer is activated
			if(!boxCollected){ //and no box was collected
				GameObject newBox = CheckForBox(); //Check if a box is in reach
				//If the currently activated box isn't in reach anymore
				if(newBox == null && boxActivated){ 
					DeactivateBox(currentBox); //deactivate the box
					currentBox = null;
				}
				//If a completly new box is in reach
				if(newBox != null && currentBox != newBox){
					if(boxActivated)
						//Deactivate the old box if necessary
						DeactivateBox(currentBox);
					//Activate the new box
					currentBox = newBox;
					ActivateBox(currentBox);
				}
			}
		} else { //If the pointer isn't activated
			if (boxActivated){ //deactivate the box if necessary
				DeactivateBox(currentBox);
				currentBox = null;
			}
		}

		player.GetComponent<PlayerItems> ().boxCollected = boxCollected;
	
	}

	//Deactivates the box
	//Attention: It doesn't deactivate the game object of the box itself, only of the particle
	//systems which indicates if an box is "active" or not
	private void DeactivateBox(GameObject box){
		box.transform.FindChild(nameOfBoxParticleSystem).gameObject.SetActive(false);
		boxActivated = false;
	}

	//Activates the box
	//Attention: It doesn't activate the game object of the box itself, only of the particle
	//systems which indicates if an box is "active" or not
	private void ActivateBox(GameObject box){
		box.transform.FindChild(nameOfBoxParticleSystem).gameObject.SetActive(true);
		boxActivated = true;
	}
	

	//Collect or drops a box
	public void UsePointer(){
		if (!boxCollected) {
			if (currentBox != null)
				CollectBox ();
		} else
			DropBox ();

	}

	//Collects the active box
	private void CollectBox(){
		DeactivateBox (currentBox);
		currentBox.SetActive (false);
		boxCollected = true;
	}

	//Drops a collected box
	private void DropBox(){
		currentBox.transform.position = new Vector3 (transform.position.x + Mathf.Sign(transform.parent.localScale.x) * dropDistanceX, transform.position.y + dropDistanceY);
		currentBox.SetActive (true);
		boxCollected = false;
		currentBox = null;
	}

	
	//Check with an ray cast if a box is in reach and returns the box
	private GameObject CheckForBox(){
		//Mathf.Sign(transform.parent.localScale.x) = -1 means the character is facing left
		// +1 means he is facing right.
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Mathf.Sign(transform.parent.localScale.x) * Vector2.right, grabDistance, boxLayer);
		if (hit.collider != null && hit.collider.tag == "Box")
			return hit.collider.gameObject; //If a box is found in reach, return the game object
		else //If there is no box in reach return null
			return null;
	}


}
