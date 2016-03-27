using UnityEngine;
using System.Collections;

public class PlayerSoundController : MonoBehaviour {

	public AudioClip deathSound;

	public void PlayDeathSound(){
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
	}
}
