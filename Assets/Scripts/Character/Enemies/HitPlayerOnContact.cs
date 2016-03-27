using UnityEngine;
using System.Collections;

public class HitPlayerOnContact : MonoBehaviour {

	public int damage = 1;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.GetComponent<PlayerController>().Hit(damage, other.transform.position.x < gameObject.transform.position.x);
		}
	}
}
