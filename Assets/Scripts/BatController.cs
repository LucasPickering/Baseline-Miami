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
		//StartCoroutine ("SwingBack");
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

	void RotateAroundPoint (Rigidbody2D rigidbody, Vector2 origin, float diffAngle)
	{
		float destAngle = rigidbody.rotation + diffAngle;
		Vector2 originalPos = rigidbody.position;
		rigidbody.MovePosition (origin); // Move to the origin
		rigidbody.MoveRotation (destAngle); // Rotate around the origin

		float sin = Mathf.Sin(diffAngle * Mathf.Deg2Rad);
		float cos = Mathf.Cos(diffAngle * Mathf.Deg2Rad);
		Vector2 newPos = new Vector2 (rigidbody.position.x * cos - rigidbody.position.y * sin, rigidbody.position.x * sin + rigidbody.position.y * cos);
		Debug.Log (newPos);
		rigidbody.MovePosition (newPos); // Move back
	}
}
