using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPosition : MonoBehaviour
{
    public GameObject Door;

    //public GameObject BotonPresion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DoorChecker"))
        {
            Door.SetActive(false);
            //BotonPresion.SetActive(false);
        }
    }
}
