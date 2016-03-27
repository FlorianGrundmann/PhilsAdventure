using UnityEngine;
using System.Collections;

public class HUDBox : MonoBehaviour {

	public GameObject target; //Object whos health should be shown
	private SpriteRenderer boxUIRenderer;

	public bool boxCollected;

	// Use this for initialization
	void Start () {
		boxUIRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		boxCollected = target.GetComponent<PlayerItems> ().boxCollected;
		if (boxCollected)
			boxUIRenderer.enabled = true;
		else
			boxUIRenderer.enabled = false;
	}
}
