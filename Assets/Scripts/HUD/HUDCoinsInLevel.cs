using UnityEngine;
using System.Collections;

public class HUDCoinsInLevel : MonoBehaviour {

	//Counter for the coins
	//index = 0 : Tens
	//index = 1 : Ones
	public GameObject [] bronzeCoinCounter = new GameObject[2];
	public GameObject [] silverCoinCounter = new GameObject[2];
	public GameObject [] goldCoinCounter = new GameObject[2];
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		bronzeCoinCounter[0].GetComponent<Animator>().SetInteger("number", Coin.BronzeCoins/10);
		bronzeCoinCounter[1].GetComponent<Animator>().SetInteger("number", Coin.BronzeCoins%10);
		
	}
}
