using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableEventListnener : MonoBehaviour
{
    [SerializeField]
    private ScriptableData.SDInt sInt; 
    [SerializeField]
    private ScriptableData.ScriptableEvent<ScriptableData.SDInt> testEvent;

    private void Start()
    {
        //testEvent.OnScriptableEvent = OnMaxje;
    }

    void Update()
    {
        Debug.Log(sInt.Value);
    }

    private void OnMaxje()
    {

    }
}
