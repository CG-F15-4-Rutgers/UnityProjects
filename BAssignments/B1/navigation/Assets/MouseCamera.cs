using UnityEngine;
using System.Collections;

public class MouseCamera : MonoBehaviour {
	RaycastHit hit;
	
	
	private float moveSpeed = 0.1f;
	public static GameObject CurrentlySelectedUnit;
	GameObject CurrTarget;

	//public GameObject CurrTarget;
	
	private static Vector3 mouseDownPoint;

	
	void Update()
	{	
		CurrTarget = GameObject.Find ("Target");
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		
		
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			if (Input.GetMouseButtonDown (0)) { 
				mouseDownPoint = hit.point;
			}			
			
			
			if (Input.GetMouseButtonDown (1)) {
				CurrTarget.transform.position = hit.point;
			} else if (Input.GetMouseButtonUp(0) && LeftMouseClicked(mouseDownPoint)) {
				Deselect();
			}
			
			if(Input.GetMouseButtonUp(0) && LeftMouseClicked(mouseDownPoint))
			{
				if(hit.collider.transform.FindChild ("Selected"))
				{

					if(CurrentlySelectedUnit != hit.collider.gameObject)
					{
						
						GameObject SelectedObj = hit.collider.transform.FindChild("Selected").gameObject;
						SelectedObj.SetActive(true);



						if(CurrentlySelectedUnit != null){
							CurrentlySelectedUnit.transform.FindChild ("Selected").gameObject.SetActive(false);
						}
						
						CurrentlySelectedUnit = hit.collider.gameObject;
					}
					
				}else {
					Deselect();
				}
			}
			
		} else {
			if(Input.GetMouseButtonUp(0) && LeftMouseClicked(mouseDownPoint))
			{
				Deselect();
			}
		}
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			CurrentlySelectedUnit.transform.Translate(0.0f, 0.0f, moveSpeed);	
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			CurrentlySelectedUnit.transform.Translate(0.0f, 0.0f, -moveSpeed);	
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			CurrentlySelectedUnit.transform.Translate(-moveSpeed, 0.0f, 0.0f);	
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			CurrentlySelectedUnit.transform.Translate(moveSpeed, 0.0f, 0.0f);	
		}
	}

	public bool LeftMouseClicked(Vector3 hitPoint)
	{
		float clickRadius = 1.3f;
		
		if(
			( mouseDownPoint.x < hitPoint.x + clickRadius && mouseDownPoint.x > hitPoint.x - clickRadius) &&
			( mouseDownPoint.y < hitPoint.y + clickRadius && mouseDownPoint.y > hitPoint.y - clickRadius) &&
			( mouseDownPoint.z < hitPoint.z + clickRadius && mouseDownPoint.z > hitPoint.z - clickRadius) 
			){
			return true;
		}else {
			return false;
		}
	}

	public static void Deselect()
	{
		if (CurrentlySelectedUnit != null) {
			
			CurrentlySelectedUnit.transform.FindChild("Selected").gameObject.SetActive(false);
			CurrentlySelectedUnit = null;
		}	
	}
}