using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEnemiga : MonoBehaviour
{

    public bool vision = false;
    public EnemiCont rango;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            vision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            vision = false;
        }
    }
}
