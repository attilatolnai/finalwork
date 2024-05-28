using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterAtari : MonoBehaviour
{
    public TMP_Text CounterUpAtari;
    public int totalItemsAtari = 3;
    private int grabbedItemsAtari = 0;

    private void Start()
    {
        grabbedItemsAtari = 0;
        UpdateCounterDisplayAtari();
    }

    public void IncrementCounterAtari()
    {
        grabbedItemsAtari++;
        PlayerPrefs.SetInt("GrabbedItemsAtariCount", grabbedItemsAtari);
        UpdateCounterDisplayAtari();
    }

    private void UpdateCounterDisplayAtari()
    {
        CounterUpAtari.text = grabbedItemsAtari + "/" + totalItemsAtari;
    }
}
