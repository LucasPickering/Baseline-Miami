using UnityEngine;
using System.Collections;

public class OpponentBallCollision : MonoBehaviour
{

	public GameObject deathSprite;

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("Ball")) {
			Kill (collision.gameObject); // On collision with a ball, kill
		}
	}

	private void Kill (GameObject ball)
	{
		Destroy (gameObject); // Kill me
		Destroy (ball.gameObject); // Kill the ball (misery loves company)
		Instantiate(deathSprite, transform.position, Quaternion.identity); // Splat
	}
}
