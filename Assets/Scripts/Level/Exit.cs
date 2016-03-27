using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	
	public string nextLevel;

	private Animator animator;
	
	public bool activated;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("activated", activated);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			activated = true;
			FindObjectOfType<FinishScreenManager> ().LevelCompleted (1, 1, nextLevel);
		}
	}
}
