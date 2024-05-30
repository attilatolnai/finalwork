using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimelineCounter : MonoBehaviour
{
    public TMP_Text CounterText;
    public int totalItems = 6; 

    public TMP_Text CounterTextGen4;
    public int totalItemsGen4 = 6; // Total number of grabbable items in gen4

    private void Start()
    {
        // Load the grabbed items count from PlayerPrefs
        int grabbedItems = PlayerPrefs.GetInt("GrabbedItemsCount", 0);
        UpdateCounterDisplay(grabbedItems);

        int grabbedItemsGen4 = PlayerPrefs.GetInt("GrabbedItemsCountGen4", 0);
        UpdateCounterDisplayGen4(grabbedItemsGen4);
    }

    private void UpdateCounterDisplay(int grabbedItems)
    {
        CounterText.text = grabbedItems + "/" + totalItems;
    }
    private void UpdateCounterDisplayGen4(int grabbedItemsGen4)
    {
        CounterTextGen4.text = grabbedItemsGen4 + "/" + totalItemsGen4;
    }
}
