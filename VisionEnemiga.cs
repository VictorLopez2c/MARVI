using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEnemiga : MonoBehaviour
{

    public bool vision = false;
    public EnemiCont rango;
    public int antonio = 0;

    // Start is called before the first frame update
    void Start()
    {
        rango = GameObject.Find("Enemy").GetComponent<EnemiCont>();
    }

    // Update is called once per frame
    void Update(Collider other)
    {

        if (rango != null) rango = GameObject.Find("Enemy").GetComponent<EnemiCont>();

        if (rango.cerca == false)
        {
            vision = false;
        }
        if (other.tag == "Player")
        {
            vision = true;
        }
    }


    enemiVida currentEnemyInContact = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            antonio = 1;
            enemiVida enemiCont = other.GetComponentInParent<enemiVida>();

                


            vision = true;
            currentEnemyInContact.GetComponent<enemiVida>().EnemyAttacking();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            enemiVida enemiCont = other.GetComponentInParent<enemiVida>();

            currentEnemyInContact = enemiCont;
            if (enemiCont)
            {
                currentEnemyInContact = null;
            }

            vision = false;
            currentEnemyInContact.GetComponent<enemiVida>().EnemyPatrolling();
        }
    }

    public void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            if (currentEnemyInContact)
            {
                currentEnemyInContact.GetComponent<enemiVida>().EnemyAttacking();
            }
        }*/

        if (vision == true)
        {
            if (currentEnemyInContact)
            {
                
            }
        }

        if (vision == false)
        {
            if (currentEnemyInContact)
            {
                
            }
        }
    }



   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController enemiCont = other.GetComponentInParent<PlayerController>();

            if (enemiCont)
            {
                currentEnemyInContact = enemiCont;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController enemiCont = other.GetComponentInParent<PlayerController>();

            if (enemiCont)
            {
                currentEnemyInContact = null;
            }
        }
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            antonio = 1;
            EnemiCont enemiCont = other.GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = enemiCont;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemiCont enemiCont = other.GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = null;
            }
        }
    }*/
}
