using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableData;

public class DayHandler : MonoBehaviour
{
    [SerializeField]
    private SDInt dayIndex;
    [SerializeField]
    private SEBool playerSleepEvent;
    [SerializeField]
    private SEBool playerClickBedEvent;
    [SerializeField]
    private GameObject sleepTransitionImage;

    private void Awake()
    {
        dayIndex.Value = 0;
        playerSleepEvent.OnScriptableEvent += PlayerWakeUp;
        playerClickBedEvent.OnScriptableEvent += PlayerSleep;
    }

    private void PlayerSleep(bool b)
    {
        sleepTransitionImage.SetActive(true);
    }

    private void PlayerWakeUp(bool b)
    {
        dayIndex.Value++;
        Debug.Log("Change day to day no: " + dayIndex.Value);
    }
}
