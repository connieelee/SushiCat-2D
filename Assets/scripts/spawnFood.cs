using UnityEngine;
using System.Collections;

public class spawnFood : MonoBehaviour {

	public GameObject[] foods;
	public float spawnRate = 1.0f;
	private float nextSpawn = 0.0f;

	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			GameObject spawnedFood = Instantiate(
				foods[Random.Range (0, foods.Length)],
				transform.position,
				transform.rotation)
				as GameObject;
			spawnedFood.GetComponent<moveScript>().enabled = true;
			spawnedFood.transform.parent = GameObject.Find("Foods").transform;
		}
	}
}