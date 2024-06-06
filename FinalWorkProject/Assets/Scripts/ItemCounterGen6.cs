using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterGen6 : MonoBehaviour
{
    public TMP_Text CounterUpGen6;
    public int totalItemsGen6 = 12; // Total number of grabbable items
    private int grabbedItemsGen6 = 0; // Counter for grabbed items

    private void Start()
    {
        grabbedItemsGen6 = 0; // Initialize grabbedItems to 0 at the start
        UpdateCounterDisplayGen6();
    }

    public void IncrementCounterGen6()
    {
        grabbedItemsGen6++;
        PlayerPrefs.SetInt("GrabbedItemsCountGen6", grabbedItemsGen6);
        UpdateCounterDisplayGen6();
    }

    private void UpdateCounterDisplayGen6()
    {
        CounterUpGen6.text = grabbedItemsGen6 + "/" + totalItemsGen6;
    }
}
