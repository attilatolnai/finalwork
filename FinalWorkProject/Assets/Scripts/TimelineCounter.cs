using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimelineCounter : MonoBehaviour
{
    public TMP_Text CounterText;
    public int totalItems = 6; // Total number of grabbable items

    private void Start()
    {
        // Load the grabbed items count from PlayerPrefs
        int grabbedItems = PlayerPrefs.GetInt("GrabbedItemsCount", 0);
        UpdateCounterDisplay(grabbedItems);
    }

    private void UpdateCounterDisplay(int grabbedItems)
    {
        CounterText.text = grabbedItems + "/" + totalItems;
    }
}
