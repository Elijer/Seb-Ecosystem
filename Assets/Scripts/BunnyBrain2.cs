using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBrain2 : MonoBehaviour {

    public Rigidbody rb;

    public float torque1;
    public float torque2;
    public float torque3;
    private float timeCount = 0.2f;

    public float bunnyTurn = 0;
    public float turnAmount;

    private int direction;


    void Start(){
    }

    void Update() {
        if (Input.GetKeyDown("b")) Turn("right");
        if (Input.GetKeyDown("n")) Turn("left");


    }

    void Turn(string d){
        if (d == "right"){
            direction = 1;
        } else if (d == "left"){
            direction = -1;
        }
        //bunnyTurn = bunnyTurn + turnAmount;
        //transform.Rotate(0.0f, 1.0f, 0.0f);

        // jesus christ. So right now I have a problem but I need to go to bed.
        // The problem is that if you just do b or just do n, it works fine. But doing one after the other
        // skips a turn. I think I know why. It's cause you do 0+30

        transform.rotation = Quaternion.Euler(0, bunnyTurn + (turnAmount * direction), 0);
        //transform.rotation = Quaternion.Slerp(current, next, timeCount);
        //Quaternion current = Quaternion.Euler(0, bunnyTurn, 0);
        //Quaternion next = Quaternion.Euler(0, bunnyTurn + turnAmount, 0);
        //timeCount = timeCount + Time.deltaTime;
        bunnyTurn = bunnyTurn + (turnAmount * direction);

        Debug.Log(transform.rotation.y);

        //transform.rotation.y
        /*
        rb.AddTorque(Vector3.forward * torque1 * Time.deltaTime);
        rb.AddTorque(Vector3.left * torque2 * Time.deltaTime);
        rb.AddTorque(Vector3.down * torque3 * Time.deltaTime);
        */
    }

    void Look(){
        Debug.Log(GetComponent<Rigidbody>());

        /*camera.rotate;
        if (see == predator){
            go(flee);
        }

        if (see == food && hunger < 100){
            go(eat);
        }

        if (see == bunny && hunger > 70) {
            go(mate);
        }*/
    }
}