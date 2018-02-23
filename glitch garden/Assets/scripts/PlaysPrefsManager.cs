using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaysPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master Volume out of range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockedLevel (int level) {
		if (level <= SceneManager.GetActiveScene().buildIndex -1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // use 1 for true as we don;t have bool
		} else {
			Debug.LogError ("trying to load wrong level");
		}
	}

	public static bool IsLevelUnlocked (int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (levelValue == 1);

		if (level <= SceneManager.GetActiveScene ().buildIndex - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("trying to load wrong level");
			return false;
		}
	}

	public static void SetDifficulity (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
			} else {
			Debug.Log ("difficulty out of range");
		}
	}

	public static float getDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}

}
