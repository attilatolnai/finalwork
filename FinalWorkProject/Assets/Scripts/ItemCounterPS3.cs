using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterPS3 : MonoBehaviour
{
    public TMP_Text CounterUpPS3;
    public int totalItemsPS3 = 3;
    private int grabbedItemsPS3 = 0;

    private void Start()
    {
        grabbedItemsPS3 = 0;
        UpdateCounterDisplayPS3();
    }

    public void IncrementCounterPS3()
    {
        grabbedItemsPS3++;
        PlayerPrefs.SetInt("GrabbedItemsPS3Count", grabbedItemsPS3);
        UpdateCounterDisplayPS3();
    }

    private void UpdateCounterDisplayPS3()
    {
        CounterUpPS3.text = grabbedItemsPS3 + "/" + totalItemsPS3;
    }
}
