using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_thrower : MonoBehaviour
{

    private float crono;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 6 * Time.deltaTime);
        transform.localScale += new Vector3(3, 3, 3)* Time.deltaTime;

        crono += 1 * Time.deltaTime;

        if (crono > 1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            crono = 0;


        }
    }
}
