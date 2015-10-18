using UnityEngine;
using System.Collections;

public class KyleAnimationScript : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis("Vertical");
		anim.SetFloat("Speed", move);

		if(Input.GetKeyDown(KeyCode.RightShift)||Input.GetKeyDown(KeyCode.LeftShift)) {
			anim.SetBool("Sprint", true);
		}

		if(Input.GetKeyUp(KeyCode.RightShift)||Input.GetKeyUp(KeyCode.LeftShift)) {
			anim.SetBool("Sprint", false);
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			anim.SetTrigger("Jump");
		}
	}
}
