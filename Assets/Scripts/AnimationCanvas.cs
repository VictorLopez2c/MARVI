using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCanvas : MonoBehaviour
{
    public static AnimationCanvas instance;

    public float time_s = 90.0f;
    public float time_e = 0.0f;

    public bool stop;

    public GameObject This;
    public GameObject OptionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //time_s += Time.deltaTime;
        //if (time_s >= time_e)
       // {

        //}
    }

    public void tiempoOn()
    {
        //while (stop == false)
       // {
          //  time_s -= Time.deltaTime;

           // if (time_s <= time_e)
           // {
           //     This.SetActive(false);
            //    OptionCanvas.SetActive(true);
             //   stop = true;
                
          //  }
    }
}

