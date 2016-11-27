using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print("RHorizontal: " + Input.GetAxis("RHorizontal"));
	}
}
