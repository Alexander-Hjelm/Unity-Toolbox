using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Disables the GameObject after a set amounts of seconds
/// </summary>
public class TimeToLive : MonoBehaviour
{
	[SerializeField] private float _ttl;
	
	void Start ()
	{
		Invoke("Disable", _ttl);
	}
	
	void Disable ()
	{
		Destroy(gameObject);
	}
}
