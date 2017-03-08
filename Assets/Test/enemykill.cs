using UnityEngine;
using System.Collections;

public class enemykill : MonoBehaviour {

    private GM gameManger;
    private ItsHighNoon highNoon;
    public int life = 3;
	// Use this for initialization
	void Start () {
        gameManger = GameObject.Find("GameManger").GetComponent<GM>();
        highNoon = GameObject.Find("Player").GetComponent<ItsHighNoon>();
	}
	
	// Update is called once per frame
	void Update () {
        if (life == 0)
        {       
            Destroy(this.gameObject);
        }
        
	}
    void OnDisable()
    {
        Debug.Log("我死了");
        gameManger.enemylist.Remove(this.gameObject);
        gameManger.playsound(2);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Bullet")
        {
            life--;
            if (highNoon.Energy < 100)
            {
                highNoon.Energy += 5;
            }
              
            Debug.Log("中弹了，还有" + life + "点血");
        }
    }
}
