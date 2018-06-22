using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private bool filledBuffer = false;
    private int lastWritten = 0;

    private Rigidbody rigidBody;
    private GameManager manager;
    

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        manager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (manager.recording) { 
            Record();
        } else {
            PlayBack();
        }
    }

    private void PlayBack () {
        rigidBody.isKinematic = true;
        int frame;
        float time = Time.time;

        if (filledBuffer) {
            frame = Time.frameCount % bufferFrames;
        //    Debug.Log("Playing frame " + (frame+1) + "/" + bufferFrames);
        } else {
            frame = Time.frameCount % lastWritten;
        //    Debug.Log("Playing frame " + (frame+1) + "/" + lastWritten);
        }


        transform.position = keyFrames[frame].pos;
        transform.rotation = keyFrames[frame].rot;
    }

    private void Record() {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
    //    print("Writing frame " + (frame+1));

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);

        if (Time.frameCount >= bufferFrames) {
            filledBuffer = true;
        } else {
            filledBuffer = false;
            lastWritten = frame;
        }
    }
}

public struct MyKeyFrame {
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame (float cTime, Vector3 cPos, Quaternion cRot) {
        time = cTime;
        pos = cPos;
        rot = cRot;
    }

}
