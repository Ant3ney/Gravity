using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShiHitDecection : MonoBehaviour {
    
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
    public GameObject Rotater;
    public PlayerControler Play;
    public bool Respon = false;
    public GameObject Explotion;
    public AudioClip EnemyFire;
    public AudioClip EnemyDeystroyed;
    public AudioClip EnemyHit;
    // Use this for initialization
    void Start () {
        Shipsalive++;
        Changer = GameObject.FindObjectOfType<Level_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        print("HitDetections verion Of Enemys left = " + EnemySpawner.EnemyCounter);
        Timer += (1.1f * Time.deltaTime);
        Timer2 += (1.1f * Time.deltaTime);
        
        if (Timer >= Fireinterval)
        {
            AudioSource.PlayClipAtPoint(EnemyFire, transform.position);
            GameObject Beam = Instantiate(EnemyBeam, EnemyBeam.transform.position = new Vector3(this.transform.position.x,
                transform.position.y - 0.75f, 0), Rotater.transform.rotation) as GameObject;
            

            Timer = 0;
            
            
        }
        Changer.Counts();
        if (KillSpace.Killable == false)
        {
            print("Testssss");
        }
        

    }

    void OnTriggerEnter(Collider col)
    {
        Explode();
        Destroy(col.gameObject);
        AudioSource.PlayClipAtPoint(EnemyHit, transform.position);
        Hits += 1;
        if (Hits >= MaxHits)
        {            
            DestroyObject(this.gameObject);
            AudioSource.PlayClipAtPoint(EnemyDeystroyed, transform.position);
            EnemySpawner.EnemyCounter -= 1;
                       
        }
        if (EnemySpawner.EnemyCounter <= 0)
        {
            EnemySpawner.RoundsDone += 1;
            EnemySpawner.EnemyCounter = 0;
        }
        
    }
    void Explode()
    {
        Instantiate(Explotion, Explotion.transform.position = this.transform.position, Rotater.transform.rotation);
    }
    public void Tester()
    {
        Debug.Log("Fuck");
    }
    
    
    

}
