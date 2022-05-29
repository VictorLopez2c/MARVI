using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHurtEnemy : MonoBehaviour
{

    public GameObject GolpeEfectuado;

    public void Golpeo()
    {
        GolpeEfectuado.SetActive(true);
    }

    public void NoGolpeo()
    {
        GolpeEfectuado.SetActive(false);
    }
}
