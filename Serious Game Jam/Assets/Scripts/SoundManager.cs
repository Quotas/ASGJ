using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	[SerializeField]
	List<AudioSource> sources = new List<AudioSource>();
	[SerializeField]
	List<string> name = new List<string>();

	public void PlaySound(AudioClip clip, int audioSourceRef)
	{
		sources[audioSourceRef].clip = clip;
		sources [audioSourceRef].Play ();
	}

}
