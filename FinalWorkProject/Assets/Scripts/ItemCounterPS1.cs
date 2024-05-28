using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterPS1 : MonoBehaviour
{
    public TMP_Text CounterUpPS1;
    public int totalItemsPS1 = 3;
    private int grabbedItemsPS1 = 0;

    private void Start()
    {
        grabbedItemsPS1 = 0;
        UpdateCounterDisplayPS1();
    }

    public void IncrementCounterPS1()
    {
        grabbedItemsPS1++;
        PlayerPrefs.SetInt("GrabbedItemsPS1Count", grabbedItemsPS1);
        UpdateCounterDisplayPS1();
    }

    private void UpdateCounterDisplayPS1()
    {
        CounterUpPS1.text = grabbedItemsPS1 + "/" + totalItemsPS1;
    }
}
