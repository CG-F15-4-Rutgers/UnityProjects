using UnityEngine;
using System.Collections;

public class Agent1 : MonoBehaviour {
	public GameObject target;
	NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (agent != null) {
			agent.SetDestination (target.transform.position);
		}
	}

	public GameObject getTarget()
	{
		return target;
	}
}
