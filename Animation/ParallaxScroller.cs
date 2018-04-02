using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The ParallaxScroller component translates the GameObject with a factor that depends on the distance from
/// 	itself to the main camera, to create a parallax effect. Use it on background object.
/// </summary>
public class ParallaxScroller : MonoBehaviour
{
	[SerializeField] private float parallaxFactor;	// How much the object should move relative to the camera.
	private Camera camera;
	private Vector3 prevCamPos;	// The camera position from the previous frame.
	void Awake () {
		// Set up references
		camera = Camera.main;
	}

	void Update()
	{
		if (prevCamPos != null)
		{
			float delX = camera.transform.position.x - prevCamPos.x;
			transform.position += Vector3.right * delX * parallaxFactor;
		}

		prevCamPos = camera.transform.position;
	}
}
