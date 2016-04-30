using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour
{

	[SerializeField]
	public GameObject player;
	public float startAngle;
	public float endAngle;
	public float swingForwardRate;
	public float swingBackRate;
	public float pauseTime;

	private new Rigidbody2D rigidbody;
	private bool inMotion;

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

	void FixedUpdate()
	{
	}

	IEnumerator SwingForward ()
	{
		inMotion = true;
		while (transform.rotation.eulerAngles.z < endAngle) {
			yield return new WaitForFixedUpdate (); // Wait for physics loop before rotating
			RotateAroundPoint (rigidbody, player.transform.position, swingForwardRate * Time.fixedDeltaTime);
			yield return null;
		}

		yield return new WaitForSeconds (pauseTime); // Pause for a bit
		inMotion = false;
		StartCoroutine ("SwingBack");
	}

	IEnumerator SwingBack ()
	{
		inMotion = true;
		while (transform.rotation.eulerAngles.z > startAngle) {
			yield return new WaitForFixedUpdate (); // Wait for physics loop before rotating
			RotateAroundPoint (rigidbody, player.transform.position, -swingBackRate * Time.fixedDeltaTime);
			yield return null;
		}
		inMotion = false;
	}

	void RotateAroundPoint (Rigidbody2D rigidbody, Vector3 origin, float diffAngle)
	{
		Quaternion q = Quaternion.Euler(0f, 0f, diffAngle); // Quaternion to rotate with
		rigidbody.MovePosition(q * (transform.position - origin) + origin); // Move to the new position
    rigidbody.MoveRotation((transform.rotation * q).eulerAngles.z); // Rotate to the new angle
	}
}
