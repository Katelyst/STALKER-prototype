using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableEventListnener : MonoBehaviour
{
    [SerializeField]
    private ScriptableData.SDInt sInt; 

    void Update()
    {
        Debug.Log(sInt.Value);
    }
}
