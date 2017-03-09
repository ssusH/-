using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using Com.LuisPedroFonseca.ProCamera2D.Platformer;

public class ItsHighNoon : MonoBehaviour {

    public GM gameManger;
    public GameObject itsbullet;
    public float Energy = 100;
    public float coldtime = 1;
    public int Hp;
    private bool wudi = false;
    public float wudiCD = 1;
    public int bulletSum = 6;
    private AudioSource AS;
    public int bsum = 6;
    private bool HD;//换弹
    public Transform shotPoint;
    public Transform bodyPoint;
    public List<AudioClip> sound;
    public ProCamera2DCinematics Cinematics;

    // Use this for initialization
    void Start ()
    {
        Hp = 200;
        bsum = bulletSum;
        AS = this.GetComponent<AudioSource>();
        coldtime = -1;
        Energy = 0;
        gameManger = GameObject.Find("GameManger").GetComponent<GM>();
        Cinematics = GameObject.Find("Main Camera").GetComponent<ProCamera2DCinematics>();
        ProCamera2D.Instance.AddCameraTarget(GameObject.Find("Player").transform);
    }
	
	// Update is called once per frame
	void Update () {

        if (Energy < 100 && !gameManger.ishn)
            Energy += Time.deltaTime;
        else if (Energy > 100)
            Energy = 100;


        if (Hp < 0)
            Hp = 0;
        if (Hp > 200)
            Hp = 200;

        if(wudi)
        {
            wudiCD -= Time.deltaTime;
            if(wudiCD<0)
            {
                wudiCD = 1;
                wudi = false;
            }
        }
        if (coldtime < 0 && Input.GetKeyDown(KeyCode.J)&&!HD)
        {

            if (bsum <= 0)
            {
                playsound(1);
                StartCoroutine(huanzidang());
                HD = true;
            }
            else
                PlayerXShot();

            coldtime = 0.1f;
        }
        else
        {
           coldtime -= Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.R)&&!HD)
        {
            playsound(1);
            StartCoroutine(huanzidang());
            HD = true;
        }
        if (Input.GetKeyDown(KeyCode.Q)&&Energy==100)
        {
            gameManger.playsound(3);
            gameManger.ishn = true;
            gameManger.clodAllEnemy();
            this.GetComponent<PlayerInput>().enabled = false;
            Cinematics.Play();
            Energy = 0;
            for (int i = 0;i<gameManger.enemylist.Count;i++)
            {
                gameManger.killenemylist.Add(gameManger.enemylist[i]);
            }
            gameManger.enemylist.Clear();
            gameManger._Ui.restar();
        }
    }

    public void PlayerShot()
    {

        if (!gameManger.ishn && bsum > 0)
        {
            bsum--;
            Vector3 offset = Vector3.zero;
            GameObject _bullet = Instantiate(itsbullet, shotPoint.position + new Vector3(0, 0.2f, 0), Quaternion.identity) as GameObject;
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 _offset = offset - this.transform.position;
            _offset = _offset.normalized;
            _bullet.GetComponent<Rigidbody>().velocity = new Vector2(_offset.x * 15, _offset.y * 15);
            playsound(0);
        }

    }
    public void PlayerXShot()
    {

        if (!gameManger.ishn && bsum > 0)
        {
            bsum--;
            //Vector3 offset = Vector3.zero;
            GameObject _bullet = Instantiate(itsbullet, shotPoint.position + new Vector3(0, 0.2f, 0), Quaternion.identity) as GameObject;
            //offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 _offset = offset - this.transform.position;
            //_offset = _offset.normalized;
            if(bodyPoint.localScale.x<0)
                _bullet.GetComponent<Rigidbody>().velocity = Vector2.left*10;
            else
                _bullet.GetComponent<Rigidbody>().velocity = Vector2.right*10;
            playsound(0);
        }

    }
    public IEnumerator huanzidang()
    {

        Debug.Log("waiteing");
        yield return new WaitForSeconds(1.0f);
        HD = false;
        Debug.Log("huanzidangwait1s");
        bsum = bulletSum;
    }

    public void playsound(int i)
    {
            AS.clip = sound[i];
            AS.Play();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag=="Enemy")
        {
            Debug.Log("attack");
            if(!wudi)
            {
                Hp -= 15;
                wudi = true;
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "bigHp")
        {
            Debug.Log("bigHP");
            if (Hp != 200)
            {
                Hp += 250;
                other.GetComponent<HP>().useHp();
                //other.gameObject.active = false;
            }
               
        }

        if (other.transform.gameObject.name == "smallHp")
        {
            Debug.Log("smallHP");
            if(Hp!=200)
            {
                Hp += 75;
                other.GetComponent<HP>().useHp();
                //other.gameObject.active = false;
            }
            
        }
    }
}
