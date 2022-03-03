using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPickup : MonoBehaviour
{

    public int value;

    public GameObject goldEffect;

    public AudioSource goldSound;

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
