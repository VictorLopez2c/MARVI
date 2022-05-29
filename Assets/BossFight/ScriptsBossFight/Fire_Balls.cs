using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Balls : MonoBehaviour
{


    private float crono;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        crono += 1 * Time.deltaTime;
        if (crono >3)
        {
            gameObject.SetActive(false);
            crono = 0;
        }
        transform.Translate(Vector3.forward * 15 * Time.deltaTime);

    }
}
