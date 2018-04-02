using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the knockback of an actor
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Knockback : MonoBehaviour
{
	[SerializeField] private float _knockbackReduction = 1f;
	private Rigidbody _rigidbody;
	
	void Awake ()
	{
		// Set up references
		_rigidbody = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// Apply a knockback force on this object
	/// </summary>
	/// <param name="knockback">The direction of the knockback force, will be normalized internally</param>
	public void ApplyKnockback(Vector3 knockback, float magnitude)
	{
		knockback = knockback.normalized;
		_rigidbody.AddForce(knockback * magnitude * _knockbackReduction, ForceMode.Impulse);
	}

}
