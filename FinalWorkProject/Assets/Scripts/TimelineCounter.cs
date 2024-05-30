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

    public TMP_Text CounterTextGen5;
    public int totalItemsGen5 = 6; // Total number of grabbable items in gen5

    private void Start()
    {
        // Load the grabbed items count from PlayerPrefs
        int grabbedItems = PlayerPrefs.GetInt("GrabbedItemsCount", 0);
        UpdateCounterDisplay(grabbedItems);

        int grabbedItemsGen4 = PlayerPrefs.GetInt("GrabbedItemsCountGen4", 0);
        UpdateCounterDisplayGen4(grabbedItemsGen4);

        int grabbedItemsGen5 = PlayerPrefs.GetInt("GrabbedItemsCountGen5", 0);
        UpdateCounterDisplayGen5(grabbedItemsGen5);
    }

    private void UpdateCounterDisplay(int grabbedItems){
        CounterText.text = grabbedItems + "/" + totalItems;
    }
    private void UpdateCounterDisplayGen4(int grabbedItemsGen4){
        CounterTextGen4.text = grabbedItemsGen4 + "/" + totalItemsGen4;
    }
    private void UpdateCounterDisplayGen5(int grabbedItemsGen5){
        CounterTextGen5.text = grabbedItemsGen5 + "/" + totalItemsGen5;
    }
}
