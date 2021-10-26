using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Level;


    public GameObject optionsScreen;

    


    public void Play()
    {
        SceneManager.LoadScene(Level);

    }

   public void Options()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void Quitgame()
    {
       Application.Quit();
    }
}
