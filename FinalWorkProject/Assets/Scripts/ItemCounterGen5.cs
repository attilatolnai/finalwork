using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterGen5 : MonoBehaviour
{
    public TMP_Text CounterUpGen5;
    public int totalItemsGen5 = 9; // Total number of grabbable items
    private int grabbedItemsGen5 = 0; // Counter for grabbed items

    private void Start()
    {
        grabbedItemsGen5 = 0; // Initialize grabbedItems to 0 at the start
        UpdateCounterDisplayGen5();
    }

    public void IncrementCounterGen5()
    {
        grabbedItemsGen5++;
        PlayerPrefs.SetInt("GrabbedItemsCountGen5", grabbedItemsGen5);
        UpdateCounterDisplayGen5();
    }

    private void UpdateCounterDisplayGen5()
    {
        CounterUpGen5.text = grabbedItemsGen5 + "/" + totalItemsGen5;
    }
}
