using UnityEngine;
using System.Collections;

public class Speak : MonoBehaviour {
	
	string [][] speech;
	private int textPage;
	private int timesTalked;
	private SpeechBubble bubble;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		bubble = gameObject.GetComponent<SpeechBubble> ();

		speech = new string[2][];
		speech [0] = new string[3];
		speech [1] = new string[2];

		speech [0] [0] = "Hi Phil! How are you doing?";
		speech [0] [1] = "I have a tip for you: Hold the Magic Button and then press Jump to collect a box.";
		speech [0] [2] = "You can place the box somewhere else on the same way.";
		speech [1] [0] = "Having troubles? Press Magic + Jump to collect a box.";
		speech [1] [1] = "Press Magic + Jump again to place the collected box somwhere else.";

	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool ShowText(){

		bool stillSpeaking = Next ();
		if (!stillSpeaking) {
			switch(timesTalked){
			case 0:
				timesTalked = 1;
				break;
			case 1:
				break;
			}
		}
		return stillSpeaking;
	}

	private bool Next(){
		if (textPage < this.speech [timesTalked].Length) {
			bubble.enabled = true;
			bubble.CurrentText = speech [timesTalked] [textPage];
			textPage++;
		} else {
			bubble.enabled = false;
			textPage = 0;
		}
		return bubble.enabled;
	}
}
