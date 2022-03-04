using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointReference : MonoBehaviour
{
    public GameObject WaypointContainer;
    private Transform[] Waypoints;

    public Transform[] GetWaypoints(){
        return Waypoints;
    }

    void Start(){
        Waypoints = WaypointContainer.GetComponentsInChildren<Transform>();
    }
}
