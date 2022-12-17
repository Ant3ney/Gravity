using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnudranceLeftEBeam : MonoBehaviour {
    public float BeamsSpeeds;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<Transform>();
        this.transform.position = new Vector3(GetComponentInParent<Transform>().position.x - (BeamsSpeeds * (1 * Time.deltaTime)), this.transform.position.y - (BeamsSpeeds * (1 * Time.deltaTime)), 0);
    }
}
