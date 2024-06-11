using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimelineCounter : MonoBehaviour
{
    public TMP_Text CounterText;
    public int totalItems = 6;

    public TMP_Text CounterTextGen4;
    public int totalItemsGen4 = 6; // Total number of grabbable items in gen4

    public TMP_Text CounterTextGen6;
    public int totalItemsGen6 = 12; // Total number of grabbable items in gen6

    public TMP_Text CounterTextGen9;
    public int totalItemsGen9 = 6; // Total number of grabbable items in gen9

    private void Start()
    {
        InitializePlayerPrefs();
        LoadCounters();
    }

    private void InitializePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("GrabbedItemsCount"))
        {
            PlayerPrefs.SetInt("GrabbedItemsCount", 0);
        }
        if (!PlayerPrefs.HasKey("GrabbedItemsCountGen4"))
        {
            PlayerPrefs.SetInt("GrabbedItemsCountGen4", 0);
        }
        if (!PlayerPrefs.HasKey("GrabbedItemsCountGen6"))
        {
            PlayerPrefs.SetInt("GrabbedItemsCountGen6", 0);
        }
        if (!PlayerPrefs.HasKey("GrabbedItemsCountGen9"))
        {
            PlayerPrefs.SetInt("GrabbedItemsCountGen9", 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadCounters()
    {
        int grabbedItems = PlayerPrefs.GetInt("GrabbedItemsCount", 0);
        UpdateCounterDisplay(grabbedItems);

        int grabbedItemsGen4 = PlayerPrefs.GetInt("GrabbedItemsCountGen4", 0);
        UpdateCounterDisplayGen4(grabbedItemsGen4);

        int grabbedItemsGen6 = PlayerPrefs.GetInt("GrabbedItemsCountGen6", 0);
        UpdateCounterDisplayGen6(grabbedItemsGen6);

        int grabbedItemsGen9 = PlayerPrefs.GetInt("GrabbedItemsCountGen9", 0);
        UpdateCounterDisplayGen9(grabbedItemsGen9);
    }

    private void OnDisable()
    {
        ResetPlayerPrefs();
    }

    private void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("GrabbedItemsCount", 0);
        PlayerPrefs.SetInt("GrabbedItemsCountGen4", 0);
        PlayerPrefs.SetInt("GrabbedItemsCountGen6", 0);
        PlayerPrefs.SetInt("GrabbedItemsCountGen9", 0);
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs reset to 0 on disable");
    }

    private void UpdateCounterDisplay(int grabbedItems)
    {
        CounterText.text = grabbedItems + "/" + totalItems;
    }

    private void UpdateCounterDisplayGen4(int grabbedItemsGen4)
    {
        CounterTextGen4.text = grabbedItemsGen4 + "/" + totalItemsGen4;
    }

    private void UpdateCounterDisplayGen6(int grabbedItemsGen6)
    {
        CounterTextGen6.text = grabbedItemsGen6 + "/" + totalItemsGen6;
    }

    private void UpdateCounterDisplayGen9(int grabbedItemsGen9)
    {
        CounterTextGen9.text = grabbedItemsGen9 + "/" + totalItemsGen9;
    }
}
