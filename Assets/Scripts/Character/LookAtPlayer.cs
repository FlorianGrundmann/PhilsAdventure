using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((gameObject.transform.position.x > player.transform.position.x) && transform.localScale.x > 0)
			transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
		else if ((gameObject.transform.position.x < player.transform.position.x) && transform.localScale.x < 0)
			transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
	}
}
