using UnityEngine;
using UnityEngine.AI;

public class BunnyController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            //Input.mousePosition current mouseposition in screen coordinates
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        //Physics.Raycast(ray, out hit shoots out a "ray" called ray and then saves the "hit" to a RacastHit object called hit
            if (Physics.Raycast(ray, out hit)){
                agent.SetDestination(hit.point);
            }
        }
    }


//SetDestination(position); tells an agent to go somewhere

}
