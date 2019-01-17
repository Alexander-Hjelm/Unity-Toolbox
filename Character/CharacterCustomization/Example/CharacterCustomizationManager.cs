using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Animator))]
public class CharacterCustomizationManager : MonoBehaviour
{
	[Serializable]
	private class ClothingSlotContainer
	{
		public ClothingItem.ClothingSlot Slot;
		public ClothingItem[] ClothingItems;
		[NonSerialized] public int currentIndex = -1;
	}

	private static CharacterCustomizationManager _instance;

	[SerializeField] private ClothingSlotContainer[] _clothingSlots;

	private Character _characterCustomized;
	private static Dictionary<ClothingItem.ClothingSlot, ClothingSlotContainer> _clothingContainersBySlot = new Dictionary<ClothingItem.ClothingSlot, ClothingSlotContainer>();
	
	private void Awake()
	{
		_instance = this;
		foreach (ClothingSlotContainer clothingSlot in _clothingSlots)
		{
			_clothingContainersBySlot.Add(clothingSlot.Slot, clothingSlot);
		}
	}

	public static void SetCharacter(Character character)
	{
		_instance._characterCustomized = character;
	}

	public static void Scroll(ClothingItem.ClothingSlot slot, int offset)
	{
		Assert.IsNotNull(_instance._characterCustomized);
		ClothingSlotContainer clothingSlotContainer = _clothingContainersBySlot[slot];
		clothingSlotContainer.currentIndex += offset;
		clothingSlotContainer.currentIndex %= clothingSlotContainer.ClothingItems.Length;
		if (clothingSlotContainer.currentIndex < 0)
			clothingSlotContainer.currentIndex = clothingSlotContainer.ClothingItems.Length + clothingSlotContainer.currentIndex;
		_instance._characterCustomized.SetClothingItem(slot, clothingSlotContainer.ClothingItems[clothingSlotContainer.currentIndex]);
	}
	
	
	

}
