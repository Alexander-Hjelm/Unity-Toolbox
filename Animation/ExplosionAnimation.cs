using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the initial force of a pickup object randomly to create a "loot explosion" effect
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class ExplosionAnimation : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private float magnitude = 3f;	// Exlopsion force magnitude

	private void Awake()
	{
		// Set up references
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	private void OnEnable ()
	{
		// Apply a random force, always with y >= 0 to never send the pickup into the ground.
		Vector3 force = new Vector3(Random.Range(-1f,1f), 1f, Random.Range(-1f,1f)).normalized;
		_rigidbody.AddForce(magnitude * force, ForceMode.Impulse);
	}
}
