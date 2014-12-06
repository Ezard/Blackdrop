using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	public float nextOff = 0;
	public float nextOn = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextOff) {
			nextOn = Time.time + 0.005f;
			nextOff = float.MaxValue;
			gameObject.light.enabled = false;
		}
		if (Time.time > nextOn) {
			nextOff = Time.time + Random.value * 3;
			nextOn = float.MaxValue;
			gameObject.light.enabled = true;
		}
	}
}
