using UnityEngine;
using System.Collections;

public class PlayerAnimationScript : MonoBehaviour {
	public Animator anim;
	int sprintHash = Animator.StringToHash("JogForward_NtrlFaceFwd");
	int walkHash = Animator.StringToHash("WalkFWD");

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis("Vertical");
		anim.SetFloat("Speed", move);

		/*if(Input.GetKeyDown(KeyCode.RightShift)) {
			anim.SetBool("Sprint", true);
		}

		if(Input.GetKeyUp(KeyCode.RightShift)) {
			anim.SetBool("Sprint", false);
		}
*/
		/*AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if(Input.GetKeyDown(KeyCode.Space)) {
			anim.SetTrigger("Walk Jump");
		}

		/*if(Input.GetKeyUp(KeyCode.Space)) {
			anim.SetBool("Walk Jump", false);
		}	*/
	}	
}
