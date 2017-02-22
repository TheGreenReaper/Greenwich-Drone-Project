using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSoundAfterTime : MonoBehaviour {
    public AudioClip[] sounds;
	// Use this for initialization
	void Start () {
        Invoke("ActivateSound", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ActivateSound()
    {
        GetComponent<AudioSource>().enabled = true;
        GetComponent<AudioSource>().clip = sounds[Random.Range(0, sounds.Length)];
        GetComponent<AudioSource>().Play();
        Invoke("ActivateSound", Random.Range(10,15));
    }
}
