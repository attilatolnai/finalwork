using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterPS2 : MonoBehaviour
{
    public TMP_Text CounterUpPS2;
    public int totalItemsPS2 = 3;
    private int grabbedItemsPS2 = 0;

    private void Start()
    {
        grabbedItemsPS2 = 0;
        UpdateCounterDisplayPS2();
    }

    public void IncrementCounterPS2()
    {
        grabbedItemsPS2++;
        PlayerPrefs.SetInt("GrabbedItemsPS2Count", grabbedItemsPS2);
        UpdateCounterDisplayPS2();
    }

    private void UpdateCounterDisplayPS2()
    {
        CounterUpPS2.text = grabbedItemsPS2 + "/" + totalItemsPS2;
    }
}
