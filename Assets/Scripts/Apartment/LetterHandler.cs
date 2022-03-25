using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ScriptableData;

public class LetterHandler : MonoBehaviour
{
    [Header("Envelope Fields")]
    [SerializeField]
    private GameObject envelope;
    [SerializeField]
    private GameObject openLetterButton;
    [SerializeField]
    private TextMeshProUGUI envelopeText;
    [Header("Letter Fields")]
    [SerializeField]
    private GameObject openedLetter;
    [SerializeField]
    private TextMeshProUGUI letterText; //edit with new day letter text
    [SerializeField]
    private SEBool clickLetterPileEvent;
    [SerializeField]
    private SEBool OpenLetterEvent;
    [Header("Daily Text Data")]
    [SerializeField]
    private List<DailyText> texts;

    [SerializeField]
    private SDInt dayIndex;

    // Start is called before the first frame update
    void Start()
    {
        dayIndex.Value = 0; //set to 0, because scriptable objects store data offline
        UpdateText(dayIndex.Value);
        clickLetterPileEvent.OnScriptableEvent += ShowEnvelope;
        OpenLetterEvent.OnScriptableEvent += OpenLetter;
        dayIndex.OnValueChangedEvent += DayChanged;
    }


    //would be nice to have an option to skip a letter for example
    private void ShowEnvelope(bool show)
    {
        //Debug.Log("Got event, open envelope!");
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

    private void DayChanged(int i)
    {
        //Debug.Log("Switched to the next day");
        UpdateText(i);
    }

    private void UpdateText(int newDay)
    {
        Debug.Log("Update text now");
        
        //limit day count
        if(newDay > texts.Count)
        {
            dayIndex.Value = 0;
            newDay = 0;
        }

        envelopeText.text = texts[newDay].letterSender[0];
        letterText.text = texts[newDay].letters[0];
    }

    void OnDestroy()
    {
        clickLetterPileEvent.OnScriptableEvent -= ShowEnvelope;
        OpenLetterEvent.OnScriptableEvent -= OpenLetter;
        dayIndex.OnValueChangedEvent -= DayChanged;
    }
}
