using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarTreckHealthUI : MonoBehaviour {
    private StarTreckHitDecection Control;
    // Use this for initialization
    public  float Hits;
    public static float TotalHealth;
    public float Perccents1;
    public float Perccents2;
    public float MaxHits = 200;
    public static float WidthPercent;
    public float HealthScale;
    public  float Bar;
    
    public GameObject Control2;
    
	void Start () {
        //Control = GetComponent<PlayerControler>();
        
            Control = GameObject.FindObjectOfType<StarTreckHitDecection>();
        
       
        
        Perccents2 = 1;



    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<RectTransform>().localScale = new Vector3(Perccents2, 1, 0);        
        print("Real Percent2 = " + Perccents2);
        print("Hits = " + Hits);
    }
    public void HealthBar()
    {
        Hits += 1;
        Perccents1 = (MaxHits - Hits);
        Perccents2 = (Perccents1 / MaxHits);
        //HealthUI.HealthScale = Mathf.Clamp(HealthUI.Percent2, 0, 1);        
       

        
    }
       
}
