using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger1point5 : MonoBehaviour {
    public PlayerControler Shudle;
    public Level_Manager ChangeLevel;
    public Text Inputer;
    public static int TextAdder = 1;
    public static bool NextStoper = true;
    public bool InHirarkey = false;
    // Use this for initialization
    void Start () {
        TextAdder = 1;
        Inputer = GetComponent<Text>();
        Shudle = GameObject.FindObjectOfType<PlayerControler>();
        ChangeLevel = GameObject.FindObjectOfType<Level_Manager>();
        PlayerControler.TextLevel2 = true;
        PlayerControler.TextLevel = true;
        if(InHirarkey == true)
        {
            NextStoper = false;
        }
        initTextSize();
    }
	
	// Update is called once per frame
	void Update () {
        print("TextAdder = " + TextAdder);
		if (TextAdder == 1)
        {
            Inputer.text = "Matt Kowalski:You plan to kill us in space for this!";
        }
        if (TextAdder == 2)
        {
            Inputer.text = "Cooper: If we allowed everyone to live who broke our capital law, space would be a lawless wasteland!";
        }
        if (TextAdder == 3)
        {
            Inputer.text = "Matt Kowalski: Space is deadly enough! Why are you inforcing a death penalty!";
        }
        if (TextAdder == 4)
        {
            Inputer.text = "Cooper: Enough! Murph send in the rest of our destroyers!";
        }
        if (TextAdder == 5)
        {
            ChangeLevel.TutorialOver();
        }
    }

    void initTextSize()
    {
        //Screen.width
        int screenWidth = Screen.width;
        if (screenWidth < 1200)
        {
            Inputer.fontSize = 16;
        }
        else if (screenWidth < 1500)
        {
            Inputer.fontSize = 30;
        }
    }
}
