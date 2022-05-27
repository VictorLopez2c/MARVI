using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionMatarPorLaEspalda : MonoBehaviour
{
    public int funciona = 0;
    public int pen = 0;

    enemiVida _enemiVida;

    private void Awake()
    {
        _enemiVida = GetComponentInParent<enemiVida>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enemiVida.EnemyAttacking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enemiVida.EnemyPatrolling();
        }
    }
}
