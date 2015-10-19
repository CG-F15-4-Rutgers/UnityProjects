using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour {
	
	public static Boundries cameraLimits = new Boundries();
	public static Boundries mouseScrollLimits = new Boundries();
	public static Camera_Script Instance;
	private float cameraMoveSpeed = 60f;
	private float mouseBoundary = 50f;
	public struct Boundries {
		public float leftBound;
		public float rightBound;
		public float topBound;
		public float botBound;
	}
	
	
	void Start () {
		mouseScrollLimits.topBound = mouseBoundary;
		mouseScrollLimits.botBound = mouseBoundary;
		mouseScrollLimits.leftBound = mouseBoundary;
		mouseScrollLimits.rightBound = mouseBoundary;
		
		cameraLimits.topBound = 1000f;
		cameraLimits.botBound = -1000f;
		cameraLimits.leftBound = -1000f;
		cameraLimits.rightBound = 1000f;
	}
	
	void Update () {
		if (CheckCamera()) {
			
			Vector3 cameraDesiredMove = GetTranslate();
			
			if(!ValidPosition(cameraDesiredMove))
			{
				
				this.transform.Translate(cameraDesiredMove);        
			}
		}
		
	}
	
	public bool CheckCamera(){
		bool mouseMove;
		bool canMove;
		bool keyboardMove;
		
		if (Camera_Script.ValidMouseBoundry()) {
			mouseMove = true;
		} else { 
			mouseMove = false;
		}
		
		if (Camera_Script.CameraKeys ()) {
			keyboardMove = true;
		} else {
			
			keyboardMove = false;
		}
		
		if (keyboardMove || mouseMove) {
			
			canMove = true;
		} else {
			canMove = false;
		}
		
		return canMove;
		
	}
	
	public static bool CameraKeys()
	{
		if((Input.GetKey(KeyCode.W)) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
			return true;
		} else {
			return false;
		}
		
	}
	
	public static bool  ValidMouseBoundry(){
		
		if(
			(Input.mousePosition.x < mouseScrollLimits.leftBound && Input.mousePosition.x > -5) ||
			(Input.mousePosition.x > (Screen.width - mouseScrollLimits.rightBound)&& Input.mousePosition.x < (Screen.width + 5)) ||
			(Input.mousePosition.y < mouseScrollLimits.botBound && Input.mousePosition.y > -5) ||
			(Input.mousePosition.y > (Screen.height - mouseScrollLimits.topBound) && Input.mousePosition.y < (Screen.height +5))){
			return true;
		} else {
			
			return false;
		}
	}
	
	public bool ValidPosition(Vector3 targetPos){
		if (cameraLimits.leftBound > (this.transform.position.x + targetPos.x)) {
			return true;
		}
		
		if (cameraLimits.rightBound < (this.transform.position.x + targetPos.x) ) {
			return true;
		}
		
		if ( cameraLimits.topBound < (this.transform.position.z + targetPos.x)) {
			return true;
		}
		
		if (cameraLimits.botBound > (this.transform.position.z + targetPos.x)) {
			return true;
		}
		
		return false;
		
	}
	
	public Vector3 GetTranslate()
	{
		float moveSpeed = 0f;
		float targetX = 0f;
		float targetZ = 0f;
		moveSpeed = cameraMoveSpeed * Time.deltaTime;
		
		
		if (Input.GetKey (KeyCode.A)) {
			targetX = moveSpeed * -1;
		}
		
		if (Input.GetKey (KeyCode.D)) {
			targetX = moveSpeed;
		}
		
		if (Input.mousePosition.x < mouseScrollLimits.leftBound) {
			targetX = moveSpeed * -1;
		}
		
		if (Input.mousePosition.x > (Screen.width - mouseScrollLimits.rightBound)){
			targetX = moveSpeed;
		}
		
		if (Input.GetKey (KeyCode.W)) {
			targetZ = moveSpeed;
		}
		
		if (Input.GetKey (KeyCode.S)) {
			targetZ = moveSpeed * -1;
		}
		
		if (Input.mousePosition.y < mouseScrollLimits.botBound) {
			targetZ = moveSpeed * -1;
		}
		
		if (Input.mousePosition.y > (Screen.height - mouseScrollLimits.topBound)) {
			targetZ = moveSpeed;
		}
		
		return new Vector3 (targetX, 0, targetZ);
		
	}
}
