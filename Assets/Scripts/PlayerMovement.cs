using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float speed2 = 2f;

    // Controls are determined based on the active view, which is managed by CameraManager.cs
    public Camera firstPerson;
	public Camera thirdPerson;

    void Update() {

        if (firstPerson.enabled){
            FirstPersonControls();
        } else if (thirdPerson.enabled){
            ThirdPersonControls();
        }
    }

    void FirstPersonControls(){
        //Mouse controls 'look', character moves with QRTY relative to direction of current 'look';
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    void ThirdPersonControls(){
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetKey("w")){
            controller.Move(transform.forward * speed2 * Time.deltaTime);
        }
        if (Input.GetKey("s")){
            controller.Move(transform.forward * speed2 * Time.deltaTime * -1f);
        }
        if (Input.GetKey("d")){
            controller.Move(transform.right * speed2 * Time.deltaTime);
        }
        if (Input.GetKey("a")){
            controller.Move(transform.right * speed2 * Time.deltaTime * -1f);
        }
    }


}
