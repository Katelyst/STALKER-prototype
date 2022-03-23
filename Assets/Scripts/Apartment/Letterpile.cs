using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableData;
using Cinemachine;

public class Letterpile : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ScriptableData.SDBool clickedData; 

    [SerializeField]
    private SEBool onClickEvent; //could later become SECustomStruct to pass on data like what letter is opened, what day it is, stalker state, other data etc. 

    [SerializeField]
    private CinemachineVirtualCamera vCam;

    private int currID = 0;

    public void OnClick()
    {
        clickedData.Value = true;   //set to false in whatever is listening to this
        currID++;
        Sample(currID);
        
        //Debug.Log("Clicked letterpile");
        //fire event
        onClickEvent.Invoke(true);
        //should have an unfocus property tho
        vCam.Priority = 5;
    }


    public void Sample(int id)
    {
        //Debug.Log("Clicked letterpile: " + currID + " times!");
    }

    public CinemachineVirtualCamera GetVCam()
    {
        return vCam;
    }
}
