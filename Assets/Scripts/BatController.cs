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

	private bool swingForward;
	private bool swingBack;

	void Start()
	{
		StartCoroutine ("SwingBack");
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			swingForward = true;
		}
	}

	void FixedUpdate ()
	{
		if (swingForward) {
			//transform.RotateAround (player.transform.position, Vector3.forward, 20);
			StartCoroutine ("SwingForward");
			swingForward = false; // Reset the variable after initiating the swing
		}
	}

	IEnumerator SwingForward ()
	{
		while (transform.rotation.eulerAngles.z < endAngle) {
			transform.RotateAround (player.transform.position, Vector3.forward, swingForwardRate * Time.deltaTime);
			yield return null;
		}
	}

	IEnumerator SwingBack ()
	{
		while (transform.rotation.eulerAngles.z > startAngle) {
			transform.RotateAround (player.transform.position, Vector3.back, swingBackRate * Time.deltaTime);
			yield return null;
		}
	}
}
