using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{

	[SerializeField]
	public GameObject ballPrefab;
	public float minSpeed;
	public float maxSpeed;
	public float lifeTime;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject ball = (GameObject)Instantiate (ballPrefab, ballPrefab.transform.position, Quaternion.identity);
			ball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, -Random.Range (minSpeed, maxSpeed)); // Random start speed in range
			Destroy(ball, lifeTime); // Kill the ball after a certain amount of time
		}
	}
}
