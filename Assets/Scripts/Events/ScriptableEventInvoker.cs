using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableData;

public class ScriptableEventInvoker : MonoBehaviour
{

    [SerializeField]
    private SEBool scrEvent;    //find a way to make this generic later

    public void InvokeCustomEvent(bool args)
    {
        scrEvent.Invoke(args);
    }
}
