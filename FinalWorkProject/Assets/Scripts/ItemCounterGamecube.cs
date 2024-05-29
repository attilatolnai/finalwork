using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterGamecube : MonoBehaviour
{
    public TMP_Text CounterUpGamecube;
    public int totalItemsGamecube = 3;
    private int grabbedItemsGamecube = 0;

    private void Start()
    {
        grabbedItemsGamecube = 0;
        UpdateCounterDisplayGamecube();
    }

    public void IncrementCounterGamecube()
    {
        grabbedItemsGamecube++;
        PlayerPrefs.SetInt("GrabbedItemsGamecubeCount", grabbedItemsGamecube);
        UpdateCounterDisplayGamecube();
    }

    private void UpdateCounterDisplayGamecube()
    {
        CounterUpGamecube.text = grabbedItemsGamecube + "/" + totalItemsGamecube;
    }
}
