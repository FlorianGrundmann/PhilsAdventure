using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//Current active Checkpoint
	public static GameObject currentCheckpoint;
	//Level theme song
	private AudioSource levelMusic;

	//Text which will be shown, if the player dies
	public GameObject toBadText;

	//Sum of all coins in the level
	public static int Coins{
		get{return Coin.Coins;}
	}
	public static int CoinsLeft{
		get{return Coin.CoinsLeft;}
	}
	//Current number of bronze coins in the level
	public static int BronzeCoins{
		get{return Coin.BronzeCoins;}
	}
	//Current number of silver coins in the level
	public static int SilverCoins{
		get{return Coin.SilverCoins;}
	}
	//Current number of gold coins in the level
	public static int GoldCoins{
		get{return Coin.GoldCoins;}
	}
	
	//How many times the player died in the level
	private static int timesDied = 0;
	public static int Died{
		get{return timesDied;}
	}

	public GameObject doubleJumpEnabledText;

	private PlayerController player;

	private Parallax paraBackground;

	// Use this for initialization
	void Start () {
		paraBackground = FindObjectOfType<Parallax> ();
		player = FindObjectOfType<PlayerController> ();
		levelMusic = GetComponent<AudioSource> ();

		levelMusic.loop = true;
		PlayMusic ();
	}
	

	public void PauseMusic(){
		levelMusic.Pause ();
	}

	public void PlayMusic(){
		levelMusic.Play ();
	}
	

	public void SetCurrentCheckpoint(GameObject checkpoint){
		if(currentCheckpoint != null)
			currentCheckpoint.GetComponent<Checkpoint> ().activated = false;
		currentCheckpoint = checkpoint;
	}

	public Vector3 GetRespawnPointPosition(GameObject obj){
		if (obj.tag == "Player") 
			return currentCheckpoint.transform.position;
		else {
			Debug.LogWarning("Wrong tag of game object. Respawn point will be set to (0,0,0).");
			return new Vector3 (0, 0, 0);
		}
	}

	public void ToBadTextActive(bool active){
		toBadText.gameObject.SetActive (active);
	}

	public void EnableDoubleJump(){
		StartCoroutine (ShowDoubleJumpText ());
	}

	private IEnumerator ShowDoubleJumpText(){
		player.inputEnabled = false;
		doubleJumpEnabledText.SetActive (true);
		AudioSource.PlayClipAtPoint (doubleJumpEnabledText.GetComponent<AudioSource>().clip, doubleJumpEnabledText.transform.position);
		yield return new WaitForSeconds(2);
		doubleJumpEnabledText.SetActive (false);
		player.enableDoubleJump = true;
		player.inputEnabled = true;
	}

	//Resets all enemies to start location and respawns them
	public void ResetEnemies(){
		foreach (EnemyController enemy in GetComponentsInChildren<EnemyController>(true)) {
			enemy.Reset();
		}
	}

	private void ClearAllPlatformLists(){
		foreach (Platform platform in Platform.AllPlatfroms) {
			platform.ClearList();
		}
	}

	private void ResetBackground(){
		paraBackground.ResetPosition ();
	}

	public void PlayerDeathReset(){
		ResetEnemies ();
		ClearAllPlatformLists ();
	}

}
