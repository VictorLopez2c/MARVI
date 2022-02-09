using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godMode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GO;

    void Start()
    {
        GO.SetActive(true);
        GO = GameObject.Find("Hurt Box");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown("o"))
            GO.SetActive(true);
        if (Input.GetKeyDown("g"))
            GO.SetActive(false);
    }
    
}
