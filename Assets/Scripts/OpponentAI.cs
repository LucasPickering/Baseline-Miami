using UnityEngine;
using System.Collections;

public class OpponentAI : MonoBehaviour {

	public GameObject target;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z = -1;
		transform.position = pos;

		Vector3 targetHeading = target.transform.position - transform.position;
		Vector3 targetDirection = targetHeading.normalized;

		// Move towards the player
		if (Vector3.Distance(transform.position,target.transform.position) < 3f){//move if distance from target is greater than 1
			transform.position += targetDirection * speed * Time.deltaTime;
		}
	}
}
