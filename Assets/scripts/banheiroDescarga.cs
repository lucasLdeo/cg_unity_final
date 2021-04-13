using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banheiroDescarga : MonoBehaviour {
    AudioSource audioData;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void PlaySong () {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

    }
}
