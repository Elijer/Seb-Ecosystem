using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notes
// the .Length property doesn't return the last index, it returns the number of items in the array.

public class CameraManager : MonoBehaviour {

    // camera array
    public Camera[] cameras = new Camera[3];
    public Transform player;

    void Start(){
        // Debug.Log(cameras.Length); > 4
        CamSwitcher(0); //sets starting camera
    }

    void Update() {
        KeyScanner(); //listens to key commands and switches camera appropriately
    }

    void KeyScanner(){
        string keyInput = Input.inputString;
        if (keyInput != ""){
            int validSelection;
            System.Int32.TryParse(Input.inputString, out validSelection);
            if (validSelection <= cameras.Length && validSelection > 0){
                CamSwitcher(validSelection - 1);
            }
        }
    }

    
    void configureCamera(Camera cam, bool isActive){
        cam.enabled = isActive;
        cam.GetComponent<AudioListener>().enabled = isActive;
    }


    void CamSwitcher(int cam){
        Cursor.lockState = CursorLockMode.Locked;
        for(int i = 0; i < cameras.Length; i++ ){
            if (i == cam){
                configureCamera(cameras[i], true);
            } else {
                configureCamera(cameras[i], false);
            }
        }

        switch (cam) {  
            case 0:
                break;
            case 1:
                RotationReset();
                Cursor.lockState = CursorLockMode.None;
                break;
            case 2:
                RotationReset();
                break;
        }

        



/*         configureCamera(cameras[0], true);
        configureCamera(cameras[1], false);
        configureCamera(cameras[2], false);
        configureCamera(cameras[3], false); */
    

        // iterate through cameras array. Activate the match, deactivate everything else.
/*         for(int i = 0; i < cameras.Length; i++ ){
            configureCamera(cameras[i], true);
            if (i != cam - 1){
                configureCamera(cameras[i], false);
            }
        }

        if (cam == 1){

            Cursor.lockState = CursorLockMode.Locked;

        } else if (cam == 2)
        {
            RotationReset();

            Cursor.lockState = CursorLockMode.None;

        } else if (cam == 3){

            RotationReset();
            Cursor.lockState = CursorLockMode.Locked;

        } else if (cam == 4){

        } else {

            Debug.Log("CamSwitcher doesn't take that as an argument, or that camera doesn't exist");

        } */
    }

    void RotationReset(){
        player.eulerAngles = new Vector3(0, 0, 0);
    }
}
