using UnityEngine;
using System.Collections;

public class HUDCoins : MonoBehaviour {

	public GameObject target;
	public GameObject [] counter = new GameObject[2];

	private PlayerItems items;

	private int coins;

	// Use this for initialization
	void Start () {
		items = target.GetComponent<PlayerItems> ();
		counter[0].GetComponent<Animator>().SetInteger("number", 0);
		counter[1].GetComponent<Animator>().SetInteger("number", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (items.Coins != coins) {
			coins = items.Coins;
			counter[0].GetComponent<Animator>().SetInteger("number", coins/10);
			counter[1].GetComponent<Animator>().SetInteger("number", coins%10);
		}
	}
}
