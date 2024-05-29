using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterWii : MonoBehaviour
{
    public TMP_Text CounterUpWii;
    public int totalItemsWii = 3;
    private int grabbedItemsWii = 0;

    private void Start()
    {
        grabbedItemsWii = 0;
        UpdateCounterDisplayWii();
    }

    public void IncrementCounterWii()
    {
        grabbedItemsWii++;
        PlayerPrefs.SetInt("GrabbedItemsWiiCount", grabbedItemsWii);
        UpdateCounterDisplayWii();
    }

    private void UpdateCounterDisplayWii()
    {
        CounterUpWii.text = grabbedItemsWii + "/" + totalItemsWii;
    }
}
