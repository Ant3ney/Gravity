using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {
    public GameObject EnemyShip;
    public GameObject EnemyShipLv2;
    public GameObject Rottater;
    public float Width = 10f;
    public float Hight = 5f;
    public float xmin;
    public float xmax;
    bool MovingLeft;
    bool MovingRight;
    public float timmer = 0;
    public float SwichTime;
    public float Speed;
    public int BeamSpeed;
    public float MoveDownSpeed;
    public float MoveDownStart;
    public float MoveDownStop;
    public static int EnemyCounter;
    public ShiHitDecection Dection;
    public static int RoundsDone = 0;
    public static bool WinRoundWait = false;
    Level_Manager Change;
    public static int NumberofPositionsInSpawner = 0;
    public EnemySpawner FirtsEnemySpawner;
    public bool ThirdFormationSpawnStart = false;
    void Start()
    {
        FirtsEnemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        StartupConstraints();        
        foreach (Transform child in transform)
        {            
            GameObject EnemyLevel1 = Instantiate(EnemyShip, child.transform.position, Rottater.transform.rotation) as GameObject;
            EnemyLevel1.transform.parent = child;
            EnemySpawner.EnemyCounter += 1;
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Hight, 0));
    }    
    void Update () {
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        EnemyMovementandSpawns();
        RoundControlls();
        if (FirtsEnemySpawner.SeceondFormationSpawnStart == true)
        {
            print("Seceond Formation Spawned");
        }
    }
    public void StartupConstraints()
    {
        
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 Leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 Rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = (Leftmost.x + (Width / 2));
        xmax = (Rightmost.x - (Width / 2));
        this.transform.position = new Vector3(transform.position.x, MoveDownStart, 0);
        print(EnemyCounter);
        RoundsDone = 0;
    }
    public void EnemyMovementandSpawns()
    {
        if (MovingRight)
        {
            transform.position = new Vector3(transform.position.x + (Speed * Time.deltaTime), transform.position.y, 0);
            timmer += (1 * Time.deltaTime);
            
            

        }
        if (!MovingRight)
        {
            transform.position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, 0);
            timmer -= (1 * Time.deltaTime);
            
        }
        transform.position = new Vector3(transform.position.x, (transform.position.y - (MoveDownSpeed * Time.deltaTime)), 0);

        if (transform.position.x < (xmin))
        {
            MovingRight = true;

        }
        else if (transform.position.x > (xmax))
        {
            MovingRight = false;

        }
        if (transform.position.y < MoveDownStop)
        {
            MoveDownSpeed = 0;
        }
    }
    public void RoundControlls()
    {        
        if ((FirtsEnemySpawner.SeceondFormationSpawnStart == true) && (EnemySpawner.RoundsDone < 2))
        {
            print("WWW---------------------------------------------------------");
            foreach (Transform child in transform)
            {
                MoveDownSpeed = 3;
                GameObject EnemyLevel1 = Instantiate(EnemyShip, child.transform.position, Rottater.transform.rotation) as GameObject;
                EnemyLevel1.transform.parent = child;
                EnemySpawner.EnemyCounter += 1;
                this.transform.position = new Vector3(transform.position.x, MoveDownStart,0);
                FirtsEnemySpawner.SeceondFormationSpawnStart = false;
                ThirdFormationSpawnStart = true;
}

        }
        
    }
}
