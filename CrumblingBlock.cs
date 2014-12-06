using UnityEngine;
using System.Collections;

public class CrumblingBlock : MonoBehaviour {
	float crumbleTime = float.MaxValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > crumbleTime && crumbleTime != 0) {
			foreach(Transform child in transform) {
				child.rigidbody2D.gravityScale = Random.value * 2f;
				collider2D.enabled = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		crumbleTime = Time.time + 0.5f;
	}
}
