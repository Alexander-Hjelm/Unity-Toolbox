using UnityEngine;
using System.Collections;

public class LookTargetPos : MonoBehaviour {

	[SerializeField] private GameObject targetObj;

	// Update is called once per frame
	void Update () {
	
		transform.LookAt (targetObj.transform.position);
	}
}
