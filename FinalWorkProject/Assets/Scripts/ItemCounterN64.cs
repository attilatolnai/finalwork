using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterN64 : MonoBehaviour
{
    public TMP_Text CounterUpN64;
    public int totalItemsN64 = 3;
    private int grabbedItemsN64 = 0;

    private void Start()
    {
        grabbedItemsN64 = 0;
        UpdateCounterDisplayN64();
    }

    public void IncrementCounterN64()
    {
        grabbedItemsN64++;
        PlayerPrefs.SetInt("GrabbedItemsN64Count", grabbedItemsN64);
        UpdateCounterDisplayN64();
    }

    private void UpdateCounterDisplayN64()
    {
        CounterUpN64.text = grabbedItemsN64 + "/" + totalItemsN64;
    }
}
