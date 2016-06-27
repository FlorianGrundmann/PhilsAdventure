using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Button : MonoBehaviour, Switchable {

	private Animator animator;
	
	public bool autoreleasing;
    public GameObject switchableObjects; //Must be set in the Unity-Editor
    
	private bool pressed;
    public bool Switched
    {
        get
        {
            return pressed;
        }

        set
        {
            pressed = value;
            animator.SetBool("pressed", value);
        }
    }

    private void Start () {
		animator = GetComponent<Animator> ();
	}
	
	
	void Update () {
		
	}
	
	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player" || collider.tag == "Box") {
			this.Switched = true;
            switchAllObjects();
        }
	}
    
    private void OnTriggerExit2D(Collider2D collider){
		if (autoreleasing && (collider.tag == "Player" || collider.tag == "Box")) {
			this.Switched = false;
            switchAllObjects();
        }
	}

    private void switchAllObjects()
    {
        foreach (Switchable switchableObj in switchableObjects.GetComponentsInChildren<SwitchableTile>())
        {
            switchableObj.Switched = !switchableObj.Switched;
        }
    }
}
