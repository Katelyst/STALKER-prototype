using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ScriptableData;

[RequireComponent(typeof(PlayerInput))]
public class Navigation : MonoBehaviour
{
    private PlayerInputs _input;
    private int layerMask;
    private float distance = 50f;

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
                    obj.OnClick();

                    // testBoolEvent.Invoke(flipflop);
                    // flipflop = !flipflop;
                    // testEvent.Invoke();

                }

                //testEvent.Invoke(sInt);
                //sInt.Value += 5;
            }
        }
    }
}
