using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {
    public Text Inputer;
    public static int TextAdder = 1;
    public Image BackroundBlue;
    public float TimmerControllsTurotial;
    public bool TimmerStartControllsTurotial = false;
    public float TimmerControllsTutorialLength = 3;
    public PlayerControler Shudle;
    public static bool NextStoper = false;
    public float TimmerControllsTurotial2;
    public bool TimmerStartControllsTurotial2 = false;
    public float TimmerControllsTutorialLength2 = 1f;
    public Level_Manager ChangeLevel;
    public static bool IsfakeGame = false;
    public GameObject Beams;
    public int NumberOfShots = 1;
    public AudioClip BeamSoundEffect;
    public bool DidShoot = false;
    public GameObject Rotator;

    // Use this for initialization
    private void Awake()
    {
        IsfakeGame = true;
    }
    void Start () {
        Inputer = GetComponent<Text>();
        Shudle = GameObject.FindObjectOfType<PlayerControler>();
        ChangeLevel = GameObject.FindObjectOfType<Level_Manager>();
        PlayerControler.TextLevel2 = true;
        PlayerControler.TextLevel = true;
        initTextSize();
    }
	
	// Update is called once per frame
	void Update ()
    {        
		if (TextAdder == 1)
        {
            Inputer.text = "Matt Kowalski: Rhyan. Take hold of the controls! I'm going to replicate what you did earlier."; 
        }
        if (TextAdder == 2)
        {
            Inputer.text = "Dr.Rhyan Stone: I'm not a pilot. But here goes!";
        }
        if (TextAdder == 3)
        {
            Inputer.text = "Matt Kowalski: Trust me we'll be fine. We survived worse before!";
        }
        if (TextAdder == 4)
        {
            Inputer.text = "Matt Kowalski: Ready! Take Control!";
        }
        if (TextAdder == 5)
        {
            NextStoper = true;
            Inputer.text = "PRESS A TO TURN LEFT. PRESS D TO TURN RIGHT.";
            PlayerControler.TextLevelTutorialMoving = false;
            if (Input.GetKeyDown(KeyCode.A))
            {
                hideTutorialUI();
                TimmerStartControllsTurotial = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                hideTutorialUI();
                TimmerStartControllsTurotial = true;
            }
            if (TimmerStartControllsTurotial == true)
            {
                TimmerControllsTurotial += (1 * Time.deltaTime);
                if (TimmerControllsTurotial >= TimmerControllsTutorialLength)
                {
                    PlayerControler.TextLevelTutorialMoving = true;
                    if (Shudle.transform.position.x > 0)
                    {
                        Shudle.transform.position = Shudle.transform.position - new Vector3(15 * Time.deltaTime, 0, 0);                                               
                    }
                    if (Shudle.transform.position.x < 0)
                    {
                        Shudle.transform.position = Shudle.transform.position + new Vector3(15 * Time.deltaTime, 0, 0);
                                                
                    }
                    if ((Shudle.transform.position.x < 0.5f) && (Shudle.transform.position.x > -0.5f))

                    {
                        showTutorialUI();
                        Shudle.transform.position = new Vector3(0, -3.77f, 0);
                        TimmerStartControllsTurotial = true;
                        TextAdder += 1;
                        NextStoper = false;

                    }
                }
            }
        }
        if (TextAdder == 6)
        {
            PlayerControler.TextLevelTutorialMoving = true;
            Inputer.text = "Dr.Rhyan Stone: Wow! Surprisingly intuitive and easy to control!";
        }
        if (TextAdder == 7)
        {
            Inputer.text = "Matt Kowalski: Sure is! It Makes me wonder why I needed training to become a pilot.";
        }
        if (TextAdder == 8)
        {
            Inputer.text = "Matt Kowalski: Rhyan. I'm no expert but is it safe to short circit the ship's central exhaust compartment.";
        }
        if (TextAdder == 9)
        {
            Inputer.text = "Dr.Rhyan Stone: We'll be fine but it may rattle the ship a little.";
        }
        if (TextAdder == 10)
        {
            Inputer.text = "Matt Kowalski: Say your prayers.";
        }
        if (TextAdder == 11)
        {
            NextStoper = true;
            if (NextStoper == true)
            {
                Inputer.text = "PRESS MOUSE 1 TO SHORT CIRCIT SHIP EXHAUST COMPARTMENT";
                PlayerControler.TextLevel2 = true;
                PlayerControler.TextLevel = true;
                ShootingTutorial();
            }
            
            
            
            
            
 
        }
        if (TextAdder == 12)
        {
            Inputer.text = "Dr.Rhyan Stone: Dam! \nI underestimated the power of the ships exhaust!";
        }
        if (TextAdder == 13)
        {
            Inputer.text = "Matt Kowalski: I told you. Say your prayers.";
        }
        if (TextAdder == 14)
        {
            Inputer.text = "Dr.Rhyan Stone: The ship must have been compressing large amounts of C02 while we...";
        }
        if (TextAdder == 15)
        {
            Inputer.text = "Matt Kowalski: Hold that thought. There's something on the radar! I Don't believe it!";
        }
        if (TextAdder == 16)
        {
            ChangeLevel.TutorialOver();
        }


        

    }

    void initTextSize() {
        //Screen.width
        int screenWidth = Screen.width;
        if (screenWidth < 1200)
        {
            Inputer.fontSize = 16;
        } else if (screenWidth < 1500){
            Inputer.fontSize = 30;
        }
    }

    void hideTutorialUI()
    {
        BackroundBlue.enabled = false;
        Inputer.enabled = false;
    }
    void showTutorialUI()
    {
        BackroundBlue.enabled = true;
        Inputer.enabled = true;

    }

    void ShootingTutorial()
    {
        PlayerControler.TextLevel2 = false;
        NextStoper = true;
        
        
        if (Input.GetButtonDown("Fire1"))
        {
            DidShoot = true;
            hideTutorialUI();
            TimmerStartControllsTurotial2 = true;
            if (NumberOfShots == 1)
            {
                
                Instantiate(Beams, Beams.transform.position = new Vector3(0, -3.5f, 0), transform.rotation);
                AudioSource.PlayClipAtPoint(BeamSoundEffect, Beams.transform.position = new Vector3(0, -3.5f, 0));
                NumberOfShots += 1;
                print("BeamShot");
            }
            
        }
        if (DidShoot == true)
        {
            TimmerControllsTurotial2 += (1 * Time.deltaTime);
        }
        if ((TimmerControllsTurotial2 > TimmerControllsTutorialLength) && (DidShoot == true))
        {

            showTutorialUI();
            NextStoper = false;
            TextAdder += 1;
            print("Working Screen");

        }

    }
    
}
