using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRTS : MonoBehaviour {

    public Transform player;
    private Vector3 startPos;
    private Vector3 posChange;
    private Vector3 camStartPos;

    void Start() {
        startPos = player.position;
        camStartPos = transform.position;
    }

    void Update() {
        posChange = startPos - player.position;
        transform.position = new Vector3(camStartPos.x - posChange.x, 0, camStartPos.z - posChange.z);
        Debug.Log(posChange);
        //^make a shortcuts file that makes a shorter method for this
    }
}
