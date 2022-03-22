using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableData;
using Cinemachine;

public interface IInteractable
{
    //public ScriptableData<T0> scrData;

    public void OnClick();
    public void Sample(int id);
    public CinemachineVirtualCamera GetVCam();
}
