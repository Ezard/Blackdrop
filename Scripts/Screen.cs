using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {
	bool drop = false;
	public GameObject projectorLight;

	// Use this for initialization
	void Start () {
		StartCoroutine(dropDown());
	
	}

	IEnumerator dropDown() {
		yield return new WaitForSeconds(3);
		drop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (drop) {
			if (transform.localPosition.y > 0.05) {
				transform.Translate (0, -10 * Time.deltaTime, 0);
			} else {
				if (!GetComponent<Test>().enabled) {
					GetComponent<Test>().enabled = true;
					StartCoroutine(activateLight());
				}
			}
		}
	}

	IEnumerator activateLight() {
		yield return new WaitForSeconds(0.5f);
		projectorLight.SetActive(true);
	}
}
