using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D.Platformer;

public class GM : MonoBehaviour {

    public GameObject enemyPrefab;
    public ItsHighNoon ihn;
    public UIcontrol _Ui;
    public int enemySum;
    public bool ishn = false;
    public AudioSource AS;
    public List<Transform> randomCreatPoints;
    public List<GameObject> enemylist;
    public List<GameObject> killenemylist;
    public List<AudioClip> sound;
    public float enemyCD = 3f;
    public bool gameing = true;
    // Use this for initialization
    void Start () {
        _Ui = GameObject.Find("Canvas").GetComponent<UIcontrol>();
        AS = this.GetComponent<AudioSource>();
        foreach(Transform child in GameObject.Find("Level").transform)
        {
            if(child.name == "creatEnemyPoint")
                randomCreatPoints.Add(child);
        }
        ihn = GameObject.Find("Player").GetComponent<ItsHighNoon>();
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        enemyCD -= Time.deltaTime;
        if (enemylist.Count!=enemySum && !ishn && enemyCD<0)
        {
            Vector3 randomPosition = randomCreatPoints[Random.Range(0,randomCreatPoints.Count)].position;
            GameObject _e = Instantiate(enemyPrefab,randomPosition,Quaternion.identity) as GameObject;
            enemylist.Add(_e);
            ihn.Cinematics.AddCinematicTarget(_e.transform);
            enemyCD = 3f;
        }

        if (enemylist.Count == 0 && ihn.Cinematics.IsPlaying == false&&ishn)
        {
            GameObject.Find("Player").GetComponent<PlayerInput>().enabled = true;
            killAllEnemy();
        }

    }

    public void clodAllEnemy()
    {
        for(int i = 0;i<enemylist.Count;i++)
        {
            enemylist[i].GetComponent<PlayerInputBot>().enabled = false;
        }
        
    }
    public void killAllEnemy()
    {
        for (int i = 0; i < killenemylist.Count; i++)
        {
            Destroy(killenemylist[i]);
        }

        playsound(0);
        ishn = false;
        enemyCD = 3f;
    }
    public void playsound(int i)
    {
        
        //if(!AS.isPlaying)
        //{
            AS.clip = sound[i];
            AS.Play();
        //}
        
    }
}
