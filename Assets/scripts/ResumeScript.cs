using UnityEngine;
using System.Collections;

public class ResumeScript : MonoBehaviour {

	public GameObject PauseScreen;
	public GameObject PauseButton;
	public GameObject Cat;

	void OnMouseDown() {
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Play();
		PauseButton.SetActive (true);
		Cat.SetActive(true);
		PauseScreen.SetActive (false);
		GameObject.Find("Foods").GetComponent<spawnFood> ().enabled = true;
		Time.timeScale = 1.0f;
	}

}
