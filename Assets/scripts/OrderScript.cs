using UnityEngine;
using System.Collections;

public class OrderScript : MonoBehaviour {

	public delegate void OrderAction ();
	public static event OrderAction CorrectlyEaten;
	public static event OrderAction IncorrectlyEaten;
	public static event OrderAction OrderComplete;

	public GameObject[] foods;
	public GameObject checkmark;

	GameObject[] Order = new GameObject[5];
	Vector3[] positions = {
		new Vector3 (-1.5f, 0.5f, 0),
		new Vector3 (0.3f, 0.5f, 0),
		new Vector3 (2.1f, 0.5f, 0),
		new Vector3 (-0.7f, -0.4f, 0),
		new Vector3 (1f, -0.4f, 0)
	};

	bool[] fulfilled = new bool[5];
	GameObject[] Checkmarks = new GameObject[5];

	bool firstOrder = true;

	void OnEnable() {
		EatScript.OnEat += checkEaten;
		StartScript.OnStart += createFirstOrder;
	}

	void OnDisable() {
		EatScript.OnEat -= checkEaten;
		StartScript.OnStart -= createFirstOrder;
	}
		
	void Update () {
		bool orderComplete = true;

		for (int i = 0; i < 5; i++) {
			if (!fulfilled[i]) orderComplete = false;
		}

		if (orderComplete) {
			
			if (OrderComplete != null) {
				OrderComplete ();
			}

			for (int i = 0; i < 5; i++) {
				Destroy (Order [i]);
				Destroy (Checkmarks [i]);
				fulfilled [i] = false;
			}

			createOrder ();
		}
	}

	void createOrder () {
		for (int i = 0; i < 5; i++) {
			Order[i] = Instantiate (foods [Random.Range (0, foods.Length)]) as GameObject;
			Order[i].transform.position = positions [i] + transform.position;
			Order[i].transform.parent = GameObject.Find ("Order").transform;
		}
	}

	void createFirstOrder () {
		createOrder ();
	}

	void checkEaten (GameObject food) {
		for (int i = 0; i < 5; i++) {
			if (!fulfilled[i] && food.name == Order[i].name) {

				if (CorrectlyEaten != null) {
					CorrectlyEaten ();
				}

				fulfilled [i] = true;
				Checkmarks [i] = Instantiate (checkmark) as GameObject;
				Checkmarks[i].transform.position = positions[i] + transform.position;
				Checkmarks[i].transform.parent = GameObject.Find ("Order").transform;

				return;
			}
		}

		if (IncorrectlyEaten != null) {
			IncorrectlyEaten ();
		}
	}

}
