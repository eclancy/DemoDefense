using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PurchaseScript : MonoBehaviour
{
    //Objects for clicking
    GraphicRaycaster Raycaster;
    PointerEventData PointerEventData;
    EventSystem EventSystem;
    public string CurrentPurchaseSelection = "None";

    //Objects that can be purchased
    public PlayerStats PlayerStats;
    public GameObject QuakeTower;
    public int QuakeTowerCost = 20;

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

            //Find where on the scene the click occured
            Vector3 ScenePositionClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ScenePositionClicked.z = 0; //Move point infront of background

            //Raycast the click point to find what was clicked on the canvas
            List<RaycastResult> CanvasHitResults = new List<RaycastResult>();
            Raycaster.Raycast(PointerEventData, CanvasHitResults);

            //Process list of what was clicked on the canvas
            foreach (RaycastResult result in CanvasHitResults)
            {
                string ClickedObjectName = result.gameObject.name;
                //Debug.Log(result.gameObject.name + " Clicked");

                //Assign Tower to be Purchased is purchase button clicked.
                if(ClickedObjectName == "QuakeTower")
                {
                    Debug.Log("Buying Quake Tower");
                    CurrentPurchaseSelection = "QuakeTower";
                }
                if(ClickedObjectName == "Tower2")
                {
                    Debug.Log("Buying Tower 2");
                    CurrentPurchaseSelection = "Tower2";
                }
            }

            //Process ScenePositionClicked
            if(
                CurrentPurchaseSelection != "None" && //Something is selcted to be purchased
                CanvasHitResults.Count == 0 //Canvas not clicked 
            )
            {
                //Buy and place QuakeTower if able
                if(CurrentPurchaseSelection == "QuakeTower" && PlayerStats.currency >= QuakeTowerCost)
                {
                    PlayerStats.currency = PlayerStats.currency - QuakeTowerCost;
                    Instantiate(QuakeTower, ScenePositionClicked, Quaternion.identity);
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
