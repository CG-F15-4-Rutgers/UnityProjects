using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Director1 : MonoBehaviour
{
	private RaycastHit hit;
	bool isSelecting = false;
	Vector3 mousePosition1;
	private Transform CurrTarget;
	private List<Transform> selectedTargets;
	
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		Physics.Raycast (ray, out hit, Mathf.Infinity);
		
		if( Input.GetMouseButtonDown( 0 ) )
		{
			isSelecting = true;
			mousePosition1 = Input.mousePosition;
		}
		
		if( Input.GetMouseButtonUp( 0 ) )
		{
			var selectedObjects = new List<Agent1>();
			selectedTargets = new List<Transform>();
			foreach( var selectableObject in FindObjectsOfType<Agent1>() )
			{
				if( IsWithinSelectionBounds( selectableObject.gameObject ) )
				{
					selectedObjects.Add( selectableObject );
					CurrTarget = selectableObject.transform.parent.gameObject.transform.GetChild(0);
					selectedTargets.Add(CurrTarget);
					
				}
			}
			
			isSelecting = false;
		}
		
		if (Input.GetMouseButtonDown (1)) {
			foreach(var target in selectedTargets){
				target.transform.position = hit.point;
			}
		}
	}
	
	public bool IsWithinSelectionBounds( GameObject gameObject )
	{
		if( !isSelecting )
			return false;
		
		var camera = Camera.main;
		var viewportBounds = DrawRect1.GetViewportBounds( camera, mousePosition1, Input.mousePosition );
		return viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ) );
	}
	
	void OnGUI()
	{
		if( isSelecting )
		{
			var rect = DrawRect1.GetScreenRect( mousePosition1, Input.mousePosition );
			DrawRect1.DrawScreenRect( rect, new Color( 0.8f, 0.8f, 0.95f, 0.25f ) );
			DrawRect1.DrawScreenRectBorder( rect, 2, new Color( 0.8f, 0.8f, 0.95f ) );
		}
	}
}