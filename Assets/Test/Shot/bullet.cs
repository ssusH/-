using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{

    public float power;
    public string type;
    public float speed;

    void OnCollisionEnter(Collision other)
    {
            Destroy(this.gameObject);
        if (other.transform.tag == "Enemy")
        {
            //Destroy(other.gameObject);
        }

    }
    //void OnTriggerExit(Collider other)
    //{
    //    if(other.transform.tag == "Player")
    //    {
    //        this.gameObject.GetComponent<SphereCollider>().isTrigger = false;
    //    }
    //}


}
