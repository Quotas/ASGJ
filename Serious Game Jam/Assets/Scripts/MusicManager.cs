using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource fxSource;
	public AudioSource musicSource;

	// Use this for initialization
	void Start () 
	{

		// Don't interupt the music during restart or reload of the scene
		DontDestroyOnLoad (this);

	}


	public void SinglePlay(AudioClip clip)
	{

	}

}
