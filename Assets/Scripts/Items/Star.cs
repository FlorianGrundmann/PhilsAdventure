using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	public AudioClip collectSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.GetComponent<PlayerItems>().stars++;
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		}
	}
}
