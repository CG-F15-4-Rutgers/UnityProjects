using UnityEngine;
using System.Collections;

public class RTS_Camera : MonoBehaviour {
	
	public struct BoxLimit {
		public float LeftLimit;
		public float RightLimit;
		public float TopLimit;
		public float BottomLimit;
		
	}
	
	public static BoxLimit cameraLimits = new BoxLimit();
	public static BoxLimit mouseScrollLimits = new BoxLimit();
	public static RTS_Camera Instance;
	
	private float cameraMoveSpeed = 60f;
	private float shiftBonus = 45f;
	private float mouseBoundary = 25f;
	
	void Awake()
	{
		Instance = this;
	}
	
	// Use this for initialization
	void Start () {
		
		cameraLimits.LeftLimit = -1000f;
		cameraLimits.RightLimit = 1000f;
		cameraLimits.TopLimit = 1000f;
		cameraLimits.BottomLimit = -1000f;
		
		mouseScrollLimits.LeftLimit = mouseBoundary;
		mouseScrollLimits.RightLimit = mouseBoundary;
		mouseScrollLimits.TopLimit = mouseBoundary;
		mouseScrollLimits.BottomLimit = mouseBoundary;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckIfUserCameraInput()) {

			Vector3 cameraDesiredMove = GetDesiredTranslation();

			if(!isDesiredPositionOverBounderies(cameraDesiredMove))
			{

				this.transform.Translate(cameraDesiredMove);		
			}
		}
		
	}
	
	public bool CheckIfUserCameraInput(){
		bool keyboardMove;
		bool mouseMove;
		bool canMove;
		
		
		if (RTS_Camera.AreCameraKeyboardButtonsPressed ()) {
			keyboardMove = true;
		} else {
			
			keyboardMove = false;
		}
		
		if (RTS_Camera.IsMousePositionWithinBoundaries ()) {
			mouseMove = true;
		} else { 
			mouseMove = false;
		}
		
		if (keyboardMove || mouseMove) {
			
			canMove = true;
		} else {
			canMove = false;
		}
		
		return canMove;
		
	}
	
	public Vector3 GetDesiredTranslation()
	{
		float moveSpeed = 0f;
		float desiredX = 0f;
		float desiredZ = 0f;
		
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			moveSpeed = (cameraMoveSpeed + shiftBonus) * Time.deltaTime;
		} else {
			moveSpeed = cameraMoveSpeed * Time.deltaTime;
		}
		
		if (Input.GetKey (KeyCode.W)) {
			desiredZ = moveSpeed;
		}

		
		if (Input.GetKey (KeyCode.S)) {
			desiredZ = moveSpeed * -1;
		}
		
		if (Input.GetKey (KeyCode.A)) {
			desiredX = moveSpeed * -1;
		}
		
		if (Input.GetKey (KeyCode.D)) {
			desiredX = moveSpeed;
		}
		
		if (Input.mousePosition.x < mouseScrollLimits.LeftLimit) {
			desiredX = moveSpeed * -1;
		}
		
		if (Input.mousePosition.x > (Screen.width - mouseScrollLimits.RightLimit)){
			desiredX = moveSpeed;
		}
		
		if (Input.mousePosition.y < mouseScrollLimits.BottomLimit) {
			desiredZ = moveSpeed * -1;
		}
		
		if (Input.mousePosition.y > (Screen.height - mouseScrollLimits.TopLimit)) {
			desiredZ = moveSpeed;
		}

		return new Vector3 (desiredX, 0, desiredZ);
		
	}
	
	public bool isDesiredPositionOverBounderies(Vector3 desiredPosition){
		
		bool overBoundaries = false;
		
		if ((this.transform.position.x + desiredPosition.x) < cameraLimits.LeftLimit) {
			overBoundaries = true;
		}
		
		if ((this.transform.position.x + desiredPosition.x) > cameraLimits.RightLimit) {
			overBoundaries = true;
		}
		
		if ((this.transform.position.z + desiredPosition.x) > cameraLimits.TopLimit) {
			overBoundaries = true;
		}
		
		if ((this.transform.position.z + desiredPosition.x) < cameraLimits.BottomLimit) {
			overBoundaries = true;
		}

		return overBoundaries;
		
	}
		
	public static bool AreCameraKeyboardButtonsPressed()
	{
		if((Input.GetKey(KeyCode.W)) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
			return true;
		} else {
			return false;
		}
		
	}
	
	public static bool  IsMousePositionWithinBoundaries(){
		
		if(
			(Input.mousePosition.x < mouseScrollLimits.LeftLimit && Input.mousePosition.x > -5) ||
			(Input.mousePosition.x > (Screen.width - mouseScrollLimits.RightLimit)&& Input.mousePosition.x < (Screen.width + 5)) ||
			(Input.mousePosition.y < mouseScrollLimits.BottomLimit && Input.mousePosition.y > -5) ||
			(Input.mousePosition.y > (Screen.height - mouseScrollLimits.TopLimit) && Input.mousePosition.y < (Screen.height +5))){
			return true;
		} else {
			
			return false;
		}
	}
}
