using UnityEngine;
using UnityEngine.InputSystem;

public class ReturnFromUI : MonoBehaviour
{
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
