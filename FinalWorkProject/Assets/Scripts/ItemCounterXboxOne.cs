using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterXboxOne : MonoBehaviour
{
    public TMP_Text CounterUpXboxOne;
    public int totalItemsXboxOne = 3;
    private int grabbedItemsXboxOne = 0;

    private void Start()
    {
        grabbedItemsXboxOne = 0;
        UpdateCounterDisplayXboxOne();
    }

    public void IncrementCounterXboxOne()
    {
        grabbedItemsXboxOne++;
        PlayerPrefs.SetInt("GrabbedItemsXboxOneCount", grabbedItemsXboxOne);
        UpdateCounterDisplayXboxOne();
    }

    private void UpdateCounterDisplayXboxOne()
    {
        CounterUpXboxOne.text = grabbedItemsXboxOne + "/" + totalItemsXboxOne;
    }
}
