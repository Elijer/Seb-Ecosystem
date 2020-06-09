﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* What I should really do is to create an array that is full of the cameras and
create a function that first selects one and makes it active as well as it's audio listener
and then immediately goes through all others and makes them inactive.
In addition, the hotkeys for the cameras should be command+1, command+2, etc,
that way I won't select them accidentally when I'm putting in the public values.
Is it possible to automatically create an array of cameras in the scene instead of selecting them 
one by one? Dragging them all in one by one would honestly be great too, but I think it's worth looking
into. */

public class CameraManager : MonoBehaviour {

    public Camera cam1;
	public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Transform player;

    void Start(){
        CamSwitcher(4);    //Switches the camera
    }

    void Update() {
        KeyScanner();      //Switches camera according to Key commands
    }

    void KeyScanner(){
        switch(Input.inputString){
            case "1": CamSwitcher(1); break;
            case "2": CamSwitcher(2); break;
            case "3": CamSwitcher(3); break;
            case "4": CamSwitcher(4); break;
        }
    }

    void CamSwitcher(int cam){
        if (cam == 1){
            Cursor.lockState = CursorLockMode.Locked;
			cam1.enabled = true;    cam1.GetComponent<AudioListener>().enabled = true;
			cam2.enabled = false;   cam2.GetComponent<AudioListener>().enabled = false;
            cam3.enabled = false;   cam3.GetComponent<AudioListener>().enabled = false;
            cam4.enabled = false;   cam4.GetComponent<AudioListener>().enabled = false;
        } else if (cam == 2){
            RotationReset();
            Cursor.lockState = CursorLockMode.None;
			cam1.enabled = false;   cam1.GetComponent<AudioListener>().enabled = false;
			cam2.enabled = true;    cam2.GetComponent<AudioListener>().enabled = true;
            cam3.enabled = false;   cam3.GetComponent<AudioListener>().enabled = false;
            cam4.enabled = false;   cam4.GetComponent<AudioListener>().enabled = false;
        } else if (cam == 3){
            RotationReset();
            Cursor.lockState = CursorLockMode.Locked;
			cam1.enabled = false;   cam1.GetComponent<AudioListener>().enabled = false;
			cam2.enabled = false;   cam2.GetComponent<AudioListener>().enabled = false;
            cam3.enabled = true;    cam3.GetComponent<AudioListener>().enabled = true;
            cam4.enabled = false;   cam4.GetComponent<AudioListener>().enabled = false;
        } else if (cam == 4){
			cam1.enabled = false;   cam1.GetComponent<AudioListener>().enabled = false;
			cam2.enabled = false;   cam2.GetComponent<AudioListener>().enabled = false;
            cam3.enabled = false;   cam3.GetComponent<AudioListener>().enabled = false;
            cam4.enabled = true;    cam4.GetComponent<AudioListener>().enabled = true;
        } else {
            Debug.Log("CamSwitcher doesn't take that as an argument, or that camera doesn't exist");
        }
    }

    void RotationReset(){
        player.eulerAngles = new Vector3(0, 0, 0);
    }
}
