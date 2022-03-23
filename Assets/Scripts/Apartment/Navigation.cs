using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ScriptableData;
using Cinemachine;
using System.Linq;

[RequireComponent(typeof(PlayerInput))]
public class Navigation : MonoBehaviour
{
    private PlayerInputs _input;
    private int layerMask;
    private float distance = 50f;

    [SerializeField]
    private List<CinemachineVirtualCamera> virtualCamsInScene = new List<CinemachineVirtualCamera>();
    [SerializeField]
    private SDInt dayIndex; 
    private CinemachineVirtualCamera prevVCam;

    // just for scriptable data testing
    // [SerializeField]
    // //private ScriptableData.ScriptableEvent<ScriptableData.SDInt> testEvent;
    // [SerializeField]
    // private ScriptableData.SDInt sInt;

    //public ScriptableEvent testEvent; 
    //public SEBool testBoolEvent; 

    //private bool flipflop = false;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Clickable");
        _input = GetComponent<PlayerInputs>();
        //SortCameras();
        prevVCam = virtualCamsInScene.ElementAt(0);
        dayIndex.OnValueChangedEvent += ResetVCamPriority;
    }

    void Update()
    {
        if(_input.click)
        {
            //Debug.Log("Player clicked at: " + _input.look + " Coordinates");
            _input.click = false;
            //translate to world pos, see if player clicked letter pile
            //or other objects in world
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(_input.look);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, layerMask))
            {
                //draw invisible ray cast/vector
                //Debug.DrawLine(ray.origin, hit.point);
                //log hit area to the console
                //Debug.Log(hit.transform.gameObject.name);
                //hit.transform.parent.gameObject.name;

                //check if hit object has a IInteractable interface
                IInteractable obj = hit.transform.gameObject.GetComponent<IInteractable>();
                if(obj != null)
                {
                    prevVCam.Priority = 0;
                    obj.OnClick();
                    prevVCam = obj.GetVCam();
                    // testBoolEvent.Invoke(flipflop);
                    // flipflop = !flipflop;
                    // testEvent.Invoke();

                }

                //testEvent.Invoke(sInt);
                //sInt.Value += 5;
            }
        }
        else if(_input.rightClick)
        {
            _input.rightClick = false;
            //should add lock states for this, such as when reading letters etc. busy work tho
            ResetVCamPriority(0);
        }
        //SortCameras();

        //could make scriptable data that holds index to vcam in list
        // or could make scriptable data that holds keyvaluepair of vcam and index??
    }

    public void ResetVCamPriority(int i)
    {
        foreach(CinemachineVirtualCamera virtCam in virtualCamsInScene)
        {
            virtCam.Priority = 0;
        }
        //set appartment overview camera (SHOULD be first element) to highest priority
        virtualCamsInScene.ElementAt(0).Priority = 1;
    }

    /// <summary>
    /// Sorts camera in order of priority. Highest priority is first element in list
    /// </summary>
    void SortCameras()
    {
        virtualCamsInScene = virtualCamsInScene.OrderByDescending(x => x.Priority).ToList();
    }
}
