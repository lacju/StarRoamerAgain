//If you're rendering the tooltip over a 3D Object, make sure you attach this script to the object
//Also make sure the object has a collider

using UnityEngine;
using System.Collections;

public class MouseOnObject : MonoBehaviour
{
	[HideInInspector]
	public bool mouseOnObject = false;
	
	void Update ()
	{
		//Define the raycast variables
	    Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	    RaycastHit hit;
		
		//if the raycast hits, pass true to the bool, otherwise pass false
	    if (GetComponent<Collider>().Raycast (ray, out hit, 1000000))
	        mouseOnObject = true;
		else
			mouseOnObject = false;
	}
}