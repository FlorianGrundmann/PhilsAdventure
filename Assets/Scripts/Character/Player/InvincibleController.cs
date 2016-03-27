using UnityEngine;
using System.Collections;

public class InvincibleController : MonoBehaviour {


	public bool invincible; //If true, character doesn't get damage

	public float invincibleTime = 0.2f;
	public float timeBetweenBlinks;
	private float timeAlreadyInvincible;
	private SpriteRenderer myRenderer;
	private Shader shaderGUItext;
	private Shader shaderSpritesDefault;

	// Use this for initialization
	void Start () {
		myRenderer = gameObject.GetComponent<SpriteRenderer>();
		shaderGUItext = Shader.Find("GUI/Text Shader");
		shaderSpritesDefault = Shader.Find("Sprites/Default");
	}
	
	// Update is called once per frame
	void Update () {
		if (invincible) {
			timeAlreadyInvincible += Time.deltaTime;
			if(timeAlreadyInvincible >= invincibleTime){
				StopCoroutine("Blink");
				ReturnColor();
				timeAlreadyInvincible = 0;
				invincible = false;
			}
		}
	}

	public void MakeInvincible(){
		invincible = true;
		StartCoroutine ("Blink");
	}
	
	IEnumerator Blink(){
		while(true){
			MakeWhite();
			yield return new WaitForSeconds(timeBetweenBlinks);
			ReturnColor();
			yield return new WaitForSeconds(timeBetweenBlinks);
		}
	}
	
	private void MakeWhite(){
		myRenderer.material.shader = shaderGUItext;
		myRenderer.color = Color.white;
	}
	
	private void ReturnColor(){
		myRenderer.material.shader = shaderSpritesDefault;
		myRenderer.color = Color.white;
	}
}
