using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

 
    public GameObject HitEffect;
    public Animator animator;
    public UnityEngine.AI.NavMeshAgent agent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            animator.SetTrigger("Hit");
            HealthManager.instance.Hurt();
            Instantiate(HitEffect,transform.position, transform.rotation);
            //animator.SetBool("Attack", true);
            agent.isStopped = true;
        }
    }

}
