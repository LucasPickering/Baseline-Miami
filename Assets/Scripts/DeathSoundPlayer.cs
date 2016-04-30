using UnityEngine;
using System.Collections;

public class DeathSoundPlayer : MonoBehaviour
{

	[SerializeField]
	public AudioClip[] audioClips;

	void Start ()
	{
		GetComponent<AudioSource> ().PlayOneShot (audioClips [Random.Range (0, audioClips.Length)]); // Play a death sound
	}
}
