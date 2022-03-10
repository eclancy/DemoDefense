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
    public string CurrentPurchaseSelection = "None";

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

            //Debug.Log("Point clicked: " + PointerEventData.position);

            //Raycast the click point to find what was clicked on the canvas
            List<RaycastResult> results = new List<RaycastResult>();
            Raycaster.Raycast(PointerEventData, results);

            //Process list of what was clicked
            foreach (RaycastResult result in results)
            {
                string ClickedObjectName = result.gameObject.name;
                //Debug.Log(result.gameObject.name + " Clicked");

                //Assign Tower to be Purchased is purchase button clicked.
                if(ClickedObjectName == "Tower1")
                {
                    Debug.Log("Buying Tower 1");
                    CurrentPurchaseSelection = "Tower1";
                }
                if(ClickedObjectName == "Tower2")
                {
                    Debug.Log("Buying Tower 2");
                    CurrentPurchaseSelection = "Tower2";
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Clear Selected Buy");
            CurrentPurchaseSelection = "None";
        }
    }
}
