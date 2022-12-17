using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnduranceHitDecection : MonoBehaviour {
    
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
    public PlayerControler Play;
    public bool Respon = false;
    public GameObject Explotion;
    public AudioClip EnemyFire;
    public Animator EnduranceRotation;
    public GameObject Rotator;
    public BossHealthUI BossHealthBar;
    public GameObject BeamMovingRight;
    public GameObject BeamMovingLeft;
    public GameObject RotatorRight;
    public GameObject RotatorLeft;
    public AudioClip EnemyDeystroyed;
    public AudioClip EnemyHit;
    // Use this for initialization
    void Start () {
        EnduranceRotation = GetComponent<Animator>();
        Shipsalive++;
        Changer = GameObject.FindObjectOfType<Level_Manager>();
        BossHealthBar = GameObject.FindObjectOfType<BossHealthUI>();
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
                transform.position.y - 0.75f, 0), Rotator.transform.rotation) as GameObject;
            GameObject BeamR = Instantiate(BeamMovingRight, BeamMovingRight.transform.position = new Vector3(this.transform.position.x,
                transform.position.y - 0.75f, 0), RotatorRight.transform.rotation) as GameObject;
            GameObject BeamL = Instantiate(BeamMovingLeft, BeamMovingLeft.transform.position = new Vector3(this.transform.position.x,
                transform.position.y - 0.75f, 0), RotatorLeft.transform.rotation) as GameObject;

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
        BossHealthBar.HealthBar();
        Explode();
        Destroy(col.gameObject);
        print("EnduranceHit");
        Hits += 1;
        AudioSource.PlayClipAtPoint(EnemyHit, transform.position);
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
        Instantiate(Explotion, Explotion.transform.position = this.transform.position, Rotator.transform.rotation);
    }
    public void Tester()
    {
        Debug.Log("Fuck");
    }
    
    
    

}
