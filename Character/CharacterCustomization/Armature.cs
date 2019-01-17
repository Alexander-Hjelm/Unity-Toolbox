using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/*
 * A class that defines the bone structure of a character. Must be placed on the root bone (one level above hips/pelvis).
 * 
 * Copyright (c) 2019 Alexander Hjelm
 * Part of the Unity-Toolbox repository
 * https://github.com/Alexander-Hjelm/Unity-Toolbox/
 */
public class Armature : MonoBehaviour
{	
	private Armature targetArmature;
	private Dictionary<string, Transform> _bonesByName = new Dictionary<string, Transform>();
	
	private void Awake()
	{
		// Add all transforms in children as bones
		foreach (Transform boneTransform in GetComponentsInChildren<Transform>())
		{
			if (boneTransform != transform)
			{
				_bonesByName.Add(boneTransform.name, boneTransform);
			}
		}
		_bonesByName.Add(name, transform);	// Add the root bone
	}

	private void Start()
	{
		UpdateBones();	// Update bone positions once so that they are already in place.
						// Otherwise they will spawn in T-pose and snap into place on the first Update.
	}

	private void Update()
	{
		UpdateBones();
	}

	/// <summary>
	/// Set the armature that this armature will follow. This will copy the bone transforms.
	/// </summary>
	/// <param name="targetArmature">The target armature.</param>
	public void SetTargetArmature(Armature targetArmature)
	{
		this.targetArmature = targetArmature;

		// Check that bone names match exactly
		Assert.IsTrue(ArmatureExactMatch(this, targetArmature));
	}

	/// <summary>
	/// Set position, rotation and scale of each bone to match the corresponding bone transform on the target armature.
	/// </summary>
	private void UpdateBones()
	{
		if (targetArmature)
		{
			foreach (string boneKey in _bonesByName.Keys)
			{
				_bonesByName[boneKey].position = targetArmature._bonesByName[boneKey].position;
				_bonesByName[boneKey].rotation = targetArmature._bonesByName[boneKey].rotation;
				_bonesByName[boneKey].localScale = targetArmature._bonesByName[boneKey].localScale;
			}
		}
	}

	/// <summary>
	/// Check if two armatures are exact copies, with respect to all bone names.
	/// </summary>
	/// <param name="a1">Armature 1</param>
	/// <param name="a2">Armature 2</param>
	/// <returns></returns>
	private bool ArmatureExactMatch(Armature a1, Armature a2)
	{
		foreach (string boneKey in a1._bonesByName.Keys)
		{
			if (!a2._bonesByName.ContainsKey(boneKey))
			{
				return false;
			}
		}
		
		foreach (string boneKey in a2._bonesByName.Keys)
		{
			if (!a1._bonesByName.ContainsKey(boneKey))
			{
				return false;
			}
		}

		return true;
	}
}
