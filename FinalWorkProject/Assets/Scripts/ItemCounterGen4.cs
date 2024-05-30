using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterGen4 : MonoBehaviour
{
    public TMP_Text CounterUpGen4;
    public int totalItemsGen4 = 6; // Total number of grabbable items
    private int grabbedItemsGen4 = 0; // Counter for grabbed items

    private void Start()
    {
        grabbedItemsGen4 = 0; // Initialize grabbedItems to 0 at the start
        UpdateCounterDisplayGen4();
    }

    public void IncrementCounterGen4()
    {
        grabbedItemsGen4++;
        PlayerPrefs.SetInt("GrabbedItemsCountGen4", grabbedItemsGen4);
        UpdateCounterDisplayGen4();
    }

    private void UpdateCounterDisplayGen4()
    {
        CounterUpGen4.text = grabbedItemsGen4 + "/" + totalItemsGen4;
    }
}
