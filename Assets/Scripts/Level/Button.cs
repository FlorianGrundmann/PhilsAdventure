using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	private Animator animator;
	
	public bool release;
	
	private bool pressed;
	public bool Pressed{
		get{return pressed;}
		set{
			pressed = value;
			animator.SetBool("pressed", value);
		}
	}
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player" || collider.tag == "Box") {
			Pressed = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider){
		if (release && (collider.tag == "Player" || collider.tag == "Box")) {
			Pressed = false;
		}
	}
}
