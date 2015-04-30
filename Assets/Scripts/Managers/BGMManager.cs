using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {
	

	AudioSource bgAudio;
	// Use this for initialization

	void Awake ()
	{
		bgAudio = GetComponent <AudioSource> ();
	}

	void Start () {
		bgAudio.Play ();
	}

	public void StopBGM () {
		bgAudio.Stop ();
	}
}
