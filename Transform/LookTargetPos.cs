using UnityEngine;
using System.Collections;

public class LookTargetPos : MonoBehaviour {

	[SerializeField] private Vector3 targetPos;

	// Update is called once per frame
	void Update () {
	
		transform.LookAt (targetPos);
	}
}
