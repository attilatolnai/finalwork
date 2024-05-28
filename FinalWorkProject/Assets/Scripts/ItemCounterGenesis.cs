using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterGenesis : MonoBehaviour
{
    public TMP_Text CounterUpGenesis;
    public int totalItemsGenesis = 3;
    private int grabbedItemsGenesis = 0;

    private void Start()
    {
        grabbedItemsGenesis = 0;
        UpdateCounterDisplayGenesis();
    }

    public void IncrementCounterGenesis()
    {
        grabbedItemsGenesis++;
        PlayerPrefs.SetInt("GrabbedItemsGenesisCount", grabbedItemsGenesis);
        UpdateCounterDisplayGenesis();
    }

    private void UpdateCounterDisplayGenesis()
    {
        CounterUpGenesis.text = grabbedItemsGenesis + "/" + totalItemsGenesis;
    }
}
