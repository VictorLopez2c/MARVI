using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string Level;


    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject Menu;
    public GameObject Buttons;
    public GameObject AnimationOptions;

    public AudioSource BasicFX;
    public AudioSource StoneLow;




    void Start()
    {
        Cursor.visible = true;
    }


    public void Play()
    {
        BasicFX.Play();
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;

    }

   public void Options()
    {
        optionsScreen.SetActive(true);
        Buttons.SetActive(false);
        BasicFX.Play();
    }
    public void Options2()
    {
        optionsScreen.SetActive(true);
        Buttons.SetActive(false);
        AnimationOptions.SetActive(false);
        BasicFX.Play();
    }

    public void Credits()
    {
        creditsScreen.SetActive(true);
        Menu.SetActive(false);
        AnimationOptions.SetActive(false);
        BasicFX.Play();
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        Menu.SetActive(true);
        Buttons.SetActive(true);
        BasicFX.Play();
        StoneLow.Play();
    }

    public void CloseCredits()
    {
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        Menu.SetActive(true);
        Buttons.SetActive(true);
        BasicFX.Play();
    }

    public void Quitgame()
    {
        BasicFX.Play();
        Application.Quit();
        
    }

    public void ScreenReturn()
    {

        
        AnimationCanvas.instance.tiempoOn();
        BasicFX.Play();

    }
}
