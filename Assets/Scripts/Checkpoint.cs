using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject cpON, cpOFF;
    public GameObject healthEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.SetSpawnPoint(transform.position);

            Checkpoint[] allCP = FindObjectsOfType<Checkpoint>();
            for( int i = 0; i< allCP.Length; i++)
            {
                allCP[i].cpOFF.SetActive(true);
                allCP[i].cpON.SetActive(false);
            }

            cpOFF.SetActive(false);
            cpON.SetActive(true);
        }
    }

}
