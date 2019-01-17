using UnityEngine;

/*
 * A class that describes a clothing item that can be applied to a Character.
 * The clothing item gameObject must contain a bone structure that matches the associated character,
 * where every single bone name matches exactly.
 * 
 * Copyright (c) 2019 Alexander Hjelm
 * Part of the Unity-Toolbox repository
 * https://github.com/Alexander-Hjelm/Unity-Toolbox/
 */
public class ClothingItem : MonoBehaviour {

	// All the possible slots that a clothing item can be applied to. Add more slots as required.
	public enum ClothingSlot
	{
		TORSO,
		LEGS,
		HEAD
		// etc...
	}

	private Armature _armature; 	// The bone structure

	private void Awake()
	{
		// Get armature component among children.
		_armature = GetComponentInChildren<Armature>();
		if (!_armature)
		{
			Debug.LogError(name + ": Could not find an armature component. Please add one to the child that is the root bone.");
		}
	}

	/// <summary>
	/// Set the armature that this clothing item will follow. This will copy the bone transforms.
	/// </summary>
	/// <param name="armature">The target armature.</param>
	public void SetTargetArmature(Armature armature)
	{
		_armature.SetTargetArmature(armature);
	}

}
