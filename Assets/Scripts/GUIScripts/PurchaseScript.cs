using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PurchaseScript : MonoBehaviour
{
    GraphicRaycaster Raycaster;
    PointerEventData PointerEventData;
    EventSystem EventSystem;

    void Start()
    {
        //Load Components
        Raycaster = GetComponent<GraphicRaycaster>();
        EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Get the point clicked
            PointerEventData = new PointerEventData(EventSystem);
            PointerEventData.position = Input.mousePosition;

            //Raycast the click point to find what was clicked
            List<RaycastResult> results = new List<RaycastResult>();
            Raycaster.Raycast(PointerEventData, results);

            //Process list of what was clicked
            foreach (RaycastResult result in results)
            {
                Debug.Log(result.gameObject.name + " Clicked");
            }
        }
    }
}
