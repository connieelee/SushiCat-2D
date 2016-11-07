using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour {

	void OnMouseDown() {
		SceneManager.LoadScene("main");
		Time.timeScale = 1.0f; // in case retry was activated via pause button
	}

}
