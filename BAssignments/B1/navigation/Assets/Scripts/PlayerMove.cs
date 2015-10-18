
using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    NavMeshAgent agent;
    public Camera camera;
	public Animator anim;
	public float speed;
	
	// Use this for initialization
    void Start () {
    
        agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
        }

    }
    
    // Update is called once per frame
    void Update () {
		speed = agent.acceleration;
		anim.SetFloat("Speed", speed);
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