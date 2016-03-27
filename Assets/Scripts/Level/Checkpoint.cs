using UnityEngine;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {

	private LevelManager levelManager;
	private Animator animator;
	
	public bool activated;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("activated", activated);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			levelManager.SetCurrentCheckpoint(gameObject);
			activated = true;
		}
	}


}
