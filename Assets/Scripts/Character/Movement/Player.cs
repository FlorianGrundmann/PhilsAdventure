using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (InputChecker.RightPressed)
            Debug.Log("Right button pressed");
        if (InputChecker.CancelPressed)
            Debug.Log("Cancel button pressed");
        if (InputChecker.JumpPressed)
            Debug.Log("Jump button pressed");
        if (InputChecker.LeftPressed)
            Debug.Log("Left button pressed");
        if (InputChecker.MagicPressed)
            Debug.Log("Magic button pressed");
    }
}
