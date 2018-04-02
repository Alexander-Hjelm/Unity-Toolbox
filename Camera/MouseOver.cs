using UnityEngine;
using System.Collections;
using System;

public class MouseOver : MonoBehaviour {

    //Expose boolean mouseOver, which is true if the mouse is currently over the game object

    public bool mouseOver;

    private Ray ray;
    private RaycastHit hit;
    
	void FixedUpdate () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider coll in colliders)
            {
                if (coll.Equals(hit.collider)) {
                    mouseOver = true;
                    return;
                }
                mouseOver = false;
            }
        }
        else {
            mouseOver = false;
        }
	}
}