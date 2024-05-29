using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterXboxSeries : MonoBehaviour
{
    public TMP_Text CounterUpXboxSeries;
    public int totalItemsXboxSeries = 3;
    private int grabbedItemsXboxSeries = 0;

    private void Start()
    {
        grabbedItemsXboxSeries = 0;
        UpdateCounterDisplayXboxSeries();
    }

    public void IncrementCounterXboxSeries()
    {
        grabbedItemsXboxSeries++;
        PlayerPrefs.SetInt("GrabbedItemsXboxSeriesCount", grabbedItemsXboxSeries);
        UpdateCounterDisplayXboxSeries();
    }

    private void UpdateCounterDisplayXboxSeries()
    {
        CounterUpXboxSeries.text = grabbedItemsXboxSeries + "/" + totalItemsXboxSeries;
    }
}
