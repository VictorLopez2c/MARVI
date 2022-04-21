using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaEnemigo : MonoBehaviour
{
    public int funciona = 0;
    public int pen = 0;
    public GameObject Enemigo;

    //
    public void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            if (currentEnemyInContact)
            {
                currentEnemyInContact.GetComponent<enemiVida>().EnemyAttacking();
            }
        }*/
    }

    //PlayerController currentEnemyInContact = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /* PlayerController playerController = other.GetComponentInParent<PlayerController>();

             if (playerController)
             {
                 currentEnemyInContact = playerController;
             } */
            Enemigo.GetComponent<enemiVida>().EnemyAttacking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /*   PlayerController playerController = other.GetComponentInParent<PlayerController>();

               if (playerController)
               {
                   currentEnemyInContact = null;
               }
            */
            Enemigo.GetComponent<enemiVida>().EnemyPatrolling();
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Enemy")
        {
            funciona = funciona + 1;
            PlayerController.instance.Area();
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (other.tag == "Enemy")
        {
            pen = pen + 1;
            PlayerController.instance.Area();

        }
    }*/
}
