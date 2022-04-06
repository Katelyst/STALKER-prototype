using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackInterface : MonoBehaviour
{
    private Text FeedbackTextElement; 

    [SerializeField]
    public GameObject PackageDataBase;

    private List<PackageSO> packageList;
    // Start is called before the first frame update
    void Start()
    {
        FeedbackTextElement = this.GetComponentInChildren<Text>();
        packageList = PackageDataBase.GetComponent<PackageDataBase>().packageList;

        FeedbackTextElement.text = "Acquire Package";
    }

    public void UpdateFeedbackText(string feedbackText)
    {  
        FeedbackTextElement.text = "";
        FeedbackTextElement.text = feedbackText + "\n";

        if(packageList.Count == 0)
        {
            FeedbackTextElement.text = "Go home";
        }

        foreach(PackageSO package in packageList)
        {
            FeedbackTextElement.text += "Deliver Package to: " + package.deliveryAddress + "\n";
        }

    }



}
