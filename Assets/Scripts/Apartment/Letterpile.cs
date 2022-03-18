using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableData;

public class Letterpile : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ScriptableData.SDBool clickedData; 

    [SerializeField]
    private SEBool clickLetterEvent; //could later become SECustomStruct to pass on data like what letter is opened, what day it is, stalker state, other data etc. 

    private int currID = 0;

    public void OnClick()
    {
        clickedData.Value = true;   //set to false in whatever is listening to this
        currID++;
        Sample(currID);
        
        //Debug.Log("Clicked letterpile");
        //fire event
        clickLetterEvent.Invoke(true);
        //listen for it on canvas
        //enable envelope graphic
        //click (or do something else) to open envelope
        //read letter contents
    }


    public void Sample(int id)
    {
        Debug.Log("Clicked letterpile: " + currID + " times!");
    }
}
