using UnityEngine;
using System.Collections;

public class InstantKill : MonoBehaviour {

	public bool killEnemies = true;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.GetComponent<PlayerController> ().Kill (true);
		}
		if (other.tag == "Enemy" && killEnemies) {
			other.GetComponent<EnemyController>().Kill();
		}
	
	}
}
