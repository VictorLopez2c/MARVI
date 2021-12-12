using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
  
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HealthManager.instance.Hurt();
        }
    }

}
