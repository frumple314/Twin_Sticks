using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

    public float panSpeed = 5f;

    private Vector3 armRot;
    private GameObject player;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRot = transform.rotation.eulerAngles;
        
	}
	
	// Update is called once per frame
	void Update () {

        armRot.y += CrossPlatformInputManager.GetAxis("RHoriz") * panSpeed;
        armRot.x += CrossPlatformInputManager.GetAxis("RVert") * panSpeed;


        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRot);
    }
}
