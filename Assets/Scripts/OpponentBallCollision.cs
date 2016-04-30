using UnityEngine;
using System.Collections;

public class OpponentBallCollision : MonoBehaviour
{

	[SerializeField]
	public AudioClip[] audioClips;
	public GameObject deathSprite;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
	}

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
		audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]); // Play a death sound
		Destroy (gameObject); // Kill me
		Destroy (ball.gameObject); // Kill the ball (misery loves company)
		Instantiate(deathSprite, transform.position, Quaternion.identity); // Splat
	}
}
