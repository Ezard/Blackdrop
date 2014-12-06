using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	int jumpCount = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(-0.015f, 0, 0);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(0.015f, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) {
			rigidbody2D.velocity = new Vector2(0, 3);
			jumpCount++;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.position.y <= collider2D.bounds.min.y) {
			jumpCount = 0;
		}
	}
}
