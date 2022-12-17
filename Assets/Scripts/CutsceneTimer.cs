using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTimer : MonoBehaviour {
    public float timer;
    public float timerEnd;
    Level_Manager Level;
    public bool last = false;
    // Use this for initialization
    void Start () {
        Level = FindObjectOfType<Level_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += (1 * Time.deltaTime);
        if ((timer>= timerEnd) && (last == false))
        {
            Level.TutorialOver();
        }
        if ((timer >= timerEnd) && (last == true))
        {
            Level.LastLevelDone("Main_Menu");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer += 1000;
        }
	}
}
