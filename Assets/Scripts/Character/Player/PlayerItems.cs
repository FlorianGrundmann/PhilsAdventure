using UnityEngine;
using System.Collections;

public class PlayerItems : MonoBehaviour {

	//Number of stars the player collected
	public int stars;

	public bool boxCollected;

	//Number of coins the player collected
	private int coins;
	public int Coins {
		get { return coins; }
		set { 
			coins = value;
			if(coins >= 100) {
				coins = 0;
				Lifes += 1;
			}
		}
	}

	private int lifes;
	public int Lifes {
		get { return lifes; }
		set { lifes = value; }
	}


	
}
