using UnityEngine;
using UnityEngine.UI;

/*
 * Example script for Unity-Toolbox/CharacterCustomization
 */
public class Setup : MonoBehaviour
{
	[SerializeField] private Character _characterToCustomize;
	[SerializeField] private Button _buttonLeft;
	[SerializeField] private Button _buttonRight;

	private void Start()
	{
		CharacterCustomizationManager.SetCharacter(_characterToCustomize);
		_buttonLeft.onClick.AddListener( () => CharacterCustomizationManager.Scroll(ClothingItem.ClothingSlot.TORSO, -1));
		_buttonRight.onClick.AddListener( () => CharacterCustomizationManager.Scroll(ClothingItem.ClothingSlot.TORSO, 1));
	}
}
