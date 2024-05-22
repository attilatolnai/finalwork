using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPages : MonoBehaviour
{
    public GameObject InventoryConsoleMenu;
    public Button Page1Btn;
    public Button Page2Btn;
    public Button Page3Btn;

    private List<Transform> pages = new List<Transform>();
    private int currentPage = 0;

    void Start()
    {
        // Collect all the pages
        foreach (Transform child in InventoryConsoleMenu.transform)
        {
            pages.Add(child);
            child.gameObject.SetActive(false);
        }

        // Show the first page
        if (pages.Count > 0)
        {
            pages[0].gameObject.SetActive(true);
        }

        // Set up button listeners
        Page1Btn.onClick.AddListener(() => ShowPage(0));
        Page2Btn.onClick.AddListener(() => ShowPage(1));
        Page3Btn.onClick.AddListener(() => ShowPage(2));

        UpdateButtonState();
    }

    void ShowPage(int pageIndex)
    {
        if (pageIndex >= 0 && pageIndex < pages.Count)
        {
            pages[currentPage].gameObject.SetActive(false);
            currentPage = pageIndex;
            pages[currentPage].gameObject.SetActive(true);
            UpdateButtonState();
        }
    }

    void UpdateButtonState()
    {
        Page1Btn.interactable = currentPage != 0;
        Page2Btn.interactable = currentPage != 1;
        Page3Btn.interactable = currentPage != 2;
    }
}
