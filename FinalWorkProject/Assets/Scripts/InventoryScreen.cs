using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : MonoBehaviour
{
    public GameObject InventoryCanvas;
    public GameObject UICanvas;

    private bool inventoryActive = false;

    void Update()
    {
        // Check if the B button is pressed on the right controller
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        // Toggle between enabling/disabling InventoryCanvas and UICanvas
        inventoryActive = !inventoryActive;
        InventoryCanvas.SetActive(inventoryActive);
        UICanvas.SetActive(!inventoryActive);
    }
}
