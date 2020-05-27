using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    // Controls are determined based on the active view, which is managed by CameraManager.cs
    public Camera firstPerson;
	public Camera RTS;
    public Camera thirdPerson;
    public float speed1 = 12f;
    public float speed2 = 2f;
    public float speed3 = 100f;
    public CharacterController controller;
    public Rigidbody focus;

    private float gravity;
    public float deltaCompensation = 40;

    void Awake(){
        focus.detectCollisions = false; // prevents this character controller from colliding since it's just a focal point
    }

    void FixedUpdate() {

        Gravity();

        if (firstPerson.enabled){
            FirstPersonControls(speed1);
        } else if (RTS.enabled){
            RTSControls(speed3);
        } else if (thirdPerson.enabled){
            ThirdPersonControls(speed2);
        }
    }

    void FirstPersonControls(float pace){
        //Mouse controls 'look', character moves with QRTY relative to direction of current 'look';
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        float tooFast = move.x + move.z;
        if (tooFast > 1){
            float reduction = (tooFast - 1)/2;
            move = new Vector3(move.x - reduction, move.y, move.z - reduction);
            controller.Move(move * pace * Time.deltaTime);
        } else {
            controller.Move(move * pace * Time.deltaTime);
        }
    }

    void RTSControls(float pace){
        if (Input.GetKey("w")) RigidbodyMove("forward", pace, focus);
        if (Input.GetKey("s")) RigidbodyMove("back", pace, focus);
        if (Input.GetKey("d")) RigidbodyMove("right", pace, focus);
        if (Input.GetKey("a")) RigidbodyMove("left", pace, focus);
    }

    void ThirdPersonControls(float pace){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Vector3 move = transform.right * x + transform.forward * z;
        float tooFast = move.x + move.z;
        if (tooFast > 1){
            float reduction = (tooFast - 1)/2;
            move = new Vector3(move.x - reduction, move.y, move.z - reduction);
            controller.Move(move * pace * Time.deltaTime);
        } else {
            controller.Move(move * pace * Time.deltaTime);
        }

        /*
        if (Input.GetKey("w")) ControllerMove("forward", pace, controller);
        if (Input.GetKey("s")) ControllerMove("back", pace, controller);
        if (Input.GetKey("d")) ControllerMove("right", pace, controller);
        if (Input.GetKey("a")) ControllerMove("left", pace, controller);*/
    }

    void ControllerMove(string direction, float pace, CharacterController c){
        switch(direction){

            case "forward": c.Move(transform.forward * pace * Time.deltaTime);
            break;

            case "back": c.Move(transform.forward * pace * Time.deltaTime * -1f);
            break;

            case "right": c.Move(transform.right * pace * Time.deltaTime);
            break;

            case "left": c.Move(transform.right * pace * Time.deltaTime * -1f);
            break;
        }
    }

    void RigidbodyMove(string direction, float pace, Rigidbody rb){
        switch(direction){

            case "forward": rb.AddForce(transform.forward * pace * Time.deltaTime, ForceMode.VelocityChange);
            break;

            case "back": rb.AddForce(transform.forward * -1 * pace * Time.deltaTime, ForceMode.VelocityChange);
            break;

            case "right": rb.AddForce(transform.right *  pace * Time.deltaTime, ForceMode.VelocityChange);
            break;

            case "left": rb.AddForce(transform.right * -1 * pace * Time.deltaTime, ForceMode.VelocityChange);
            break;
        }  
    }

    void Gravity(){
        gravity -= 9.81f * Time.deltaTime / deltaCompensation;
        controller.Move(new Vector3(0, gravity, 0));
        if (controller.isGrounded) gravity = 0;
    }


}
