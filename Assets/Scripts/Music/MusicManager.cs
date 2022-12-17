using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager Marathon = null;
    public MusicStoping Stopper;
    public AudioSource Levels1To3;
    public AudioClip EnduranceBossFightMarrathon;
    // Use this for initialization
    public void Awake()
    {
        if (Marathon != null)
        {
            Destroy(Marathon.gameObject);
        }
                    
    }
    void Start()
    {        
        Marathon = this;
        GameObject.DontDestroyOnLoad(gameObject);               
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void AudioChanger(AudioClip DiffrentAudio, int WichTrack)
    {
        if (WichTrack == 2)
        {
            Levels1To3.Stop();
            Levels1To3.clip = DiffrentAudio;
            Levels1To3.Play();
        }
    }
}
