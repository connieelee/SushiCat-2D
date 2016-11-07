using UnityEngine;
using System.Collections;

public class EatScript : MonoBehaviour {

	public delegate void FoodAction (GameObject food);
	public static event FoodAction OnEat;

	public AudioClip blopSound;
	private AudioSource source;

	void Start () {
		gameObject.AddComponent<AudioSource>();
		gameObject.GetComponent<AudioSource>().clip = blopSound;
	}

	void OnMouseDown () {
		if (OnEat != null)
			OnEat (gameObject);

		gameObject.GetComponent<AudioSource>().Play();
		Destroy (gameObject, blopSound.length);
	}

}