using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	//Camera properties
	private Transform cam; //Transform of the used camera
	private Vector3 previousCamPos; //Position of the camera in the last frame

	//Background properties
	public Transform[] backgrounds = new Transform[3]; //Background pictures; 0 = front, 1 = middle, 2 = sky background
	private Transform[] startPosition; //Start postions of the backgrounds
	public float smoothing = 0.5f; //How smooth the movement should be
	public float[] parallaxScales = {60, 70} ; //How much each background should move. Use the same index as in "backgrounds".


	void Start () {
		//Finds the camera used in the scene
		cam = FindObjectOfType<Camera> ().transform;
		//Initializes the camera position
		previousCamPos = cam.position;
		//Initialize the start postion
		startPosition = backgrounds;
	}

	void LateUpdate () {
		for (int i = 0; i < backgrounds.Length; i++) {

			//Place the sky where the camera is. This means, the sky doesn't move.
			if(i == backgrounds.Length -1){
				backgrounds[i].transform.position = new Vector3(cam.transform.position.x, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
				break;
			}

			//Calculate the position the background should move to
			float parallax = (cam.position.x - previousCamPos.x) * parallaxScales[i];
			Vector3 targetPos = new Vector3 (backgrounds[i].transform.position.x + parallax, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);

			//Move the background
			backgrounds[i].transform.position = Vector3.Lerp(backgrounds[i].transform.position, targetPos, smoothing * Time.deltaTime);


		}
		//Remember the camera positon
		previousCamPos = cam.position;
	}

	//Reset the background position to their start position
	public void ResetPosition(){
		for (int i = 0; i < backgrounds.Length - 1; i++){
			backgrounds[i].transform.position = startPosition[i].transform.position;
		}
		//Keep the sky at the camera's place
		backgrounds[backgrounds.Length].transform.position = new Vector3(cam.transform.position.x, backgrounds[backgrounds.Length].transform.position.y, backgrounds[backgrounds.Length].transform.position.z);
	}
}
