using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {
	public bool isRecording =  true;

	private float defaultTimeScale;
	private float defaultFixedDeltaTime;
	private bool isPaused = false;

	void Start() {
		PlayerPrefsManager.UnlockLevel(0);
		defaultTimeScale = Time.timeScale;
		defaultFixedDeltaTime = Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update () {
		this.isRecording = !CrossPlatformInputManager.GetButton("Fire1");

		if (Input.GetKeyDown(KeyCode.P)) {
			if (isPaused) {
				ResumeGame();
			}
			else {
				PauseGame();
			}
		}
	}

	void OnApplicationPause(bool pauseStatus) {
		if(pauseStatus) {
			PauseGame();
		}
		else {
			ResumeGame();
		}
	}

	void PauseGame() {
		this.isPaused = true;
		Time.fixedDeltaTime = 0f;
		Time.timeScale = 0f;
	}

	void ResumeGame() {
		this.isPaused = false;
		Time.fixedDeltaTime = defaultFixedDeltaTime;
		Time.timeScale = defaultTimeScale;
	}
}
