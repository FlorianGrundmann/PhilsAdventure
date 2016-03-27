using UnityEngine;
using System.Collections;

public class HUDHealth : MonoBehaviour {

	private int maxHealth;
	private int currentHealth;

	public GameObject target; //Object whos health should be shown
	private HealthSystem healthSystem;

	public GameObject [] hearts = new GameObject[10];

	//public int heartDistance = 60; //Distance between two hearts in pixels

	// Use this for initialization
	void Start () {
		healthSystem = target.GetComponent<HealthSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (maxHealth != healthSystem.maxLifePoints) {
			maxHealth = healthSystem.maxLifePoints;
			for(int i = 0; i < maxHealth; i++){
				hearts[i].SetActive(true);
			}
		}
		if (currentHealth != healthSystem.CurrentLifePoints) {
			currentHealth = healthSystem.CurrentLifePoints;
			for(int i = 0; i < currentHealth; i++)
				hearts[i].GetComponent<Animator>().SetBool("empty", false);
			for(int i = currentHealth; i < maxHealth; i++)
				hearts[i].GetComponent<Animator>().SetBool("empty", true);
		}
	
	}
}
