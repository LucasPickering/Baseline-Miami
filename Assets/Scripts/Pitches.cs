using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pitches : MonoBehaviour {

	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			count = count + 1;
		}

		gameObject.GetComponent<Text> ().text = "Pitches: " + count.ToString ();
	}
}
