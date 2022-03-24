using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBoolToggle : MonoBehaviour
{
    [SerializeField]
    private bool enabled = false;

    public void ToggleBool()
    {
        enabled = !enabled;
        gameObject.SetActive(enabled);
    }

    private void OnDisable()
    {
        enabled = gameObject.activeInHierarchy;
    }

    private void OnEnable()
    {
        enabled = gameObject.activeInHierarchy;
    }
}
