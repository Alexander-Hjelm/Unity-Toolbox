using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the current music track being played
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
	[SerializeField] private AudioClip[] clips;	// Music tracks
	private AudioSource _audioSource;
	private int playing = 0;	// Index of current music track 
	
	void Awake ()
	{
		// Set up references
		_audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		// Switch to next clip in sequence
		if (Input.GetKeyDown(KeyCode.M))
		{
			playing = (playing + 1) % clips.Length;
			_audioSource.Stop();
			_audioSource.clip = clips[playing];
			_audioSource.Play();
		}
	}
}
