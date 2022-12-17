using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSpace : MonoBehaviour {
    public static bool Killable = false;
    public bool KillCheck;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider CanKill)
    {
        Destroy(CanKill.gameObject);
    }
    
}
