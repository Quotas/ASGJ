using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource musicSource;

	public static GameObject instance = null;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this.gameObject;
		} 
		else if (instance != this.gameObject)
		{
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (this.gameObject);
	}

		
}
