using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera cam1;
	public Camera cam2;
    public Camera cam3;

    void Start(){
        CamSwitcher(3);    //Switches the camera
    }

    void Update() {
        KeyScanner();      //Switches camera according to Key commands
    }

    void KeyScanner(){
        switch(Input.inputString){
            case "1": CamSwitcher(1); break;
            case "2": CamSwitcher(2); break;
            case "3": CamSwitcher(3); break;
        }
    }

    void CamSwitcher(int cam){
        if (cam == 1){
			cam1.enabled = true;    cam1.GetComponent<AudioListener>().enabled = true;
			cam2.enabled = false;   cam2.GetComponent<AudioListener>().enabled = false;
            cam3.enabled = false;   cam3.GetComponent<AudioListener>().enabled = false;
        } else if (cam == 2){
			cam1.enabled = false;   cam1.GetComponent<AudioListener>().enabled = false;
			cam2.enabled = true;    cam2.GetComponent<AudioListener>().enabled = true;
            cam3.enabled = false;   cam3.GetComponent<AudioListener>().enabled = false;
        } else if (cam == 3){
			cam1.enabled = false;   cam1.GetComponent<AudioListener>().enabled = false;
			cam2.enabled = false;   cam2.GetComponent<AudioListener>().enabled = false;
            cam3.enabled = true;    cam3.GetComponent<AudioListener>().enabled = true;
        } else {
            Debug.Log("CamSwitcher doesn't take that as an argument, or that camera doesn't exist");
        }
    }
}
