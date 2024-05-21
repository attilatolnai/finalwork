using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class KeepInventoryCheck : MonoBehaviour
{
    public static KeepInventoryCheck Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetItemGrabbed(string itemName, bool isGrabbed)
    {
        PlayerPrefs.SetInt(itemName, isGrabbed ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool IsItemGrabbed(string itemName)
    {
        return PlayerPrefs.GetInt(itemName, 0) == 1;
    }
}
