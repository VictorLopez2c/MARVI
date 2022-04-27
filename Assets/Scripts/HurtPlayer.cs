using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class HurtPlayer : MonoBehaviour
{

 
    public GameObject HitEffect;
    public Animator animator;
    public UnityEngine.AI.NavMeshAgent agent;
    public AudioSource Pupa;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            agent.isStopped = true;
            Pupa.Play();
            animator.SetTrigger("Hit");
            Task.Delay(2000);
            agent.isStopped = false;
            HealthManager.instance.Hurt();
            Instantiate(HitEffect,transform.position, transform.rotation);
            //animator.SetBool("Attack", true);
            agent.isStopped = true;
        }
    }

}
