using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableData;

public class UIFader : MonoBehaviour
{
    [SerializeField][Tooltip("Time it takes to fade in seconds")]
    private float fadeTime = 2.0f;
    [SerializeField]
    private SEBool fadedEvent;
    private RawImage image;
    private Color toCol = new Color(0.0f, 0.0f, 0.0f, 1.0f);  //black
    private Color fromCol = new Color(0.0f, 0.0f, 0.0f, 0.0f);  //transparent

    private void Awake()
    {
        image = GetComponent<RawImage>();
        image.color = fromCol;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //do leantween lerping and callback when done
        LeanTween.value(gameObject, FadedCallBack, fromCol, toCol, fadeTime);
    }

    private void FadedCallBack(Color c)
    {
        //Debug.Log("Current color: " + c + " Target color: " + toCol + " Start color: " + fromCol);
        image.color = c;

        if (c != toCol)
            return;
        //else
        //    Debug.Log("Done tweening!");

        Debug.Log("CalledBack from tweeing");
        //fire event 
        fadedEvent.Invoke(true);
        image.color = fromCol;
        gameObject.SetActive(false);
    }
}
