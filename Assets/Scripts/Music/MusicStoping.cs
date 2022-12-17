using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStoping : MonoBehaviour {
    public MusicManager Music;
    public AudioClip EnduranceFight;
    // Use this for initialization
    void Start ()
    {
        Music = FindObjectOfType<MusicManager>();
        Music.AudioChanger(EnduranceFight, 2);
    }	
	// Update is called once per frame
	void Update ()
    {		

	}
}
