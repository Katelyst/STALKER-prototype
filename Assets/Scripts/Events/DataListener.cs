using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableData;


public class DataListener : MonoBehaviour
{
    [SerializeField]
    private List<ScriptableObject> dataListeners = new List<ScriptableObject>();
    private List<ScriptableEvent> eventListeners = new List<ScriptableEvent>();

    public ScriptableEvent testEvent; 
    public SEBool testBoolEvent; 

    void Start()
    {
        // foreach(ScriptableEvent s in eventListeners)
        // {
        //     s.OnScriptableEvent += EventUpdate;
        // }

        testEvent.OnScriptableEvent += EventUpdate;
        testBoolEvent.OnScriptableEvent += EventBoolUpdate;

    }

    private void EventUpdate()
    {
        //argS.OnScriptableEvent -= EventUpdate;
        testEvent.OnScriptableEvent -= EventUpdate;
        //Debug.Log("TEST EVENT");
    }

    private void EventBoolUpdate(bool args)
    {
        //testBoolEvent.OnScriptableEvent -= EventBoolUpdate;
        Debug.Log("TEST BOOLEAN: " + args);
    }
}
