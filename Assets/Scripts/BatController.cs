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

	private bool inMotion;

	void Start()
	{
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
			transform.RotateAround (player.transform.position, Vector3.forward, swingForwardRate * Time.deltaTime);
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
			transform.RotateAround (player.transform.position, Vector3.back, swingBackRate * Time.deltaTime);
			yield return null;
		}
		inMotion = false;
	}
}
