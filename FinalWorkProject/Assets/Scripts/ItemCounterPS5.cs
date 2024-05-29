using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterPS5 : MonoBehaviour
{
    public TMP_Text CounterUpPS5;
    public int totalItemsPS5 = 3;
    private int grabbedItemsPS5 = 0;

    private void Start()
    {
        grabbedItemsPS5 = 0;
        UpdateCounterDisplayPS5();
    }

    public void IncrementCounterPS5()
    {
        grabbedItemsPS5++;
        PlayerPrefs.SetInt("GrabbedItemsPS5Count", grabbedItemsPS5);
        UpdateCounterDisplayPS5();
    }

    private void UpdateCounterDisplayPS5()
    {
        CounterUpPS5.text = grabbedItemsPS5 + "/" + totalItemsPS5;
    }
}
