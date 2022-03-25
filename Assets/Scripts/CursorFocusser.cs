using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFocusser : MonoBehaviour
{
    [SerializeField]
    private CursorLockMode lockmode = CursorLockMode.None;
    void Awake()
    {
        Cursor.lockState = lockmode;
    }
}
