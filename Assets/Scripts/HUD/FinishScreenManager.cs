using UnityEngine;
using System.Collections;

public class FinishScreenManager : MonoBehaviour {

	public float waitTime = 2f;
	private float elapsedTime = 0f;
	private Canvas finishScreenCanvas;
	private string levelToLoad;

	private AudioSource levelFinishedMusic;
		
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		levelFinishedMusic = GetComponent<AudioSource> ();
		finishScreenCanvas = gameObject.GetComponent<Canvas> ();
	}

	public void Update(){
		if (finishScreenCanvas.enabled) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= waitTime && Input.anyKey) {
				elapsedTime = 0;
				StartNextLevel ();
			}
		}
	}


	public void LevelCompleted(int coins, int stars, string nextLevel){
		levelToLoad = nextLevel;
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players){
			player.gameObject.SetActive(false);
		}
		finishScreenCanvas.enabled = true;
		levelManager.PauseMusic ();
		levelFinishedMusic.Play ();
	}

	private void StartNextLevel(){
		Application.LoadLevel (levelToLoad);
	}

}
