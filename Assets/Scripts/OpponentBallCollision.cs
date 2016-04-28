using UnityEngine;
using System.Collections;

public class OpponentBallCollision : MonoBehaviour {

	private GameObject[] ball;
	public Transform explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		ball = GameObject.FindGameObjectsWithTag("Ball");

		foreach (GameObject b in ball) {
			if (Vector3.Distance (transform.position, b.transform.position) < 1f) {
				Destroy(this.gameObject);
				Destroy(b.gameObject);
				Instantiate (explosion, this.transform.position, Quaternion.identity);
			}
		}

	}
}
