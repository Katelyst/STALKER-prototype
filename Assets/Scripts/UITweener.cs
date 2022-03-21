using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweener : MonoBehaviour
{
    private Transform currTrans;
    private Vector3 transScale;

    [SerializeField]
    private float tweenTime = 0.5f;
    [SerializeField]
    private bool tweenOnEnable = true;

    void Awake()
    {
        //Debug.Log("<color=green>SETTING TRANSFORM HERE!</color>");
        currTrans = transform;
        transScale = transform.localScale;
        if(tweenOnEnable)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }


    void OnEnable()
    {
        if(!tweenOnEnable)
            return;

        //Debug.Log("Current transform scale: " + transform.localScale);
        //make small
        transform.localScale = (currTrans.localScale * 0.5f);
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, transScale, tweenTime).setEaseOutBounce();

        //Debug.Log(" <color=red>Enabled thing!</color> ");
    }

    public void TweenUI(bool doTween)
    {
        gameObject.SetActive(true);
        transform.localScale = (currTrans.localScale * 0.9f);
        LeanTween.scale(gameObject, transScale, tweenTime).setLoopPingPong().setEaseOutSine();
        if(!doTween)
            LeanTween.cancel(gameObject);
    }
}
