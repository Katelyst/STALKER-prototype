using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ScriptableData;

public class LetterHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject envelope;
    [SerializeField]
    private GameObject openLetterButton;
    [SerializeField]
    private TextMeshProUGUI envelopeText;
    [SerializeField]
    private GameObject openedLetter;
    [SerializeField]
    private TextMeshProUGUI letterText;

    [SerializeField]
    private SEBool clickLetterPileEvent;

    [SerializeField]
    private SEBool OpenLetterEvent;

    // Start is called before the first frame update
    void Start()
    {
        clickLetterPileEvent.OnScriptableEvent += ShowEnvelope;
        OpenLetterEvent.OnScriptableEvent += OpenLetter;
    }

    private void ShowEnvelope(bool show)
    {
        Debug.Log("Got event, open envelope!");
        //clickLetterPileEvent.OnScriptableEvent -= ShowLetter; //prevent duplicates
        envelope.SetActive(true);
        openLetterButton.SetActive(true);

        openedLetter.SetActive(false);
    }

    private void OpenLetter(bool show)
    {
        openedLetter.SetActive(show);
        openLetterButton.SetActive(false);

        if(!show)   //insurance
        {
            envelope.SetActive(false);
            openedLetter.SetActive(false);
            openLetterButton.SetActive(false);
        }
    }
}
