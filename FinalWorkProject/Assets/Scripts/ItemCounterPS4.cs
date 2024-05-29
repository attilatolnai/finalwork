using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterPS4 : MonoBehaviour
{
    public TMP_Text CounterUpPS4;
    public int totalItemsPS4 = 3;
    private int grabbedItemsPS4 = 0;

    private void Start()
    {
        grabbedItemsPS4 = 0;
        UpdateCounterDisplayPS4();
    }

    public void IncrementCounterPS4()
    {
        grabbedItemsPS4++;
        PlayerPrefs.SetInt("GrabbedItemsPS4Count", grabbedItemsPS4);
        UpdateCounterDisplayPS4();
    }

    private void UpdateCounterDisplayPS4()
    {
        CounterUpPS4.text = grabbedItemsPS4 + "/" + totalItemsPS4;
    }
}
