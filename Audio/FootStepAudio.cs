using UnityEngine;
using System.Collections;

public class FootStepHandler : MonoBehaviour {

	public GameObject particle_prefab;
	public AudioClip sound;

	void Start()
	{
		audio.clip = sound;
	}

	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		GameObject.Instantiate (particle_prefab, transform.position, Quaternion.identity);
		audio.pitch = Random.Range(0.8f, 1.0f);
		audio.Play();
	}
}
