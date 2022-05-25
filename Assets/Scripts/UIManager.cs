using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using System;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public Image blackScreen;
    public float fadeSpeed;
    public bool fadeToBlack, fadeFromBlack;

    public Text healthText;
    [SerializeField]public Image healthImage;
    public Image hurtImage;

    public Text goldText;
    public Image goldImage;

    public GameObject pauseScreen, optionsScreen;

    public GameObject Robotitus;

    public GameObject MainButtons;
    public GameObject ButtonsFake;
    public GameObject Screen;
    public GameObject Sound;
    public GameObject AnimScreen;
    public GameObject AnimSound;
    public GameObject Collect;
    public GameObject Interrogante;
    public GameObject Oro;
    public GameObject Disc;
    public GameObject Calaveri;
    public GameObject Olisbox;


    public Animator loked;
    public Animator ImgMenu;
    public Animator BarraMenu;
    public Animator AnrRobo;
    public Animator AnrDisc;
    public Animator AnrCalav;
    public Animator AnrOlis;
    public Animator ButtonsM;
    public Animator ButtonsCollect;
    public string Main;


    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        Cursor.visible = true;
        //loked = GetComponent<Animator>();
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
        Collect.SetActive(false);
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

        loked.SetBool("Change", true);
    }
    public void Coleccionables()
    {
        Collect.SetActive(true);
        BarraMenu.SetBool("Barra", true);
        MainButtons.SetActive(false);
        ImgMenu.SetBool("Collectibles", true);
        BarraMenu.SetBool("salida", false);
        ButtonsCollect.SetBool("salida", false);
        //BarraMenu.SetTrigger("Entry");
        //Oro.SetActive(true);

    }
    
    public void Bloqueado()
    {
        Interrogante.SetActive(true);
        loked.SetTrigger("Click");
        loked.SetTrigger("Inter");
        AnrRobo.SetTrigger("Adeu");
        AnrDisc.SetTrigger("AdeuI");
        AnrCalav.SetTrigger("AdeuI");
        AnrOlis.SetTrigger("AdeuI");
        //loked.SetBool("Change", true);
        //loked.SetBool("Change", false);
    }
    public void Robot()
    {
        Robotitus.SetActive(true);
        AnrRobo.SetTrigger("Click");
        AnrRobo.SetTrigger("Roboti");
        loked.SetTrigger("AdeuI");
        AnrDisc.SetTrigger("AdeuI");
        AnrCalav.SetTrigger("AdeuI");
        AnrOlis.SetTrigger("AdeuI");
        //loked.SetBool("Change", true);
        //loked.SetBool("Change", false);
    }

    public void Disco()
    {
        Disc.SetActive(true);
        AnrDisc.SetTrigger("Click");
        AnrDisc.SetTrigger("Inter");
        AnrRobo.SetTrigger("Adeu");
        loked.SetTrigger("AdeuI");
        AnrCalav.SetTrigger("AdeuI");
        AnrOlis.SetTrigger("AdeuI");
        //loked.SetBool("Change", true);
        //loked.SetBool("Change", false);
    }

    public void Calavera()
    {
        Calaveri.SetActive(true);
        AnrCalav.SetTrigger("Click");
        AnrCalav.SetTrigger("Inter");
        AnrRobo.SetTrigger("Adeu");
        loked.SetTrigger("AdeuI");
        AnrDisc.SetTrigger("AdeuI");
        AnrOlis.SetTrigger("AdeuI");
        //loked.SetBool("Change", true);
        //loked.SetBool("Change", false);
    }
    public void Olisbo()
    {
        Olisbox.SetActive(true);
        AnrOlis.SetTrigger("Click");
        AnrOlis.SetTrigger("Inter");
        AnrRobo.SetTrigger("Adeu");
        loked.SetTrigger("AdeuI");
        AnrDisc.SetTrigger("AdeuI");
        AnrCalav.SetTrigger("AdeuI");
        //loked.SetBool("Change", true);
        //loked.SetBool("Change", false);
    }

    public void CloseCollect()
    {
        ImgMenu.SetBool("Collectibles", false);
        BarraMenu.SetTrigger("Exit");
        BarraMenu.SetBool("salida", true);
        //ButtonsFake.SetActive(true);
        StartCoroutine("WaitMenu");
        //Oro.SetActive(false);
        MainButtons.SetActive(true);
        ButtonsM.SetTrigger("Hi");
        ButtonsCollect.SetBool("salida", true);
        BarraMenu.SetBool("Barra", false);
        Interrogante.SetActive(false);
        Robotitus.SetActive(false);
        Disc.SetActive(false);
        Calaveri.SetActive(false);
        Olisbox.SetActive(false);


    }

    IEnumerator WaitMenu()
    {
        yield return new WaitForSeconds (3);
        ButtonsFake.SetActive(false);
        MainButtons.SetActive(true);
        Debug.Log("VictorChupaPinga");
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(Main);
    }

}
