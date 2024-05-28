using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterNES : MonoBehaviour
{
    public TMP_Text CounterUpNES;
    public int totalItemsNES = 3;
    private int grabbedItemsNES = 0;

    private void Start()
    {
        grabbedItemsNES = 0;
        UpdateCounterDisplayNES();
    }

    public void IncrementCounterNES()
    {
        grabbedItemsNES++;
        PlayerPrefs.SetInt("GrabbedItemsNESCount", grabbedItemsNES);
        UpdateCounterDisplayNES();
    }

    private void UpdateCounterDisplayNES()
    {
        CounterUpNES.text = grabbedItemsNES + "/" + totalItemsNES;
    }
}
