using UnityEngine;
using System.Collections;

public class PickRandomCat : MonoBehaviour {

	public GameObject[] cats;

	void OnEnable() {
		StartScript.OnStart += pickCat;
	}

	void OnDisable() {
		StartScript.OnStart -= pickCat;
	}

	void pickCat () {
		GameObject ActiveCat = Instantiate (cats [Random.Range (0, cats.Length)]) as GameObject;
		ActiveCat.transform.parent = GameObject.Find ("Player").transform;
	}

}
