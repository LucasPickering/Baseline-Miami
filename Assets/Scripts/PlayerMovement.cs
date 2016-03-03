using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private CharacterController controller;

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void FixedUpdate () {
		float horizSpeed = speed * Input.GetAxis("Horizontal");
		float vertSpeed = speed * Input.GetAxis("Vertical");
		controller.Move(new Vector3(horizSpeed, vertSpeed, 0f));
	}
}
