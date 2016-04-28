using UnityEngine;
using System.Collections;

public class OpponentBallCollision : MonoBehaviour {

	private GameObject[] ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		ball = GameObject.FindGameObjectsWithTag("Ball");

		foreach (GameObject b in ball) {
			if (Vector3.Distance (transform.position, b.transform.position) < 1f) {
				gameObject.active = false;
				b.gameObject.active = false;
			}
		}

	}
	/*
	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.name == "Ball(Clone)") {
			gameObject.active = false;
		}
	}
	*/
}
