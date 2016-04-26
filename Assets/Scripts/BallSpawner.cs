using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{

	[SerializeField]
	public GameObject ballPrefab;
	public float startForce;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject ball = (GameObject)Instantiate (ballPrefab, new Vector3 (0, 0, -1), Quaternion.identity);
			ball.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * startForce);
			ball.tag = "Ball";
		}
	}
}
