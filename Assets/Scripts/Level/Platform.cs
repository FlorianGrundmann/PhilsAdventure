using UnityEngine;
using System.Collections.Generic;

public class Platform : MonoBehaviour {

	//List of all platforms in the scene
	private static List<Platform> platformList = new List<Platform> ();
	public static List<Platform> AllPlatfroms
	{
		get {return platformList;}
	}

	private Vector3 lastPos; //last position of the platform
	private Vector3 currentPos; //current position of the platform

	private List<Collider2D> objOnPlatform;

	// Use this for initialization
	void Start () {
		//Initializes lastPos and currentPos
		//Sets current position of the gameobject as lastPos and currontPos for initializing
		lastPos = transform.position;
		currentPos = lastPos;

		//Initializes the list of colliders
		objOnPlatform = new List<Collider2D> ();

		//Adds itself to the list with all platfroms
		platformList.Add (this);
	}
	
	// Update is called once per frame
	void Update () {

		//Updates last and current position
		lastPos = currentPos;
		currentPos = transform.position;

		//If there is an object on the platform update it's position
		if (objOnPlatform.Count != 0) {
			foreach(Collider2D coll in objOnPlatform){
				coll.transform.position += currentPos - lastPos;
			}
		}
	}

	//If a collider is entering the hit box add it to objOnPlatform
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" || other.tag == "Enemy" || other.tag == "Box") {
			objOnPlatform.Add (other);
			Debug.Log ("Player on platform.");
		}
	}

	//if a collider leaves the platform, remove it from objOnPlatform
	void OnTriggerExit2D(Collider2D other){
		if(objOnPlatform.Contains(other))
			objOnPlatform.Remove(other);
		if (other.tag == "Player") {
			Debug.Log ("Player off platform.");
		}
	}

	//Clears the list objOnPlatform. You may need to use this, if the player dies on the platform.
	public void ClearList(){
		objOnPlatform.Clear ();
	}
}
