using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the GUI Hp bar
/// </summary>
public class HpBar : MonoBehaviour
{
	private Image _image;
	private Hp _playerHp;

	private void Awake ()
	{
		// Set up references
		_image = GetComponent<Image>();
		_playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<Hp>();
	}

	private void Update ()
	{
		// Set the fill of the Hp bar according to the current Hp of the player.
		_image.fillAmount = _playerHp.GetHp() / _playerHp.GetMaxHp();
	}
}
