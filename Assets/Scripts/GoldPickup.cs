using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPickup : MonoBehaviour
{

    public int value;
	public int Oro;

    //Menu
    public GameObject GoldItem;
    public GameObject NoGoldItem;

    //Audio
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
            GoldItem.SetActive(true);
            NoGoldItem.SetActive(false);

            //switch (type)
            //{
            //    case uielementtype.jugete:
            //        /*slider = getcomponent<slider>();
            //        slider.value = orosettings.audiosettings.getgolditem();*/
            //        oro = 1;
            //        break;
            //    case uielementtype.disco:
            //        /*slider = getcomponent<slider>();
            //        slider.value = orosettings.audiosettings.getdisco();*/
            //        oro = 2;
            //        break;
            //    case uielementtype.olisbo:
            //        /*slider = getcomponent<slider>();
            //        slider.value = orosettings.audiosettings.getolisbo();*/
            //        oro = 3;
            //        break;
            //    case uielementtype.calavera:
            //        /*slider = getcomponent<slider>();
            //        slider.value = orosettings.audiosettings.getcalavera();*/
            //        oro = 4;
            //        break;
            //}

        }
    }
    private IEnumerator GoldImageCnv()
    {
        UIManager.instance.goldImage.enabled = !UIManager.instance.goldImage.enabled;
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.goldImage.enabled = !UIManager.instance.goldImage.enabled;
        Destroy(gameObject);
    }


}
