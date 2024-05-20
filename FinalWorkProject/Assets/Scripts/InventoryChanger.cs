using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryChanger : MonoBehaviour
{
    public AtariScript AtariScript;
    public NESScript NESScript;

    public GameObject InventoryMenu;
    public GameObject InventoryConsoleMenu;
    public GameObject InventoryControllerMenu;
    public GameObject InventoryCartridgeMenu;
    public GameObject InventoryCaseMenu;
    public GameObject InventoryGameMenu;
    public GameObject Inventory_Sidebar;
    public GameObject InfoCanvas;

    public Button ConsoleNameBtn1;
    public Button ConsoleNameBtn2;
    //public Button ConsoleNameBtn3;

    public Button ControllerNameBtn1;
    public Button ControllerNameBtn2;

    public Button CartridgeNameBtn1;
    public Button CartridgeNameBtn2;

    public Button ItemDescriptionReturnBtn;

    public void Start(){
        InfoCanvas.SetActive(false);
        ItemDescriptionReturnBtn.onClick.AddListener(ReturnButtonClick);
    }

    public void ConsoleBtnClick(){
        //Enable InventoryConsoleMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(true);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(false);
        ConsoleNameBtn1.onClick.AddListener(ConsoleNameBtn1Click);
        ConsoleNameBtn2.onClick.AddListener(ConsoleNameBtn2Click);
    }

    public void ControllerBtnClick(){
        //Enable InventoryControllerMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(true);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(false);
        ControllerNameBtn1.onClick.AddListener(ControllerNameBtn1Click);
        ControllerNameBtn2.onClick.AddListener(ControllerNameBtn2Click);
    }

    public void CartridgeBtnClick(){
        //Enable InventoryCartridgeMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(true);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(false);
        CartridgeNameBtn1.onClick.AddListener(CartridgeNameBtn1Click);
        CartridgeNameBtn2.onClick.AddListener(CartridgeNameBtn2Click);
    }

    public void CaseBtnClick(){
        //Enable InventoryCaseMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(true);
        InventoryGameMenu.SetActive(false);
    }

    public void GameBtnClick(){
        //Enable InventoryGameMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(false);
        InventoryGameMenu.SetActive(true);
    }

    public void ConsoleNameBtn1Click(){
        InfoCanvas.SetActive(true);
        AtariScript.AtariConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn2Click(){
        InfoCanvas.SetActive(true);
        NESScript.NESConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn1Click(){
        InfoCanvas.SetActive(true);
        AtariScript.AtariControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn2Click(){
        InfoCanvas.SetActive(true);
        NESScript.NESControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CartridgeNameBtn1Click(){
        InfoCanvas.SetActive(true);
        AtariScript.AtariCartridgeInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CartridgeNameBtn2Click(){
        InfoCanvas.SetActive(true);
        NESScript.NESCartridgeInfo();
        Inventory_Sidebar.SetActive(false);
    }
    
    public void ReturnButtonClick()
    {
        InfoCanvas.SetActive(false);
        Inventory_Sidebar.SetActive(true);
    }
}
