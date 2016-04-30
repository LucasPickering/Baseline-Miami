using UnityEngine;
using System.Collections;

public class OpponentBallCollision : MonoBehaviour
{

	public Transform explosion;

	void OnCollisionEnter2D (Collision2D collision)
	{
		Debug.Log (collision);
		if (collision.gameObject.CompareTag ("Ball")) {
			Kill (collision.gameObject); // On collision with a ball, kill
		}
	}

	private void Kill (GameObject ball)
	{
		Destroy (this.gameObject);
		Destroy (ball.gameObject);
		Instantiate (explosion, this.transform.position, Quaternion.identity);
	}
}
