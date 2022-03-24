using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PCController : MonoBehaviour
{
    //control the UI of the PC 
    [SerializeField]
    private VideoPlayer FMVScreen;

    private void Awake()
    {
        FMVScreen.loopPointReached += CloseFMV;
        FMVScreen.gameObject.SetActive(false);
    }

    private void CloseFMV(VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
    }

    public void PlayFMV()
    {
        FMVScreen.gameObject.SetActive(true);

    }
}
