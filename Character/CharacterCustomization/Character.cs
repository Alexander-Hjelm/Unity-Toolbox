using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Character : MonoBehaviour
{
	private Dictionary<ClothingItem.ClothingSlot, ClothingItem> _clothingItems = new Dictionary<ClothingItem.ClothingSlot, ClothingItem>();
	private Armature _armature;

	private void Awake()
	{
		_armature = GetComponentInChildren<Armature>();
		Assert.IsNotNull(_armature);
	}

	public void SetClothingItem(ClothingItem.ClothingSlot slot, ClothingItem clothingItem)
	{
		if (_clothingItems.ContainsKey(slot))
		{
			ClothingItem currentIten = _clothingItems[slot];
			Destroy(currentIten.gameObject);
		}
		ClothingItem newItem = Instantiate(clothingItem, transform.position, transform.rotation);
		newItem.SetTargetArmature(_armature);
		_clothingItems[slot] = newItem;
	}
}
