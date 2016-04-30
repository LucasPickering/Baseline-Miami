using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pitches : MonoBehaviour {

	private Text text;
	private int count;

	void Start()
	{
		text = GetComponent<Text> ();
		text.text = "Pitches: " + count;
	}

	public void AddPitch() {
		count++;
		text.text = "Pitches: " + count;
	}
}
