using UnityEngine;
using System.Collections;
using System;

public class SwitchableTile : MonoBehaviour, Switchable {

	private BoxCollider2D coll;

	private Animator animator;

	private bool visible;
    public bool Switched
    {
        get
        {
            return visible;
        }

        set
        {
            animator.SetBool("full", value);
            visible = value;
            coll.enabled = value;
        }
    }

    // Use this for initialization
    void Start () {
		animator = GetComponent<Animator> ();
		coll = GetComponent<BoxCollider2D> (); 
	}
}
