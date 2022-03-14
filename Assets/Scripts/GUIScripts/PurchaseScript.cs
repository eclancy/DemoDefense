using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PurchaseScript : MonoBehaviour
{
    //Objects for clicking
    GraphicRaycaster GRaycaster;
    Physics2DRaycaster SceneRayCaster;
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
        GRaycaster = GetComponent<GraphicRaycaster>();
        EventSystem = GetComponent<EventSystem>();
        SceneRayCaster = Camera.main.GetComponent<Physics2DRaycaster>();
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
            GRaycaster.Raycast(PointerEventData, CanvasHitResults);
            bool GUIClicked = false;

            //Process list of what was clicked on the canvas
            foreach (RaycastResult result in CanvasHitResults)
            {
                GUIClicked = true;
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

            if(!GUIClicked)
            {
                //Raycast the click point to find what was clicked on the scene
                List<RaycastResult> SceneHitResults = new List<RaycastResult>();
                SceneRayCaster.Raycast(PointerEventData, SceneHitResults);

                //Process list of what was clicked on the scene
                foreach (RaycastResult result in SceneHitResults)
                {
                    string ClickedObjectName = result.gameObject.name;
                    Debug.Log(ClickedObjectName + " Clicked");

                    if(
                        ClickedObjectName.Contains("BuildSlot") //A Build Slot is clicked
                        && CurrentPurchaseSelection != "None" //Something is selcted to be purchased
                    )
                    {
                        TowerBuildTileScript BuildSlot = result.gameObject.GetComponent<TowerBuildTileScript>();
                        if(BuildSlot.Tower == "None") //Build slot is open
                        {
                            //Buy and place QuakeTower in build slot if able
                            if(CurrentPurchaseSelection == "QuakeTower" && PlayerStats.currency >= QuakeTowerCost)
                            {
                                PlayerStats.currency = PlayerStats.currency - QuakeTowerCost;
                                Instantiate(QuakeTower, result.gameObject.transform.position, Quaternion.identity, result.gameObject.transform);
                                BuildSlot.Tower = "QuakeTower";
                                BuildSlot.TowerLevel = 1;
                            }
                        }
                        else
                        {
                            //Upgrade Tower TODO
                        }
                    }

                }
            }
        }

        //Check if the right Mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Clear Selected Buy");
            CurrentPurchaseSelection = "None";
        }
    }
}
