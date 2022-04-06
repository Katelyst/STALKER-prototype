using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSO
{
    // Start is called before the first frame update
    public string name;
    public string description;
    public int    deliveryAddress;


    public PackageSO()
    {

    }

    public PackageSO(string Name, string Description, int DeliveryAddress)
    {
        name = Name;
        description = Description;
        deliveryAddress = DeliveryAddress;

        Debug.Log("A new Package was created " + name + " " + description + " To be delivered to: " + deliveryAddress);
    }
}
