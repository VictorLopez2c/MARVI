using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public List<GameObject> myList;

    private int currentActiveIndex = 0;
    void OnAnimationFinish()
    {
        myList[currentActiveIndex].SetActive(false);
        currentActiveIndex++;
        if (currentActiveIndex >= myList.Count)
            currentActiveIndex = 0;
        //myList[currentActiveIndex].SetActive(true);
    }
}
