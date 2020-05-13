using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowThings : MonoBehaviour {
    public GameObject grassPrefab;
    public bool debugMode = false;

    private float squareScale;
    private float randomX;
    private float randomZ;
    private float defaultHeight = 0.47f;
    private Vector3 placement;
    private float margin = 0.5f;
    private float spin;

    void Start() {
        squareScale = transform.lossyScale.x;
    }

    void Update() {
        randomX = Random.Range(-squareScale/2+margin, squareScale/2-margin);
        randomZ = Random.Range(-squareScale/2+margin, squareScale/2-margin);
        spin = Random.Range(0, 179);


        placement = new Vector3(randomX, defaultHeight, randomZ);
        
        GameObject newGrass = (GameObject)Instantiate(grassPrefab, placement, Quaternion.Euler(0,spin,0));
    }
}






        /*
        if (debugMode == true){
            Debug.Log("randomX is " + randomX);
            Debug.Log("randomZ is " + randomZ);
            Debug.Log("squareScale is " + squareScale);
            Debug.Log("placement is " + placement);
        }*/

        /*
        Missile missile = missileGameObject.GetComponent<Missile>();
        v = player.GetComponent<Rigidbody>().velocity * fireForce;
        missile.GetComponent<Rigidbody>().velocity = v;*/
