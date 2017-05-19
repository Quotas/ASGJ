using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwooshAudio : MonoBehaviour {

	public AudioClip swooshSound;
	AudioSource source;

	void Start()
	{

		source = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter(Collider other)
	{

		source.PlayOneShot (swooshSound);

	}

}
