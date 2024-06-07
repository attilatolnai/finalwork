using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterGen9 : MonoBehaviour
{
    public TMP_Text CounterUpGen9;
    public int totalItemsGen9 = 6; // Total number of grabbable items
    private int grabbedItemsGen9 = 0; // Counter for grabbed items

    private void Start()
    {
        grabbedItemsGen9 = 0; // Initialize grabbedItems to 0 at the start
        UpdateCounterDisplayGen9();
    }

    public void IncrementCounterGen9()
    {
        grabbedItemsGen9++;
        PlayerPrefs.SetInt("GrabbedItemsCountGen9", grabbedItemsGen9);
        UpdateCounterDisplayGen9();
    }

    private void UpdateCounterDisplayGen9()
    {
        CounterUpGen9.text = grabbedItemsGen9 + "/" + totalItemsGen9;
    }
}
