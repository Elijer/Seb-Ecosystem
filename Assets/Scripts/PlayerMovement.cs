using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed1 = 12f;
    public float speed2 = 2f;

    public float gravity;

    // Controls are determined based on the active view, which is managed by CameraManager.cs
    public Camera firstPerson;
	public Camera thirdPerson;

    void Update() {

        Gravity();

        if (firstPerson.enabled){
            FirstPersonControls(speed1);
        } else if (thirdPerson.enabled){
            ThirdPersonControls(speed2);
        }
    }

    void FirstPersonControls(float pace){
        //Mouse controls 'look', character moves with QRTY relative to direction of current 'look';
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * pace * Time.deltaTime);
    }

    void ThirdPersonControls(float pace){
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetKey("w")){
            ControllerMove("forward", pace);
        }
        
        if (Input.GetKey("s")){
            ControllerMove("back", pace);
        }

        if (Input.GetKey("d")){
            ControllerMove("right", pace);
        }

        if (Input.GetKey("a")){
            ControllerMove("left", pace);
        }

    }

    void ControllerMove(string direction, float pace){

        switch(direction){
            case "forward": controller.Move(transform.forward * pace * Time.deltaTime);
            break;

            case "back": controller.Move(transform.forward * pace * Time.deltaTime * -1f);
            break;

            case "right": controller.Move(transform.right * pace * Time.deltaTime);
            break;

            case "left": controller.Move(transform.right * pace * Time.deltaTime * -1f);
            break;
        }
    }

    void Gravity(){
        gravity -= 9.81f * Time.deltaTime;
        controller.Move(new Vector3(0, gravity, 0));
        if (controller.isGrounded){
            gravity = 0;
        }
    }


}
