using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeScrollAnimation : MonoBehaviour
{
	[SerializeField] private Vector3 dir;
	[SerializeField] private float dist;
	[SerializeField] private float speed;
	private Vector3 startPos;

	private void Awake()
	{
		startPos = transform.position;
	}

	private void Update () {
		if ((startPos - transform.position).magnitude < dist) {
			transform.position += dir.normalized * speed * Time.deltaTime;
		}
	}
}
