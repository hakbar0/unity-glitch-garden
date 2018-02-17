using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, diffSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlaysPrefsManager.GetMasterVolume ();
		diffSlider.value = PlaysPrefsManager.getDifficulty ();

	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (volumeSlider.value);
	}

	public void SaveAndExit(){
		PlaysPrefsManager.SetMasterVolume (volumeSlider.value);
		PlaysPrefsManager.SetDifficulity (diffSlider.value);
		SceneManager.LoadScene ("01a Start");
	}

	public void SetDefaults (){
		volumeSlider.value = 0.8f;
		diffSlider.value = 2f;
	}
}
