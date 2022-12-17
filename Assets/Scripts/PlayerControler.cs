using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControler : MonoBehaviour {
    public Vector2 Move;
    public GameObject Shudle;
    public Animator Reaction;
    public int Speed;
    public float extra_Space;
    float xmin = -8.36f;
    float xmax = 8.36f;
    public float BeamSpeed;
    public GameObject Beams;
    public GameObject Rotater;
    public bool test;
    public float FireRate;
    public float times;
    public float ExtraDistance;
    public bool EnemyOrNot = false;
    public static int Hits;
    public static int MaxHits = 3;
    public GameObject Explotion;
    public float DeathTimmer;
    public static bool DeathTimmerOn = false;
    Level_Manager Change;
    public  float Perccents2 = 1;
    public  float Perccents1;
    private HealthUI Health;
    public static float Perccents3;
    public GameObject Healthui;
    public ShiHitDecection L;
    public AudioClip BeamSoundEffect;
    public float MoveToCenterSpeed = 2;
    public bool CanMove = true;
    public static bool TextLevel = false;
    public static bool TextLevel2;
    public static bool TextLevelTutorialMoving = true;
    public bool RealLevelOn = true;
    public TextChanger Instance;
    public AudioClip Hit;
    public AudioClip Destroyed;

    void Start () {
        DeathTimmerOn = false;
        Hits = 0;
        Health = GameObject.FindObjectOfType<HealthUI>();
        GetComponent<HealthUI>();
        Reaction.GetComponent<Animator>();
        float Distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 Leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Distance));
        Vector3 Rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Distance));
        xmin = Leftmost.x + extra_Space;
        xmax = Rightmost.x - extra_Space;        
        if (RealLevelOn == true)
        {
           TextLevelTutorialMoving = true;
        }        
    }
	void fireing()
    {
        AudioSource.PlayClipAtPoint(BeamSoundEffect, transform.position);
        Instantiate(Beams, Beams.transform.position = new Vector3(this.transform.position.x, transform.position.y + 0.80f, 0), Rotater.transform.rotation);
    }	
	void Update ()
    {                                            
        RoundControll();
        Moves();                
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, (transform.position.y), transform.position.z);        
	}
    void Moves()
    {
        times = times + (1 * Time.deltaTime);
        if ((Input.GetButton("Fire1")) && (times >= FireRate) && ((RealLevelOn == true) ))
        {
            fireing();
            times = 0;
        }
        Reaction.GetComponent<Animator>();
        if (((Input.GetKey(KeyCode.D)) && (TextLevelTutorialMoving == false)) || ((RealLevelOn == true) && (Input.GetKey(KeyCode.D))))
        {
            Shudle.transform.position = Shudle.transform.position + new Vector3(Speed * Time.deltaTime, 0, 0);
            Reaction.SetBool("TurningRight", true);
            Reaction.SetBool("TurningLeft", false);
        }
        else if ((Input.GetKey(KeyCode.A))  && (TextLevelTutorialMoving == false) || ((RealLevelOn == true) && (Input.GetKey(KeyCode.A))))
        {
            Shudle.transform.position = Shudle.transform.position + new Vector3(-Speed * Time.deltaTime, 0, 0);
            Reaction.SetBool("TurningLeft", true);
            Reaction.SetBool("TurningRight", false);
        }
        else
        {
            Reaction.SetBool("TurningRight", false);
            Reaction.SetBool("TurningLeft", false);
        }
        

    }
    void OnTriggerEnter(Collider col)
    {
        AudioSource.PlayClipAtPoint(Hit, transform.position);
        Instantiate(Explotion, Explotion.transform.position = this.transform.position, Rotater.transform.rotation);
        Destroy(col.gameObject);
        Hits += 1;
        if (Hits >= MaxHits)
        {
            DeathTimmerOn = true;
            DestroyObject(this.gameObject);
            AudioSource.PlayClipAtPoint(Destroyed, transform.position);

        }
        Health.HealthBar();


    }
    public static void tests()
    {
        print("Why");
    }
    public void RoundControll()
    {
        if ((EnemySpawner.RoundsDone == 2) && (Shudle.transform.position.x > 0))
        {
            Shudle.transform.position = Shudle.transform.position - new Vector3(15 * Time.deltaTime, 0, 0);
            CanMove = false;
            print("InProgress");
        }
        if ((EnemySpawner.RoundsDone == 2) && (Shudle.transform.position.x < 0))
        {
            Shudle.transform.position = Shudle.transform.position + new Vector3(15 * Time.deltaTime, 0, 0);
            CanMove = false;
            print("InProgress");
        }
        if ((EnemySpawner.RoundsDone == 2) && ((Shudle.transform.position.x < 0.5f) && (Shudle.transform.position.x > -0.5f)))
        {
            CanMove = false;
            Shudle.transform.position = new Vector3(0, transform.position.y, transform.position.z);
            EnemySpawner.WinRoundWait = true;
            print("Ready");
        }
    }
}
