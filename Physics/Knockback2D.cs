using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the knockback of an actor
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Knockback2D : MonoBehaviour
{
	[SerializeField] private float _knockbackReduction = 1f;
	private Rigidbody2D _rigidbody2D;
	
	void Awake ()
	{
		// Set up references
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	/// <summary>
	/// Apply a knockback force on this object
	/// </summary>
	/// <param name="knockback">The direction of the knockback force, will be normalized internally</param>
	public void ApplyKnockback(Vector2 knockback, float magnitude)
	{
		knockback = knockback.normalized;
		_rigidbody2D.AddForce(knockback * magnitude * _knockbackReduction, ForceMode2D.Impulse);
	}

}
