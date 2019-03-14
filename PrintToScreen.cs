using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintToScreen : MonoBehaviour
{
	[SerializeField] private Text _debugText;
	[SerializeField] private float _messageDisplayTime = 2f;
	
	private static PrintToScreen _instance;

	private void Awake()
	{
		_instance = this;
		_debugText.text = "";
	}

	public static void Print(string msg)
	{
		_instance._debugText.text = msg;
		_instance.StopAllCoroutines();
		_instance.StartCoroutine(_instance.ResetText());
	}

	private IEnumerator ResetText()
	{
		yield return new WaitForSeconds(_messageDisplayTime);
		_debugText.text = "";
	}
}
