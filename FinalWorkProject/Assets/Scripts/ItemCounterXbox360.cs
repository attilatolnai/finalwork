using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterXbox360 : MonoBehaviour
{
    public TMP_Text CounterUpXbox360;
    public int totalItemsXbox360 = 3;
    private int grabbedItemsXbox360 = 0;

    private void Start()
    {
        grabbedItemsXbox360 = 0;
        UpdateCounterDisplayXbox360();
    }

    public void IncrementCounterXbox360()
    {
        grabbedItemsXbox360++;
        PlayerPrefs.SetInt("GrabbedItemsXbox360Count", grabbedItemsXbox360);
        UpdateCounterDisplayXbox360();
    }

    private void UpdateCounterDisplayXbox360()
    {
        CounterUpXbox360.text = grabbedItemsXbox360 + "/" + totalItemsXbox360;
    }
}
