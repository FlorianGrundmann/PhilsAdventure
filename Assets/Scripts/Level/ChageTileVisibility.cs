using UnityEngine;
using System.Collections;

public class ChageTileVisibility : MonoBehaviour {

	public GameObject tilesParent;

	private Button button;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (ChangeableTile tile in tilesParent.GetComponentsInChildren<ChangeableTile>()) {
			tile.GetComponent<ChangeableTile> ().Visible = !button.Pressed;
		}
	}
}
