using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour {
    ShiHitDecection Spawning;
    public GameObject Explotion;
    public PlayerControler LooseCondition;
    public float DeathTimmer;
    public bool DeathStart;
    public bool RoundWaidCheck = false;
    public static string WichLevel;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (PlayerControler.DeathTimmerOn == true)
        {
            DeathTimmer += (1 * Time.deltaTime);
            if (DeathTimmer >= 2)
            {
                Lose();
                print("Dead");
            }
        }
        Counts();
        
    }
    
    public void LoadLevel (string name)
    {
        Application.LoadLevel (name);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Counts()
    {
       
        if ((EnemySpawner.RoundsDone == 2) && (EnemySpawner.WinRoundWait == true))
        {
            EnemySpawner.EnemyCounter = 0;
            Application.LoadLevel(Application.loadedLevel + 1);
            EnemySpawner.RoundsDone = EnemySpawner.RoundsDone * 0;
            EnemySpawner.RoundsDone = 0;
            PlayerControler.MaxHits = 3;
            EnemySpawner.WinRoundWait = false;
            
        }
    }
    public void Lose()
    {
        EnemySpawner.EnemyCounter = 0;
        PlayerControler.Hits = 0;
        Application.LoadLevel("Lose");
        

    }
    public void test()
    {

    }
    public void NextText()
    {
        if ((TextChanger.NextStoper == false) || (TextChanger1point5.NextStoper == false))
        {
            TextChanger.TextAdder += 1;
            TextChanger1point5.TextAdder += 1;
        }        
    }
    public void TutorialOver()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void ReplayLevel()
    {
        Application.LoadLevel(WichLevel);
    }
    public void LastLevelDone(string name)
    {
        Application.LoadLevel(name);
    }


}
