using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTreckEBeam : MonoBehaviour {
    public float BeamsSpeeds;
    public GameObject Rotator;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<Transform>();
        this.transform.position += transform.TransformDirection(Vector3.forward * BeamsSpeeds);
        
    }
}
