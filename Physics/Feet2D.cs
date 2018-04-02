using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages collision with the ground for an actor.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Feet2D : MonoBehaviour
{
	public bool onGround = false;

	private void Awake()
	{
		// Make sure the associated collider is a trigger.
		GetComponent<Collider2D>().isTrigger = true;
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.isStatic)
		{
			onGround = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other..gameObject.isStatic)
		{
			onGround = false;
		}
	}
	
	/// <summary>
	/// Check wether the associated feet GameObject is currently touching a GameObject tagged as "Static"
	/// </summary>
	/// <returns>A boolean representing if the associated feet GameObject is on the ground or not.</returns>
	public bool OnGround()
	{
		return onGround;
	}
}
