using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShreder : MonoBehaviour {
    public bool Indestructable;

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
