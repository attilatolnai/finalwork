using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterSwitch : MonoBehaviour
{
    public TMP_Text CounterUpSwitch;
    public int totalItemsSwitch = 3;
    private int grabbedItemsSwitch = 0;

    private void Start()
    {
        grabbedItemsSwitch = 0;
        UpdateCounterDisplaySwitch();
    }

    public void IncrementCounterSwitch()
    {
        grabbedItemsSwitch++;
        PlayerPrefs.SetInt("GrabbedItemsSwitchCount", grabbedItemsSwitch);
        UpdateCounterDisplaySwitch();
    }

    private void UpdateCounterDisplaySwitch()
    {
        CounterUpSwitch.text = grabbedItemsSwitch + "/" + totalItemsSwitch;
    }
}
