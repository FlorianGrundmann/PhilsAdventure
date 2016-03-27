using UnityEngine;
using System.Collections;

public class HUDEnemiesInLevel : MonoBehaviour {


	//Counter for active enemies
	//index = 0 : Tens
	//index = 1 : Ones
	public GameObject [] enemiesCounter = new GameObject[2];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enemiesCounter[0].GetComponent<Animator>().SetInteger("number", EnemyController.EnemiesActive/10);
		enemiesCounter[1].GetComponent<Animator>().SetInteger("number", EnemyController.EnemiesActive%10);
	}
}
