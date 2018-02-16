using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake (){
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't Destroy on load: " + name);
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMuisc = levelMusicChangeArray[level];
			Debug.Log ("Playing clip:" + thisLevelMuisc);

		if (thisLevelMuisc) {
			audioSource.clip = thisLevelMuisc;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

}