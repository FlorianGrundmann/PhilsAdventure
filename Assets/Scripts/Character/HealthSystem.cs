using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	private bool isDead;
	public bool Dead{
		get{return isDead;}
	}
	public bool invincible = false;
	public int maxLifePoints = 3; //Life points of the character
	private int currentLifePoints;
	public int CurrentLifePoints
	{
		get {return currentLifePoints;}
		set {
			if(value <= 0){
				currentLifePoints = 0;
				isDead = true;
			}else {
				currentLifePoints = value;
				isDead = false;
			}
		}
	}

	public bool respawnable; //True if the character is able to respawn
	//Transform respawnPoint; //Point where the character respawns


	// Use this for initialization
	void Start () {

		currentLifePoints = maxLifePoints;

	}

	public void DoDamage(int dmg){
		if(!invincible)
			CurrentLifePoints -= dmg;
	}

	public void FillHealth(){
		CurrentLifePoints = maxLifePoints;
	}

}
