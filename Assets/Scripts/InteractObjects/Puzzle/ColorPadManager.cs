using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// This handles assigning colours to pads and interactor, and assigning ids to both interactor and pads.
/// </summary>
public class ColorPadManager : MonoBehaviour
{
    public static ColorPadManager instance;
    [Header("SET Total Correct Placements Need on Inspector")]
    [SerializeField]
    int totalCorrectPlacementsNeed; //This is the total number of interactor that needs to be placed correctly before the door will open.
    [SerializeField]
    int currentCorrectPlacements; //Current number of interactor that are placed on the correct pad
    [SerializeField]
    int placements = 0; //This is overall attempted placements. This increments everytime a box is placed on a pad

    public List<GameObject> pads;
    public List<GameObject> interactorPads;
    public List<Color> possibleColors;


    //public Text placeCorrectText;   //*** Declarar TEXTO  Posiblidades***//
    //public Text placeTotalText;   //***Declarar TEXTO Num Aciertos***//


    public UnityEvent completeEvent; //The event you want to call when all interactor are placed. This can be anything. 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalCorrectPlacementsNeed = pads.Count; //Set the total number of correct placements needed to be the number of pads in the pads list. 
        currentCorrectPlacements = 0; //Start off with 0 correct placements

        //placeTotalText.text = totalCorrectPlacementsNeed.ToString(); //***MOSTRAR CANVAS Total Posiblidades***//


        RandomizeColourList(); //Randomize the colors 
        AssignColoursToListObjects(pads); //Assign the colors to the pads
        //RandomizeColourList(); //Randomize the colors again
        AssignColoursToListObjects(interactorPads); //Assign them to the interactor
        //ShuffleBoxOrder(); //Shuffle the box order so the same box does not always go on the same box
    }

    // Update is called once per frame
    void Update()
    {
        //placeCorrectText.text = currentCorrectPlacements.ToString(); //***MOSTRAR CANVAS Num ACIERTOS***//
    }

    /// <summary>
    /// Shuffle the colours in the possibleColors list
    /// </summary>
    void RandomizeColourList()
    {
        List<Color> tempList = new List<Color>();

        for (int i = 0; i < possibleColors.Count; i++)
        {
            tempList.Add(possibleColors[i]);
        }


        for (int i = 0; i < possibleColors.Count; i++)
        {
            Color tempColor = possibleColors[i];
            int randomIndex = UnityEngine.Random.Range(i, possibleColors.Count);
            possibleColors[i] = possibleColors[randomIndex];
            possibleColors[randomIndex] = tempColor;
        }
    }

    /// <summary>
    /// Goes through the list of objects passed to the function and applies a color from the possibleColors list to it.
    /// </summary>
    /// <param name="objects"></param>
    void AssignColoursToListObjects(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].GetComponent<Renderer>().material.color = possibleColors[i];
        }
    }

    /// <summary>
    /// Increase the number of attempted placements
    /// </summary>
    public void IncreasePlacement()
    {
        placements++;

        if (placements == totalCorrectPlacementsNeed) //Update the UI board
        {
           //placeCorrectText.text = currentCorrectPlacements.ToString();        //***********************//
        }
    }

    /// <summary>
    /// Decrease the number of attempted placements
    /// </summary>
    public void DecreasePlacement()
    {
        placements--;
    }

    /// <summary>
    /// Increase the number of CORRECT placements
    /// </summary>
    public void IncreaseCorrectPlacements()
    {
        currentCorrectPlacements++;

        if (currentCorrectPlacements == totalCorrectPlacementsNeed)
        {
            Debug.Log("ALL BOXES PLACED CORRECTLY");
            completeEvent.Invoke();
        }
    }

    /// <summary>
    /// Decrease the number of incorrect placements
    /// </summary>
    public void DecreaseCorrectPlacements()
    {
        currentCorrectPlacements--;
    }

    /// <summary>
    /// Shuffles the order of the interactor, and applies an ID to each box
    /// </summary>
    //void ShuffleBoxOrder()
    //{
    //    int number = 0;
    //    for (int i = 0; i < interactorPads.Count; i++)
    //    {

    //        GameObject temp = interactorPads[i];
    //        int randomIndex = UnityEngine.Random.Range(i, interactorPads.Count);
    //        interactorPads[i] = interactorPads[randomIndex];
    //        interactorPads[randomIndex] = temp;

    //        interactorPads[i].GetComponent<InteractPad>().interactPadId = number;
    //        pads[i].GetComponent<Pad>().padId = number;
    //        number++;

    //    }
    //}

}