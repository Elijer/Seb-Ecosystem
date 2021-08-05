﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public int lookLimitUp;
    public int lookLimitDown;
    public Camera thisCamera;
    private float xRotation = 0f;

    private bool lookLock = false;

    // Start is called before the first frame update
    void Start()
    {
        //Hides Cursor
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
      if (thisCamera.enabled == true){
        MouseLooker();
      }
    }

    void MouseLooker(){
            if (Input.GetMouseButtonDown(0)){
          //Debug.Log("Mouse Down");
          lookLock = !lookLock;
      }

      if (lookLock == false){
                // Looking
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, lookLimitDown, lookLimitUp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
      } else {
      }
    }
}