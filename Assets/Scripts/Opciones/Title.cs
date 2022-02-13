using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject Titol;
    public GameObject StartMenu;

    public AudioSource Enter;
    public AudioSource GrindLow;
    public GameObject Back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Enter.Play();
            GrindLow.Play();
            Titol.SetActive(false);
            StartMenu.SetActive(true);
            Back.SetActive(true);

        }
    }
}
