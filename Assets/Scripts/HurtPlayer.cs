using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{


 
    public GameObject HitEffect;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            HealthManager.instance.Hurt();
            Instantiate(HitEffect,transform.position, transform.rotation);

        }
    }

}
