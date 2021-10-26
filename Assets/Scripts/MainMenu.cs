using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Level;

    public string Settings;


    public void Play()
    {
        SceneManager.LoadScene(Level);
    }

   public void Options()
    {
        
    }

    public void Quitgame()
    {
       Application.Quit();
    }
}
