using UnityEngine;
using System.Collections;

public class UrlOpen : MonoBehaviour {

	public void OpenUrl(string url)
	{
		//Application.OpenURL (url);
        Application.ExternalEval("window.open('http://alexander-hjelm.com','Alexander Hjelm')");
        Debug.Log ("Opening " + url);
	}
}