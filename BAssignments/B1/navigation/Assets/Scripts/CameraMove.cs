using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.position = Input.mousePosition;
	}
}
