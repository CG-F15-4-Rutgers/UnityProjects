using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {
	public GameObject target;
	NavMeshAgent agent;
	public GameObject selectionCircle;
	public Animator anim;
	public float speed;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
		agent.speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (agent != null) {
			if (Input.GetKeyDown (KeyCode.Equals)) {
				agent.speed=20;
			}
			if (Input.GetKeyDown (KeyCode.Minus)) {
				agent.speed=4;
			}
			speed = agent.velocity.magnitude;
			anim.SetFloat("Speed", speed);

			if (agent.speed == 20 && speed > 0.001) {
				anim.SetBool ("Sprint", true);
			} else {
				anim.SetBool ("Sprint", false);
			}
			if (agent.isOnOffMeshLink) {
				anim.SetTrigger("Jump");
			}
			agent.SetDestination (target.transform.position);
		}
	}

	public GameObject getTarget()
	{
		return target;
	}
}
