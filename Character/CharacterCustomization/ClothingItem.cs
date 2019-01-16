using UnityEngine;
using UnityEngine.Assertions;

public class ClothingItem : MonoBehaviour {

	public enum ClothingSlot
	{
		TORSO,
		LEGS,
		HEAD
	}

	private Armature _armature;

	private void Awake()
	{
		_armature = GetComponentInChildren<Armature>();
		Assert.IsNotNull(_armature);
	}

	public void SetTargetArmature(Armature armature)
	{
		_armature.SetTargetArmature(armature);
	}

}
