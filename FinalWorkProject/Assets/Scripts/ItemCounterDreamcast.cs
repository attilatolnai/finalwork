using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterDreamcast : MonoBehaviour
{
    public TMP_Text CounterUpDreamcast;
    public int totalItemsDreamcast = 3;
    private int grabbedItemsDreamcast = 0;

    private void Start()
    {
        grabbedItemsDreamcast = 0;
        UpdateCounterDisplayDreamcast();
    }

    public void IncrementCounterDreamcast()
    {
        grabbedItemsDreamcast++;
        PlayerPrefs.SetInt("GrabbedItemsDreamcastCount", grabbedItemsDreamcast);
        UpdateCounterDisplayDreamcast();
    }

    private void UpdateCounterDisplayDreamcast()
    {
        CounterUpDreamcast.text = grabbedItemsDreamcast + "/" + totalItemsDreamcast;
    }
}
