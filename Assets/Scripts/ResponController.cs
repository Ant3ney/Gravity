using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponController : MonoBehaviour {
    public Level_Manager Levels;
    public bool Level1 = false;
    public bool Level2 = false;
    public bool Level3 = false;
    public bool LevelEndurance = false;
    public bool LevelStartreck = false;
    public bool Level4 = false;
    public bool Level5 = false;
    public bool Level6 = false;
    // Use this for initialization
    void Start () {
        Levels = FindObjectOfType<Level_Manager>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Level1 == true)
        {
            Level_Manager.WichLevel = "Level_01";
        }
        if (Level2 == true)
        {
            Level_Manager.WichLevel = "Level_02";
        }
        if (Level3 == true)
        {
            Level_Manager.WichLevel = "Level_03";
        }
        if (LevelEndurance == true)
        {
            Level_Manager.WichLevel = "Level_EnduranceBossFight";
        }
        if (Level4 == true)
        {
            Level_Manager.WichLevel = "Level_04";
        }
        if (Level5 == true)
        {
            Level_Manager.WichLevel = "Level_05";
        }
        if (Level6 == true)
        {
            Level_Manager.WichLevel = "Level_06";
        }
        if (LevelStartreck == true)
        {
            Level_Manager.WichLevel = "Level_StarTreckBoss";
        }
    }
}
