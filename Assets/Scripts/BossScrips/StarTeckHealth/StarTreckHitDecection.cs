using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarTreckHitDecection : MonoBehaviour {
    
    int TotalHitpoints;
    public static int Shipsalive;
    public Level_Manager Changer;
    public int MaxHits;
    int Hits;
    public GameObject EnemyBeam;
    public bool EnemyOrNot = true;
    public float Timer;
    public float Timer2;
    public float Fireinterval;
    public float Fireinterval2;
    public float ShootLength;
    public GameObject Rotater;
    public PlayerControler Play;
    public bool Respon = false;
    public GameObject Explotion;
    public AudioClip EnemyFire;
    public GameObject Player;
    StarTreckHealthUI Health;
    public bool CanShoot;
    public AudioClip EnemyDeystroyed;
    public AudioClip EnemyHit;
    // Use this for initialization
    void Start () {
        Health = GameObject.FindObjectOfType<StarTreckHealthUI>();
        Shipsalive++;
        Changer = FindObjectOfType<Level_Manager>();
        Player = GameObject.Find("Shuttle");
	}
	
	// Update is called once per frame
	void Update () {
        FireAsorter();
        Vector3 RelitvePosition = Player.transform.position - this.transform.position;
        transform.rotation = Quaternion.LookRotation(RelitvePosition);
        Vector3 RotationLock = this.transform.rotation.eulerAngles;
        
        RotationLock.z = 90;
        this.transform.rotation = Quaternion.Euler(RotationLock);
        if (RotationLock.z == 270)
        {
            RotationLock.z = 90;
        }
        print("HitDetections verion Of Enemys left = " + EnemySpawner.EnemyCounter);
        Timer += (1.1f * Time.deltaTime);
        Timer2 += (1.1f * Time.deltaTime);        
        if ((Timer >= Fireinterval) && (CanShoot == true))
        {
            AudioSource.PlayClipAtPoint(EnemyFire, transform.position);
            GameObject Beam = Instantiate(EnemyBeam, EnemyBeam.transform.position = new Vector3(this.transform.position.x,
                transform.position.y, transform.position.z), this.transform.rotation) as GameObject;            
            Timer = 0;
            locationControlls();
        }
        Changer.Counts();
        if (KillSpace.Killable == false)
        {
            print("Testssss");
        }
        Timer2 += (1 * Time.deltaTime);
        if (Timer2 > Fireinterval2)
        {
            CanShoot = true;
        }
        if (Timer2 > ShootLength)
        {
            CanShoot = false;
            Timer2 = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        AudioSource.PlayClipAtPoint(EnemyHit, transform.position);
        Explode();
        Destroy(col.gameObject);
        Health.HealthBar();
        Hits += 1;
        if (Hits >= MaxHits)
        {            
            DestroyObject(this.gameObject);
            AudioSource.PlayClipAtPoint(EnemyDeystroyed, transform.position);
            EnemySpawner.EnemyCounter -= 1;
            Changer.TutorialOver();
                       
        }
        if (EnemySpawner.EnemyCounter == 0)
        {
            
        }
        
    }
    void Explode()
    {
        Instantiate(Explotion, Explotion.transform.position = this.transform.position, transform.rotation);
    }
    public void Tester()
    {
        Debug.Log("Fuck");
    }
    public void locationControlls()
    {        
        if ((Player.transform.position.x > .5) &&(Player.transform.position.x < 1.5))
        {
                      
        }
        //if (Player.transform.position.x > -8.36)
        //{
            
        //}
    }
    public void FireAsorter()
    {
        
    }





}
