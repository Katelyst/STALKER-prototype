using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    [SerializeField]
    string packageName;
    [SerializeField]
    string packageDescription;
    [SerializeField]
    int packageDeliveryAddress;


    private void Start()
    {
        Debug.Log(packageName + " " + packageDescription + " To be delivered to: " + packageDeliveryAddress);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " is colliding");
        if(other.tag == "Player")
        { 
            other.GetComponentInChildren<PackageDataBase>().packageList.Add(new PackageSO(packageName, packageDescription, packageDeliveryAddress));
            Destroy(this.gameObject);
        }

        FeedbackInterface FeedbackInterface = GameObject.Find("PlayerInterfaceCanvas").GetComponent<FeedbackInterface>();
        FeedbackInterface.UpdateFeedbackText("Picked up Package");

    }
}
