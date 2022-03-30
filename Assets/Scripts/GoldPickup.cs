using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPickup : MonoBehaviour
{

    public int value;

    public GameObject goldEffect;

    public AudioSource goldSound;
    
    public enum UIElementType { 
       Jugete,
       Disco,
       Olisbo,
       Calavera
    }

    public UIElementType type;

    Slider slider;

    void Start()
    {
        UIManager.instance.goldImage.enabled = false;//PickUp IMG- Canvas Disabled
        
    }
    

    
    void Update()
    {
        
    }

    /*   private void OnTriggerEnter(Collider other)
       {
           if (other.tag == "Player")
           {

               GameManager.instance.AddGold(value);
               goldSound.Play();

               Destroy(gameObject);
               Instantiate(goldEffect, transform.position, transform.rotation);
           }
       }*/
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            StartCoroutine(GoldImageCnv());
            //UIManager.instance.goldImage.enabled = !UIManager.instance.goldImage.enabled;
            GameManager.instance.AddGold(value);
            goldSound.Play();
            Instantiate(goldEffect, transform.position, transform.rotation);
            
            switch (type)
            {
                case UIElementType.Jugete:
                    /*slider = GetComponent<Slider>();
                    slider.value = OroSettings.audioSettings.GetRobot();*/
                    Oro = 1;
                    break;
                case UIElementType.Disco:
                    /*slider = GetComponent<Slider>();
                    slider.value = OroSettings.audioSettings.GetDisco();*/
                    Oro = 2;
                    break;
                case UIElementType.Olisbo:
                    /*slider = GetComponent<Slider>();
                    slider.value = OroSettings.audioSettings.GetOlisbo();*/
                    Oro = 3;
                    break;
                case UIElementType.Calavera:
                    /*slider = GetComponent<Slider>();
                    slider.value = OroSettings.audioSettings.GetCalavera();*/
                    Oro = 4;
                    break;
            }
            if( Oro == 1)
            {
                Oro
            }

        }
    }
    private IEnumerator GoldImageCnv()
    {
        UIManager.instance.goldImage.enabled = !UIManager.instance.goldImage.enabled;
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.goldImage.enabled = !UIManager.instance.goldImage.enabled;
        //Destroy(gameObject);
    }


}
