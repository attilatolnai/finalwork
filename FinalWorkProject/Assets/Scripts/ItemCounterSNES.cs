using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCounterSNES : MonoBehaviour
{
    public TMP_Text CounterUpSNES;
    public int totalItemsSNES = 3;
    private int grabbedItemsSNES = 0;

    private void Start()
    {
        grabbedItemsSNES = 0;
        UpdateCounterDisplaySNES();
    }

    public void IncrementCounterSNES()
    {
        grabbedItemsSNES++;
        PlayerPrefs.SetInt("GrabbedItemsSNESCount", grabbedItemsSNES);
        UpdateCounterDisplaySNES();
    }

    private void UpdateCounterDisplaySNES()
    {
        CounterUpSNES.text = grabbedItemsSNES + "/" + totalItemsSNES;
    }
}
