using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class RaycastUtils {

	public static RaycastHit RaycastFromCam(Vector3 point)
	{
		Ray ray = Camera.main.ScreenPointToRay(point);
		RaycastHit hit;
		
		Physics.Raycast(ray, out hit, 100);
		
		//Debug.Log (hit.collider.tag);
		return (hit);
	}
}