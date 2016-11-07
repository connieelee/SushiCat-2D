using UnityEngine;
using System.Collections;

public class checkEatenScript : MonoBehaviour {

	void OnEnable() {
		EatScript.OnEat += checkEaten;
	}

	void OnDisable() {
		EatScript.OnEat -= checkEaten;
	}

	void checkEaten (GameObject food) {
		print (food);
	}
}
