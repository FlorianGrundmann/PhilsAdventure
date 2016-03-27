using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {


	//Health
	private HealthSystem healthSys;
	public AudioClip deathSound; //Sound when character dies

	//Start position
	private Vector3 startPosition;

	//Number of enemies active. An inactive enemy counts as dead.
	private static int enemiesActive;
	public static int EnemiesActive{
		get{return enemiesActive;}
	}

	// Use this for initialization
	void Start () {

		healthSys = GetComponent<HealthSystem> ();
		startPosition = transform.position;
		enemiesActive++;

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Kill(){
		AudioSource.PlayClipAtPoint (deathSound, transform.position);
		gameObject.SetActive(false);
		enemiesActive--;
	}

	public void Reset(){
		if (gameObject.activeSelf == false) {
			gameObject.SetActive (true);
		}
		transform.position = startPosition;
		healthSys.FillHealth ();
		enemiesActive++;
	}

	public void Hit(int dmg){
		healthSys.DoDamage (dmg);
		if (healthSys.CurrentLifePoints <= 0) {
			Kill();
		}
	}


}
