using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaDaño : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        if (currentEnemyInContact)
        {
            currentEnemyInContact.GetComponent<enemiVida>().EnemyAttacking();
        }

    }

    EnemiCont currentEnemyInContact = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemiCont enemiCont = GetComponentInParent<EnemiCont>();

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
            EnemiCont enemiCont = GetComponentInParent<EnemiCont>();

            if (enemiCont)
            {
                currentEnemyInContact = null;
            }
        }
    }
}
