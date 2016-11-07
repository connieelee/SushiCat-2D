using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {

	public float speed = 2f;

	private Vector2 direction = new Vector2(-1, 0);
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	void Update() {
		movement = new Vector2(speed * direction.x, speed * direction.y);
		if (gameObject.transform.position.x <= -4f) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate(){
		if (rigidbodyComponent == null)
			rigidbodyComponent = GetComponent<Rigidbody2D>();
		
		rigidbodyComponent.velocity = movement;
	}
}
