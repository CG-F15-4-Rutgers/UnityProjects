
using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    NavMeshAgent agent;
    public Camera camera;

    void Start () {
    
        agent = GetComponent<NavMeshAgent> ();
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}