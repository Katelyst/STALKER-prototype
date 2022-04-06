using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    [SerializeField]
    int mailboxAddress;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            List<PackageSO> packageList = other.GetComponentInChildren<PackageDataBase>().packageList;
            FeedbackInterface FeedbackInterface = GameObject.Find("PlayerInterfaceCanvas").GetComponent<FeedbackInterface>();

            foreach(PackageSO package in packageList)
            {
                if (package.deliveryAddress == mailboxAddress)
                {
                    packageList.Remove(package);
                    FeedbackInterface.UpdateFeedbackText("Package delivered");
                    if(packageList.Count == 0)
                        {
                            GameObject.Find("HomeTrigger").GetComponent<LevelSwitchButton>().LoadLevel(0);
                        }
                    break;
                }
            }
            

        }
    }
}
