using UnityEngine;
using System.Collections;

public class OpponentBallCollision : MonoBehaviour
{

	public GameObject deathSprite;

	void Update()
	{
		/*
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Sound");
			audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]); // Play a death sound
		}
		*/
	}

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
