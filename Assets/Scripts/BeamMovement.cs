using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMovement : MonoBehaviour {
    public int BeamsSpeed;
    public bool Dystroy;
    bool Indestructables;
    ShiHitDecection IsEnemy;
    int Direction;
    public GameObject NormalBeamRotator;


    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update ()
    {
        GetComponentInParent<Transform>();       
        this.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, this.transform.position.y + (BeamsSpeed * Time.deltaTime), 0);                               
    }
    
        
    
}

