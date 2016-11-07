using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject PauseScreen;
	private GameObject Cat;

	void Start () {
		Cat = GameObject.Find ("Player");
	}

	void OnMouseDown() {
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Pause();
		gameObject.SetActive (false);
		Cat.SetActive (false);
		PauseScreen.SetActive (true);
		Time.timeScale = 0.0f;
	}

}
