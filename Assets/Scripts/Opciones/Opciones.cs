using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{
    public GameObject Screen;
    public GameObject Sound;
    public GameObject MenuOptions;
    public GameObject ScreenCanvas;
    public GameObject AnimationScreen;
    public GameObject SoundCanvas;
    public GameObject AnimationSound;
    public GameObject MainMenu;
    public GameObject AnimOptions;
    public AudioSource Grind;
    public AudioSource BasicSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pantalla()
    {
        Screen.SetActive(true);
        MenuOptions.SetActive(false);
        AnimationScreen.SetActive(false);
        AnimationSound.SetActive(false);
        BasicSound.Play();
        Grind.Play();
    }


    public void Sonido()
    {
        Sound.SetActive(true);
        MenuOptions.SetActive(false);
        AnimationScreen.SetActive(false);
        AnimationSound.SetActive(false);
        Grind.Play();
        BasicSound.Play();
    }

    public void ReturnOp()
    {
        MenuOptions.SetActive(false);
        AnimOptions.SetActive(true);
        AnimationScreen.SetActive(false);
        AnimationSound.SetActive(false);
        BasicSound.Play();
    }

    public void ReturnSc()
    {
        Grind.Play();
        ScreenCanvas.SetActive(false);
        AnimationScreen.SetActive(true);
        BasicSound.Play();
    }

    public void ReturnSo()
    {
        Grind.Play();
        SoundCanvas.SetActive(false);
        AnimationSound.SetActive(true);
        BasicSound.Play();
    }
}
