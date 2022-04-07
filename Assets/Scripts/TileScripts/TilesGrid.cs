using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGrid : MonoBehaviour
{
    private bool DebugFlag = false;
    private List<List<Transform>> TilesGridReference = new List<List<Transform>>();

    void Start()
    {
        Transform[] TilesArray = GetComponentsInChildren<Transform>();

        List<Transform> TempRowArray = new List<Transform>();

        for (int i = 1; i < TilesArray.Length; i++ ){
            if( TilesArray[i].name.Contains("Row") ){
                //ignore the first row
                if(TempRowArray.Count > 0){
                    TilesGridReference.Add(TempRowArray);
                    TempRowArray = new List<Transform>();
                }
            }
            
            if( TilesArray[i].name.Contains("Column") ){
                TempRowArray.Add(TilesArray[i]);
            }
        }
        //add final row
        TilesGridReference.Add(TempRowArray);

        if(DebugFlag){Debug.Log(TilesGridReference[2][1]);}
    }

    
}
