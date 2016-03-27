using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cursor : MonoBehaviour {
	
	public List<GameObject> positions;
	public int startPosition = 0;
	public string levelToLoad;

	private int currentIndex;
	private int axisRaw = 0;

	// Use this for initialization
	void Start () {
		currentIndex = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")||Input.GetKeyDown(KeyCode.Return)) {
			switch(currentIndex){
			case 0:
				Application.LoadLevel (levelToLoad);
				break;
			case 1:
				Application.Quit();
				break;
			}
		}

		int newRaw = (int) Input.GetAxisRaw ("Vertical");
		if (newRaw != axisRaw) {
			axisRaw = newRaw;
			currentIndex -= axisRaw;
		}


		if (currentIndex >= positions.Count)
			currentIndex = 0;
		if (currentIndex < 0)
			currentIndex = positions.Count - 1;

		gameObject.transform.position = new Vector2( gameObject.transform.position.x, positions [currentIndex].transform.position.y);
	}
}
