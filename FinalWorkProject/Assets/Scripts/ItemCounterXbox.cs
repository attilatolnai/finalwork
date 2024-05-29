using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterXbox : MonoBehaviour
{
    public TMP_Text CounterUpXbox;
    public int totalItemsXbox = 3;
    private int grabbedItemsXbox = 0;

    private void Start()
    {
        grabbedItemsXbox = 0;
        UpdateCounterDisplayXbox();
    }

    public void IncrementCounterXbox()
    {
        grabbedItemsXbox++;
        PlayerPrefs.SetInt("GrabbedItemsXboxCount", grabbedItemsXbox);
        UpdateCounterDisplayXbox();
    }

    private void UpdateCounterDisplayXbox()
    {
        CounterUpXbox.text = grabbedItemsXbox + "/" + totalItemsXbox;
    }
}
