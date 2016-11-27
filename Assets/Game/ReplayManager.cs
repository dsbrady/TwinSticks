using UnityEngine;
using System.Collections;

public class ReplayManager : MonoBehaviour {

	private const int BUFFER_FRAMES = 1000;
	private int frameNumber;
	private Frame[] frames = new Frame[BUFFER_FRAMES];
	private GameManager gameManager;
	private bool isBufferFull = false;
	private int playBackFrameNumber = -1;
	private int recordFrameNumber = -1;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
		rigidBody = GetComponent<Rigidbody>();
	}

	void PlayBack() {
		rigidBody.isKinematic = true;
		playBackFrameNumber++;
		if (playBackFrameNumber == BUFFER_FRAMES || (!isBufferFull && playBackFrameNumber > recordFrameNumber)) {
			playBackFrameNumber = 0;
		}
		transform.position = frames[playBackFrameNumber].position;
		transform.rotation = frames[playBackFrameNumber].rotation;
	}

	void Record ()
	{
		// Don't record if the game is paused
		if (Time.timeScale > 0f) {
			rigidBody.isKinematic = false;
			recordFrameNumber++;
			if (recordFrameNumber == BUFFER_FRAMES) {
				isBufferFull = true;
				recordFrameNumber = 0;
			}
			frames [recordFrameNumber] = new Frame (Time.time, gameObject.transform.position, gameObject.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.isRecording) {
			Record();
		}
		else {
			PlayBack();
		}
	}
}


/// <summary>
/// A structure for storing key frames for replay
/// </summary>
public struct Frame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public Frame(float time, Vector3 position, Quaternion rotation) {
		this.frameTime = time;
		this.position = position;
		this.rotation = rotation;
	}
}