using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Navigation : MonoBehaviour
{
    private PlayerInputs _input;
    private int layerMask;
    private float distance = 50f;

    // just for scriptable data testing
    [SerializeField]
    private ScriptableData.ScriptableEvent<int> testEvent;
    [SerializeField]
    private ScriptableData.SDInt sInt;


    private void Awake()
    {
        layerMask = LayerMask.GetMask("Clickable");
        _input = GetComponent<PlayerInputs>();
    }

    void Update()
    {
        if(_input.click)
        {
            Debug.Log("Player clicked at: " + _input.look + " Coordinates");
            _input.click = false;
            //translate to world pos, see if player clicked letter pile
            //or other objects in world
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(_input.look);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, layerMask))
            {
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit.point);
                //log hit area to the console
                Debug.Log(hit.transform.gameObject.name);
                //hit.transform.parent.gameObject.name;

                //testEvent.Invoke(5);
                sInt.Value += 5;
            }
        }
    }
}
