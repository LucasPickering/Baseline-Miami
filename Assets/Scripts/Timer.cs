using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	private float timer = 0.0f;
	private GameObject[] opponentsAlive;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		opponentsAlive = GameObject.FindGameObjectsWithTag("Opponent");

		if (opponentsAlive.Length == 0) {
			Time.timeScale = 0;
		} else {
			timer += Time.deltaTime;
			gameObject.GetComponent<Text> ().text = timer.ToString ("f2");
		}
	}
}
