using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private CharacterController controller;
	private Transform thisTransform;

	void Start () {
		controller = GetComponent<CharacterController>();
		thisTransform = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		float horizSpeed = speed * Input.GetAxis("Horizontal");
		float vertSpeed = speed * Input.GetAxis("Vertical");

		if (findRadius () < 9) {
			controller.Move (new Vector3 (horizSpeed, vertSpeed, 0f));
		} else {
			if (thisTransform.position.x > 0 && thisTransform.position.y > 0) {
				controller.Move (new Vector3 (-0.2f, -0.2f, 0f));
			} else if (thisTransform.position.x < 0) {
				controller.Move (new Vector3 (0.2f, 0f, 0f));
			} else if (thisTransform.position.y < 3) {
				controller.Move (new Vector3 (0f, 0.2f, 0f));
			} else {
				controller.Move (new Vector3 (0f, -0.2f, 0f));
			}
		}
		// controller.Move (new Vector3 (horizSpeed, vertSpeed, 0f));
	}

	float findRadius() {
		return Mathf.Sqrt ((thisTransform.position.x * thisTransform.position.x) + (thisTransform.position.y * thisTransform.position.y));
	}
}
