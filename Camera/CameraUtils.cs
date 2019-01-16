using UnityEngine;
using System.Collections;
using System;

public class CameraUtils : MonoBehaviour {
	public Vector3 mouse2WorldPos()
	{
		RaycastHit hit;
		Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
		return hit.point;
	}
}