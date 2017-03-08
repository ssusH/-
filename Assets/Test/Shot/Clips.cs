using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Clips  {

    public int maxSum;
    public int nowSum;
    public List<bullet> bullets;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    Clips()
    {
        maxSum = 6;
        bullets = new List<bullet>();
    }
    void bombExplosiveColumn()
    {
        nowSum = maxSum;

    }

}
