using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HP : MonoBehaviour {

    public bool active = true;
    private Image jsq;
    public float restartime = 5;

    void Start () {
        jsq = this.gameObject.GetComponentInChildren<Image>();
    }
	

	void Update () {
	    if(!active)
        {
            jsq.fillAmount = restartime / 5;
            restartime -= Time.deltaTime;
            if(restartime<0)
            {
                active = true;
                restar();
                restartime = 5;
            }
        }
	}



    public void restar()
    {
        this.GetComponent<CapsuleCollider>().enabled = true;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
        jsq.fillAmount = 0;
    }

    public void useHp()
    {
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        jsq.fillAmount = 1f;
        active = false;
    }
}
