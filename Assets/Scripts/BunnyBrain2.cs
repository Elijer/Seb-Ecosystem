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

    public float hopTravel;
    public float hopHops;

    private int direction;


    void Start(){
    }

    void Update() {
        if (Input.GetKeyDown("b")) Turn("right");
        if (Input.GetKeyDown("n")) Turn("left");
        if (Input.GetKeyDown("m")) Hop();


    }

    void Turn(string d){
        if (d == "right") direction = 1;
        if (d == "left") direction = -1;

        transform.rotation = Quaternion.Euler(0, bunnyTurn + (turnAmount * direction), 0);
        bunnyTurn = bunnyTurn + (turnAmount * direction);
    }

    void Hop(){
        rb.AddForce(transform.forward * hopTravel);
        rb.AddForce(transform.up * hopHops);
    }

    void Look(){
    }
}





    // Torque
        //transform.rotation.y
        /*
        rb.AddTorque(Vector3.forward * torque1 * Time.deltaTime);
        rb.AddTorque(Vector3.left * torque2 * Time.deltaTime);
        rb.AddTorque(Vector3.down * torque3 * Time.deltaTime);
        */

    //Quaternion Slerp
        //transform.rotation = Quaternion.Slerp(current, next, timeCount);
        //Quaternion current = Quaternion.Euler(0, bunnyTurn, 0);
        //Quaternion next = Quaternion.Euler(0, bunnyTurn + turnAmount, 0);
        //timeCount = timeCount + Time.deltaTime;

    //transform.Rotate(x, y, z)
        //bunnyTurn = bunnyTurn + turnAmount;
        //transform.Rotate(0.0f, 1.0f, 0.0f);