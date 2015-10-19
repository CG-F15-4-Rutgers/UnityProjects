using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour
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
			var selectedObjects = new List<Agent>();
			selectedTargets = new List<Transform>();
			foreach( var selectableObject in FindObjectsOfType<Agent>() )
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
		
		if (Input.GetKeyDown("space")) {
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
		var viewportBounds = DrawRect.GetViewportBounds( camera, mousePosition1, Input.mousePosition );
		return viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ) );
	}
	
	void OnGUI()
	{
		if( isSelecting )
		{
			var rect = DrawRect.GetScreenRect( mousePosition1, Input.mousePosition );
			DrawRect.DrawScreenRect( rect, new Color( 0.8f, 0.8f, 0.95f, 0.25f ) );
			DrawRect.DrawScreenRectBorder( rect, 2, new Color( 0.8f, 0.8f, 0.95f ) );
		}
	}
}