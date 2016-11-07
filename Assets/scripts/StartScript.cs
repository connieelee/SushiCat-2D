using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	public delegate void StartEvent ();
	public static event StartEvent OnStart;

	void Start () {
		Time.timeScale = 0.0f;
	}
	
	void OnMouseDown () {
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().enabled = true;
		GameObject.Find ("Game Controller").GetComponent<AudioSource> ().enabled = true;

		Time.timeScale = 1.0f;
		Destroy (gameObject);

		if (OnStart != null) {
			OnStart ();
		}
	}
}
