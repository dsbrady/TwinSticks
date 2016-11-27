using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string DIFFICULTY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	const string MASTER_VOLUME_KEY = "master_volume";

	// Difficulty
	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat(DIFFICULTY);
	}

	public static void SetDifficulty(float difficulty) {
		if (difficulty >= 1 && difficulty <= 3) {
			PlayerPrefs.SetFloat(DIFFICULTY, difficulty);
		}
		else {
			Debug.LogError("Invalid difficulty value: " + difficulty.ToString());
		}
	}
	
	// Level Unlocked
	public static bool IsLevelUnlocked(int level) {
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
		}
		else {
			Debug.LogError("Invalid level: " + level.ToString());
			return false;
		}
	}
	
	public static void UnlockLevel(int level) {
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // 1 = true
		}
		else {
			Debug.LogError("Invalid level: " + level.ToString());
		}
	}

	// Master Volume	
	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void SetMasterVollume(float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else {
			Debug.LogError("Invalid volume value: " + volume.ToString());
		}
	}
	
}
