using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float speed2 = 2f;

    private bool lookLock = false;

    public Camera cam1;
	public Camera cam2;

    void Start(){
        cam1.enabled = true;
		cam2.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("c")){ //switches active Camera
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
		}

        if (cam1.enabled){
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

        } else if (cam2.enabled){
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            //Vector3 moveParametric = 

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
}
