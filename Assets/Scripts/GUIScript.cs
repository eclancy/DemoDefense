using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    public PlayerStats PlayerStats;

    public TMPro.TextMeshProUGUI HealthTextObj;
    public TMPro.TextMeshProUGUI CurrencyTextObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthTextObj.text = PlayerStats.health.ToString();
        CurrencyTextObj.text = PlayerStats.currency.ToString();
    }
}
