using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public Image blackScreen;
    public float fadeSpeed;
    public bool fadeToBlack, fadeFromBlack;

    public Text healthText;
    public Image healthImage;

    public Text goldText;
    public Image goldImage;

    public GameObject pauseScreen, optionsScreen;

    public GameObject MainButtons;
    public GameObject Screen;
    public GameObject Sound;
    public GameObject AnimScreen;
    public GameObject AnimSound;

    public string Main;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        
        if (fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        MainButtons.SetActive(false);
    }

    public void ScreenOptions()
    {
        optionsScreen.SetActive(false);
        AnimScreen.SetActive(false);
        AnimSound.SetActive(false);
        Screen.SetActive(true);
    }

    public void CloseScreen()
    {
        Screen.SetActive(false);
        AnimScreen.SetActive(true);
    }

    public void SoundOptions()
    {
        optionsScreen.SetActive(false);
        AnimScreen.SetActive(false);
        AnimSound.SetActive(false);
        Sound.SetActive(true);
    }

    public void CloseSound()
    {
        Sound.SetActive(false);
        AnimSound.SetActive(true);
    }


    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        AnimScreen.SetActive(false);
        AnimSound.SetActive(false);
        MainButtons.SetActive(true);

        AnimSound.SetActive(false);
        AnimScreen.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Main);
    }

}
