using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private bool togglePause = false;
    private float timeScale;
    private float fixedDeltaTime;

	// Use this for initialization
	void Start () {
        timeScale = Time.timeScale;
        fixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
            recording = false;
        } else {
            recording = true;
        }

        if (Input.GetKeyDown (KeyCode.P)) {
            if (!togglePause) {
                PauseGame();
            } 
            else {
                ResumeGame();
            }
        }

	}

    void PauseGame () {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        togglePause = true;
    }

    void ResumeGame () {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = fixedDeltaTime;
        togglePause = false;
    }

    private void OnApplicationPause(bool pause) {
        togglePause = pause;
    }
}
