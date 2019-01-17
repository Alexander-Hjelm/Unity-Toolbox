using System.Collections.Generic;
using UnityEngine;

/*
 * A class that describes a character.
 * The character gameObject must contain an armature component on the root bone transform among its children.
 * 
 * Copyright (c) 2019 Alexander Hjelm
 * Part of the Unity-Toolbox repository
 * https://github.com/Alexander-Hjelm/Unity-Toolbox/
 */
public class Character : MonoBehaviour
{
	// The clothing items that are currently attached
	private Dictionary<ClothingItem.ClothingSlot, ClothingItem> _clothingItems = new Dictionary<ClothingItem.ClothingSlot, ClothingItem>();
	
	private Armature _armature;		// The bone structure

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
	/// Set the clothing item on the given slot.
	/// </summary>
	/// <param name="slot">The clothing slot</param>
	/// <param name="clothingItem">The ClothingItem that will be switched to</param>
	public void SetClothingItem(ClothingItem.ClothingSlot slot, ClothingItem clothingItem)
	{
		if (_clothingItems.ContainsKey(slot))
		{
			// Delete the old clothing item on this slot
			ClothingItem currentIten = _clothingItems[slot];
			Destroy(currentIten.gameObject);
		}
		
		// Create the new clothing item
		ClothingItem newItem = Instantiate(clothingItem, transform.position, transform.rotation);
		newItem.SetTargetArmature(_armature);
		_clothingItems[slot] = newItem;
	}
}
