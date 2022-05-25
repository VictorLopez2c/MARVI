using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractorManager : MonoBehaviour
{
    [Header("OnTriggerEnter")]
    public List<string> onTriggerEnterTag;
    public List<UnityEvent> onTriggerEnter;


    


    private void OnTriggerEnter(Collider other)
    {
        //*** OnTriggerEnter ***//
        if (onTriggerEnter.Count == 1 && onTriggerEnterTag.Count == 0)
        {
            onTriggerEnter[0].Invoke();
            return;
        }

        if (onTriggerEnter.Count != onTriggerEnterTag.Count)
        {
            Debug.LogError("No match tag OnTriggerEnter");
            return;
        }


        for(int i = 0; i < onTriggerEnter.Count; i++)
        {
            onTriggerEnter[i].Invoke();
        }

    }

   
}
