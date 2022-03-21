using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractible : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToAppearInRange;

    [SerializeField]
    private GameObject[] objectsToAppearAfterInteraction;

    [SerializeField]
    private GameObject[] objectsToDissapearAfterInteraction;

    private bool isCharacterInRange = false;

    [SerializeField]
    private bool changeToUI = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            isCharacterInRange = true;
            foreach(GameObject gameObject in objectsToAppearInRange)
            {
                gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isCharacterInRange = false;
            foreach (GameObject gameObject in objectsToAppearInRange)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if(Keyboard.current.cKey.isPressed&&isCharacterInRange)
        {
            foreach (GameObject gameObject in objectsToAppearAfterInteraction)
            {
                gameObject.SetActive(true);
            }
            foreach (GameObject gameObject in objectsToDissapearAfterInteraction)
            {
                gameObject.SetActive(false);
            }
            if(changeToUI)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
