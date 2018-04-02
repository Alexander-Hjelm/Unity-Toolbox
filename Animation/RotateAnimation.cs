using UnityEngine;
using System.Collections;

public class RotateAnimation : MonoBehaviour {
	
	[SerializeField] float rotateSpeed = 5f;
	[SerializeField] Vector3 axis;
	
	void Update () {
		transform.Rotate (axis.normalized*rotateSpeed*Time.deltaTime);
	}
}
