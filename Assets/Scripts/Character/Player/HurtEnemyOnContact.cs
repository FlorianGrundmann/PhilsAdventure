using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {

	public int damageToGive;

	public float bounceOnEnemy;

	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = transform.parent.GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyController>().Hit(damageToGive);
			body.velocity = new Vector2 (body.velocity.x, bounceOnEnemy);
		}
	}
}
