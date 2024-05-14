using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryChanger : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject InventoryConsoleMenu;
    public GameObject InventoryControllerMenu;
    public GameObject InventoryCartridgeMenu;
    public GameObject InventoryCaseMenu;
    public GameObject InventoryGameMenu;

    public void ConsoleBtnClick()
    {
        //Enable InventoryConsoleMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(true);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(false);
    }

    public void ControllerBtnClick()
    {
        //Enable InventoryControllerMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(true);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(false);
    }

    public void CartridgeBtnClick()
    {
        //Enable InventoryCartridgeMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(true);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(false);
    }

    public void CaseBtnClick()
    {
        //Enable InventoryCaseMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(true);
        InventoryGameMenu.SetActive(false);
    }

    public void GameBtnClick()
    {
        //Enable InventoryGameMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(true);
    }
}
