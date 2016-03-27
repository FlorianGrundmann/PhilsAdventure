using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	private enum CoinType {bronze, silver, gold};
	public int coinType;

	//Sum of all coins in the level
	private static int numberCoins;
	public static int Coins{
		get{return numberCoins;}
	}
	//Sum of all coins left in the level
	public static int CoinsLeft{
		get{return (numberBronzeCoins*BronzeCoinValue + numberSilverCoins*SilverCoinValue + numberGoldCoins*GoldCoinValue);}
	}
	//Current number of bronze coins in the level
	private static int numberBronzeCoins;
	public static int BronzeCoins{
		get{return numberBronzeCoins;}
	}
	//Current number of silver coins in the level
	private static int numberSilverCoins;
	public static int SilverCoins{
		get{return numberSilverCoins;}
	}
	//Current number of gold coins in the level
	private static int numberGoldCoins;
	public static int GoldCoins{
		get{return numberGoldCoins;}
	}

	public AudioClip collectSound;

	//Value of the different coin types
	public static int BronzeCoinValue{
		get{ return 1;}
	}
	public static int SilverCoinValue{
		get{ return 5; }
	}
	public static int GoldCoinValue{
		get{ return 5; }
	}

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Animator> ().SetInteger ("coinType", coinType);
		switch (coinType){
		case (int)CoinType.bronze:
			numberBronzeCoins++;
			break;
		case (int)CoinType.silver:
			numberSilverCoins++;
			break;
		case (int)CoinType.gold:
			numberGoldCoins++;
			break;
		}
		//Count total number of coins
		numberCoins = BronzeCoins * BronzeCoinValue + SilverCoins * SilverCoinValue + GoldCoins * GoldCoinValue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			switch (coinType){
			case (int)CoinType.bronze:
				other.GetComponent<PlayerItems>().Coins += BronzeCoinValue;
				numberBronzeCoins--;
				break;
			case (int)CoinType.silver:
				other.GetComponent<PlayerItems>().Coins += SilverCoinValue;
				numberSilverCoins--;
				break;
			case (int)CoinType.gold:
				other.GetComponent<PlayerItems>().Coins += GoldCoinValue;
				numberGoldCoins--;
				break;
			}
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		}
	}
}
