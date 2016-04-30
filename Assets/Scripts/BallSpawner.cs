using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{

	[SerializeField]
	public GameObject ballPrefab;
	public float minSpeed;
	public float maxSpeed;
	public float lifeTime;
	public float spawnInterval;

	void Start ()
	{
		InvokeRepeating ("SpawnBall", spawnInterval, spawnInterval); // Spawn a ball every few seconds
	}

	private void SpawnBall()
	{
		GameObject ball = (GameObject)Instantiate (ballPrefab, ballPrefab.transform.position, Quaternion.identity); // Spawn the ball
		ball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, -Random.Range (minSpeed, maxSpeed)); // Random start speed in range
		Destroy(ball, lifeTime); // Kill the ball after a certain amount of time
	}
}
