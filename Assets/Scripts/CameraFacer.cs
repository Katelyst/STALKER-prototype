using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacer : MonoBehaviour
{
    [SerializeField][Tooltip("The transform to face, probably camera. Not required, if left null object will face main camera")]
    private Transform target = null;

    void LateUpdate()
    {
        if(!target)
        {
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            transform.LookAt(target);
        }
        transform.Rotate(Vector3.up - (Vector3.up * 180));
    }
}
