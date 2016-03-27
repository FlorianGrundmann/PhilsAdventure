using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	private Canvas pauseMenuCanvas;

	// Use this for initialization
	void Start () {
		pauseMenuCanvas = gameObject.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Cancel")) {
			isPaused = !isPaused;

			if (isPaused) {
				Pause ();
			} else {
				Unpause ();
			}
		}
	
	}

	void Pause(){
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players){
			player.GetComponent<SpriteRenderer>().enabled = false;
		}
		pauseMenuCanvas.enabled = true;
		foreach (SpriteRenderer renderer in gameObject.GetComponentsInChildren<SpriteRenderer>()) {
			renderer.enabled = true;
		}
		Time.timeScale = 0f;
	}

	void Unpause(){
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players){
			player.GetComponent<SpriteRenderer>().enabled = true;
		}
		pauseMenuCanvas.enabled = false;
		foreach (SpriteRenderer renderer in gameObject.GetComponentsInChildren<SpriteRenderer>()) {
			renderer.enabled = false;
		}
		Time.timeScale = 1f;
	}
}
