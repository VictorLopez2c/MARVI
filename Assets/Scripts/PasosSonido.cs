using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosSonido : MonoBehaviour
{
    public AudioSource Pie;
    public AudioSource PieRock;
    public AudioSource PieWood;
    public AudioSource PiePont;
    public AudioSource PieWater;
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain" & other.gameObject.tag != "Water")
        {
            Pie.Play();
        }
        if (other.gameObject.tag == "Rock")
        {
            PieRock.Play();
        }
        if (other.gameObject.tag == "Wood")
        {
            PieWood.Play();
        }
        if (other.gameObject.tag == "Pont")
        {
            PiePont.Play();
        }
        if (other.gameObject.tag == "Water")
        {
            PieWater.Play();
        }
    }
}
