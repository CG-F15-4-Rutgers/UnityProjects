using UnityEngine;
using System.Collections;

public class MouseSelection1 : MonoBehaviour {
	RaycastHit hit;
	
	
	private float moveSpeed = 0.1f;
	public static GameObject CurrentlySelectedUnit;
	private Transform singleTarget;
	
	
	
	private static Vector3 mousePoint;
	
	void Update()
	{   
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			if (Input.GetMouseButtonDown (0)) { 
				mousePoint = hit.point;
			}           
			
			
			if (Input.GetKeyDown("space")) {
				singleTarget.transform.position = hit.point;
			} else if (Input.GetMouseButtonUp(0) && LeftMouseClicked(mousePoint)) {
				Deselect();
			}
			
			if(Input.GetMouseButtonUp(0) && LeftMouseClicked(mousePoint))
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
						//Debug.Log(hit.collider.transform.parent.gameObject.transform.GetChild(0));
						singleTarget = hit.collider.transform.parent.gameObject.transform.GetChild(0);
					}
					
				}else {
					Deselect();
				}
			}
			
		} else {
			if(Input.GetMouseButtonUp(0) && LeftMouseClicked(mousePoint))
			{
				Deselect();
			}
		}
	
		if (CurrentlySelectedUnit.tag == "Mov_Obj") {
		
			if (Input.GetKey (KeyCode.UpArrow)) {
				CurrentlySelectedUnit.transform.Translate (0.0f, 0.0f, moveSpeed);   
			}
		
			if (Input.GetKey (KeyCode.DownArrow)) {
				CurrentlySelectedUnit.transform.Translate (0.0f, 0.0f, -moveSpeed);  
			}
		
			if (Input.GetKey (KeyCode.LeftArrow)) {
				CurrentlySelectedUnit.transform.Translate (-moveSpeed, 0.0f, 0.0f);  
			}
		
			if (Input.GetKey (KeyCode.RightArrow)) {
				CurrentlySelectedUnit.transform.Translate (moveSpeed, 0.0f, 0.0f);   
			}
		}

	}
	
	public bool LeftMouseClicked(Vector3 hitPoint)
	{
		float clickRadius = 1.3f;
		
		if(
			( mousePoint.x < hitPoint.x + clickRadius && mousePoint.x > hitPoint.x - clickRadius) &&
			( mousePoint.y < hitPoint.y + clickRadius && mousePoint.y > hitPoint.y - clickRadius) &&
			( mousePoint.z < hitPoint.z + clickRadius && mousePoint.z > hitPoint.z - clickRadius) 
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
			
		}   
	}
}