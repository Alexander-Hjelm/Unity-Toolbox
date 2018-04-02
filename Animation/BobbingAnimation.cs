using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the constant "bobbing" effect of a pickup object to make it appear to be floating in the air
/// </summary>
public class BobbingAnimation : MonoBehaviour
{
	private Vector3 startPos;	// Initial transform.localPosition
	private float a = 0.2f;		// Bobbing amplitude
	private float w = 2f;		// Bobbing frequency
	private float d;		// Bobbing phase (offset)
	
	void Start ()
	{
		startPos = transform.localPosition;
		d = Random.RandomRange(0f, 2*Mathf.PI / w);	// Randomize offset
	}
	
	void Update ()
	{
		transform.localPosition = startPos + Vector3.up * a * Mathf.Sin(w * Time.time + d);
	}
}
