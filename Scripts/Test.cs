using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public GameObject line;

	// Use this for initialization
	void Start () {
		line = Resources.Load("Line") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	Vector3 start = Vector3.zero;
	RaycastHit hit;
	LineRenderer lr;

	void OnMouseDown() {
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
			start = hit.point;
			lr = (GameObject.Instantiate (line, new Vector3 (), new Quaternion ()) as GameObject).GetComponent<LineRenderer> ();
			lr.SetPosition (0, new Vector3(start.x, start.y, 0));
		}
	}

	void OnMouseDrag() {
		if (start != Vector3.zero && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
			if (Vector3.Distance(start, hit.point) > 1) {
				hit.point = start + (hit.point - start).normalized;
			}
			lr.SetPosition (1, new Vector3(hit.point.x, hit.point.y, 0));
		}
	}

	void OnMouseUp() {
		if (start != Vector3.zero) {
			lr.SetPosition (1, new Vector3(hit.point.x, hit.point.y, 0));
			start = Vector3.zero;
		}
	}

	void OnMouseExit() {
		OnMouseUp();
	}
}
