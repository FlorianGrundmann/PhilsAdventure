using UnityEngine;

public class Player : MonoBehaviour {

    private InputManager input;

	// Use this for initialization
	void Start () {
        input = new InputManager();
	}
	
	// Update is called once per frame
	void Update () {
        input.Update();
        if (input.RightPressed)
            Debug.Log("Right button pressed");
	}
}
