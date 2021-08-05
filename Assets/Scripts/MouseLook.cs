 using System.Collections;
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

    void Start()
    {
    }

    void Update() {
      if (thisCamera.enabled == true){
        MouseLooker();
      }
    }

    void MouseLooker(){

      // Rightclick toggles view lock for testing purposes:
      // Lets you keep the same view while changing variable values in GUI etc.
      if (Input.GetMouseButtonDown(0)){
          lookLock = !lookLock;
      }

      if (lookLock == false){
        // Looking
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, lookLimitUp, lookLimitDown);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
      } else {
      }
    }
}