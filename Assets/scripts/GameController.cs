using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public TextMesh scoreText;
	private int score;

	public float totalTime;
	public GameObject timerBar;
	private float remainingTime;

	public GameObject foodSpawner;
	public GameObject orderGenerator;
	public GameObject Cat;
	public GameObject GameOverDisplay;

	void OnEnable() {
		OrderScript.CorrectlyEaten += addOneToScore;
		OrderScript.IncorrectlyEaten += subtractOneFromTime;
		OrderScript.OrderComplete += addFiveToTime;
	}

	void OnDisable() {
		OrderScript.CorrectlyEaten -= addOneToScore;
		OrderScript.IncorrectlyEaten -= subtractOneFromTime;
		OrderScript.OrderComplete -= addFiveToTime;
	}

	void Start() {
		score = 0;
		remainingTime = totalTime;
	}

	void Update() {
		scoreText.text = score + " pts";

		if (remainingTime > 0) {
			remainingTime = remainingTime - Time.deltaTime;
			float timerSize = (remainingTime / totalTime) * 0.5f;
			timerBar.transform.localScale = new Vector3 (timerSize, 0.1f, 1f);
		} else {
			GameOver ();
		}
	}

	void addOneToScore () {
		score += 1;
	}

	void subtractOneFromTime () {
		if (remainingTime > 1.0f)
			remainingTime -= 1.0f;
		else
			remainingTime = 0.0f;
	}

	void addFiveToTime () {
		if (remainingTime < (totalTime - 5.0f))
			remainingTime += 5.0f;
		else
			remainingTime = totalTime;
	}

	void GameOver() {
		GameOverDisplay.SetActive (true);
		timerBar.SetActive (false);
		Cat.SetActive(false);

		GameObject.Find ("Main Camera").GetComponent<AudioSource>().enabled = false;
		foodSpawner.GetComponent<spawnFood> ().enabled = false;
		orderGenerator.GetComponent<OrderScript> ().enabled = false;
		this.GetComponent<GameController> ().enabled = false;
	}
}
