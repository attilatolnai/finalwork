using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounter : MonoBehaviour
{
    public TMP_Text CounterUp;
    public int totalItems = 6; // Total number of grabbable items
    private int grabbedItems = 0; // Counter for grabbed items

    private void Start()
    {
        grabbedItems = 0; // Initialize grabbedItems to 0 at the start
        UpdateCounterDisplay();
    }

    public void IncrementCounter()
    {
        grabbedItems++;
        PlayerPrefs.SetInt("GrabbedItemsCount", grabbedItems);
        UpdateCounterDisplay();
    }

    private void UpdateCounterDisplay()
    {
        CounterUp.text = grabbedItems + "/" + totalItems;
    }
}
