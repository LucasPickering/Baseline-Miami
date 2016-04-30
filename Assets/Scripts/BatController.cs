using UnityEngine;
using System.Collections;
using MovementEffects;

public class BatController : MonoBehaviour
{

	public float startAngle;
	public float endAngle;
	public float swingForwardRate;
	public float swingBackRate;
	public float pauseTime;

	private new Rigidbody2D rigidbody;
	private bool inMotion;
	private bool swingingForward;
	private bool swingingBack;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		StartCoroutine ("SwingBack");
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && !inMotion) {
			StartCoroutine ("SwingForward");
		}
	}

	void FixedUpdate ()
	{
		if (swingingForward) {
			if (rigidbody.rotation < endAngle) {
				rigidbody.MoveRotation (rigidbody.rotation + swingForwardRate * Time.fixedDeltaTime); // Rotate to the new angle
			} else {
				swingingForward = false;
				swingingBack = true;
			}
		} else if (swingingBack) {
			if (rigidbody.rotation > startAngle) {
				rigidbody.MoveRotation (rigidbody.rotation - swingForwardRate * Time.fixedDeltaTime); // Rotate to the new angle
			} else {
				swingingBack = false;
			}
		}
	}

	private IEnumerator<float> SwingForward ()
	{
		inMotion = true;
		while (transform.rotation.eulerAngles.z < endAngle) {
			rigidbody.MoveRotation (rigidbody.rotation + swingForwardRate * Time.fixedDeltaTime); // Rotate to the new angle
			yield return 0;
		}

		yield return Timing.WaitForSeconds (pauseTime); // Pause for a bit
		inMotion = false;
		StartCoroutine ("SwingBack");
	}

	private IEnumerator<float> SwingBack ()
	{
		inMotion = true;
		while (transform.rotation.eulerAngles.z > startAngle) {
			rigidbody.MoveRotation (rigidbody.rotation - swingForwardRate * Time.fixedDeltaTime); // Rotate to the new angle
			yield return 0;
		}
		inMotion = false;
	}

	void RotateAroundPoint (Rigidbody2D rigidbody, Vector3 origin, float diffAngle)
	{
		Quaternion q = Quaternion.Euler (0f, 0f, diffAngle); // Quaternion to rotate with
		rigidbody.MovePosition (q * (transform.position - origin) + origin); // Move to the new position
	}
}
