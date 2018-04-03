using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Manages a GUI bar. Remember to set the getValue and getMaxValue delegates.
/// </summary>
public class GUIBar : MonoBehaviour
{
	public UnityEvent myAction;
	
	public delegate float GetValue();	
	private GetValue getValue;
	private GetValue getMaxValue;
	
	private Image _image;
	private Hp _playerHp;

	private void Awake ()
	{
		// Set up references
		_image = GetComponent<Image>();

		// Remember to set these
		getValue = 
		getMaxValue = 

	}

	private void Update ()
	{
		// Set the fill of the Hp bar according to the current Hp of the player.
		_image.fillAmount = getValue() / getMaxValue();
	}
}
