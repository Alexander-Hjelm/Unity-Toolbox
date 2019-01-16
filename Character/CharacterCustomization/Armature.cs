using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Armature : MonoBehaviour
{
	[SerializeField] private bool _isRootBone;
	
	private Armature targetArmature;
	private Dictionary<string, Transform> _bonesByName = new Dictionary<string, Transform>();
	
	private void Awake()
	{
		foreach (Transform boneTransform in GetComponentsInChildren<Transform>())
		{
			if (boneTransform != transform)
			{
				_bonesByName.Add(boneTransform.name, boneTransform);
			}
		}

		if (_isRootBone)
		{
			_bonesByName.Add(name, transform);
		}
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

	public void SetTargetArmature(Armature targetArmature)
	{
		this.targetArmature = targetArmature;

		// Armatures match exactly check
		Assert.IsTrue(ArmatureExactMatch(this, targetArmature));
	}

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
