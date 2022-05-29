using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBeginBossFight : MonoBehaviour
{


    public BossStats bossStats;
    public GameObject FightBarrier;
    public GameObject Xaman;

    private void Awake()
    {
        bossStats = GetComponent<BossStats>();
    }


    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //bossStats.bossCurrentHealth = bossStats.bossMaxHealth;
            //bossStats.isDeath = false;
            //bossStats.bossMusic.enabled = true;
            FightBarrier.SetActive(true);
            Xaman.SetActive(true);
        }


    }

}