using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterSaturn : MonoBehaviour
{
    public TMP_Text CounterUpSaturn;
    public int totalItemsSaturn = 3;
    private int grabbedItemsSaturn = 0;

    private void Start()
    {
        grabbedItemsSaturn = 0;
        UpdateCounterDisplaySaturn();
    }

    public void IncrementCounterSaturn()
    {
        grabbedItemsSaturn++;
        PlayerPrefs.SetInt("GrabbedItemsSaturnCount", grabbedItemsSaturn);
        UpdateCounterDisplaySaturn();
    }

    private void UpdateCounterDisplaySaturn()
    {
        CounterUpSaturn.text = grabbedItemsSaturn + "/" + totalItemsSaturn;
    }
}
