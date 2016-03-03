using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		float horizSpeed = speed * Input.GetAxis("Horizontal");
		float vertSpeed = speed * Input.GetAxis("Vertical");
		controller.Move(new Vector3(horizSpeed, vertSpeed, 0f));
	}
}
