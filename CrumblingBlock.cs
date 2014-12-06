using UnityEngine;
using System.Collections;

public class CrumblingBlock : MonoBehaviour {
	float crumbleTime = float.MaxValue;

	// Use this for initialization
	void Start () {
	
	}

	float velocity = 0;
	// Update is called once per frame
	void Update () {
		if (Time.time > crumbleTime && crumbleTime != 0) {
			foreach (Transform child in transform) {
				child.rigidbody2D.gravityScale = Random.value;
				collider2D.enabled = false;
			}
			crumbleTime = 0;
		} else if (crumbleTime == 0) {
			foreach (Transform child in transform) {
				child.renderer.material.color = new Color(1, 1, 1, Mathf.SmoothDamp(child.renderer.material.color.a, 0, ref velocity, 0.5f));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		crumbleTime = Time.time + 0.5f;
	}
}
