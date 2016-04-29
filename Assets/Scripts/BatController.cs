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

	private Rigidbody2D rigidbody;
	private bool inMotion;
	private bool swingForward = true;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		rigidbody.centerOfMass = player.transform.position;
		StartCoroutine ("SwingBack");
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && !inMotion) {
			StartCoroutine ("SwingForward");
		}
	}

	IEnumerator SwingForward ()
	{
		inMotion = true;
		while (transform.rotation.eulerAngles.z < endAngle) {
			yield return new WaitForFixedUpdate ();
			RotateAroundPoint (rigidbody, player.transform.position, swingForwardRate * Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds (pauseTime);
		inMotion = false;
		StartCoroutine ("SwingBack");
	}

	IEnumerator SwingBack ()
	{
		inMotion = true;
		while (transform.rotation.eulerAngles.z > startAngle) {
			RotateAroundPoint (rigidbody, player.transform.position, -swingBackRate * Time.deltaTime);
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
