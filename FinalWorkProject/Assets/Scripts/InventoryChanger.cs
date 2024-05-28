using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryChanger : MonoBehaviour
{
[Header("References System scripts")]
    public AtariScript AtariScript;
    public NESScript NESScript;
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;
    public PS1Script PS1Script;
    public N64Script N64Script;
    public SaturnScript SaturnScript;
[Header("References Inventory Menus")]
    public GameObject InventoryMenu;
    public GameObject InventoryConsoleMenu;
    public GameObject InventoryControllerMenu;
    public GameObject InventoryCartridgeMenu;
    public GameObject InventoryCaseMenu;
    public GameObject InventoryGameMenu;
    public GameObject Inventory_Sidebar;
    public GameObject InfoCanvas;
[Header("References ConsoleNameBtn's")]
    public Button ConsoleNameBtn1;
    public Button ConsoleNameBtn2;
    public Button ConsoleNameBtn3;
    public Button ConsoleNameBtn4;
    public Button ConsoleNameBtn5;
    public Button ConsoleNameBtn6;
    public Button ConsoleNameBtn7;
[Header("References ControllerNameBtn's")]
    public Button ControllerNameBtn1;
    public Button ControllerNameBtn2;
    public Button ControllerNameBtn3;
    public Button ControllerNameBtn4;
    public Button ControllerNameBtn5;
    public Button ControllerNameBtn6;
    public Button ControllerNameBtn7;
[Header("References CartridgeNameBtn's")]
    public Button CartridgeNameBtn1;
    public Button CartridgeNameBtn2;
    public Button CartridgeNameBtn3;
    public Button CartridgeNameBtn4;
    public Button CartridgeNameBtn5;
[Header("References CaseNameBtn's")]
    public Button CaseNameBtn1;
    public Button CaseNameBtn2;
[Header("References ItemDescriptionReturnBtn")]
    public Button ItemDescriptionReturnBtn;
[Header("References Pages")]
    public Button Page1Btn;
    public Button Page2Btn;
    public Button Page3Btn;

    private List<Transform> currentPages = new List<Transform>();
    private int currentPage = 0;

    public void Start(){
        InfoCanvas.SetActive(false);
        ItemDescriptionReturnBtn.onClick.AddListener(ReturnButtonClick);

        // Set up button listeners for page buttons
        Page1Btn.onClick.AddListener(() => ShowPage(0));
        Page2Btn.onClick.AddListener(() => ShowPage(1));
        Page3Btn.onClick.AddListener(() => ShowPage(2));

        SetUpPages(InventoryConsoleMenu);
        SetUpPages(InventoryControllerMenu);
        SetUpPages(InventoryCartridgeMenu);
        SetUpPages(InventoryCaseMenu);
    }

    private void SetUpPages(GameObject menu)
    {
        // Initialize pages
        currentPages.Clear();
        foreach (Transform child in menu.transform)
        {
            currentPages.Add(child);
            child.gameObject.SetActive(false);
        }
        // Show the first page
        if (currentPages.Count > 0)
        {
            currentPages[0].gameObject.SetActive(true);
        }
        currentPage = 0;
        UpdateButtonState();
    }

    private void ShowPage(int pageIndex)
    {
        if (pageIndex >= 0 && pageIndex < currentPages.Count)
        {
            currentPages[currentPage].gameObject.SetActive(false);
            currentPage = pageIndex;
            currentPages[currentPage].gameObject.SetActive(true);
            UpdateButtonState();
        }
    }


    private void UpdateButtonState()
    {
        Page1Btn.interactable = currentPage != 0;
        Page2Btn.interactable = currentPage != 1;
        Page3Btn.interactable = currentPage != 2;
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
        ConsoleNameBtn3.onClick.AddListener(ConsoleNameBtn3Click);
        ConsoleNameBtn4.onClick.AddListener(ConsoleNameBtn4Click);
        ConsoleNameBtn5.onClick.AddListener(ConsoleNameBtn5Click);
        ConsoleNameBtn6.onClick.AddListener(ConsoleNameBtn6Click);
        ConsoleNameBtn7.onClick.AddListener(ConsoleNameBtn7Click);
        
        // Ensure page buttons are active
        Page1Btn.gameObject.SetActive(true);
        Page2Btn.gameObject.SetActive(true);
        Page3Btn.gameObject.SetActive(true);

        SetUpPages(InventoryConsoleMenu);
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
        ControllerNameBtn3.onClick.AddListener(ControllerNameBtn3Click);
        ControllerNameBtn4.onClick.AddListener(ControllerNameBtn4Click);
        ControllerNameBtn5.onClick.AddListener(ControllerNameBtn5Click);
        ControllerNameBtn6.onClick.AddListener(ControllerNameBtn6Click);
        ControllerNameBtn7.onClick.AddListener(ControllerNameBtn7Click);
       
        SetUpPages(InventoryControllerMenu);
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
        CartridgeNameBtn3.onClick.AddListener(CartridgeNameBtn3Click);
        CartridgeNameBtn4.onClick.AddListener(CartridgeNameBtn4Click);
        CartridgeNameBtn5.onClick.AddListener(CartridgeNameBtn5Click);
        SetUpPages(InventoryCartridgeMenu);
    }

    public void CaseBtnClick(){
        //Enable InventoryCaseMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(false);
        InventoryCaseMenu.SetActive(true);
        InventoryGameMenu.SetActive(false);
        CaseNameBtn1.onClick.AddListener(CaseNameBtn1Click);
        CaseNameBtn2.onClick.AddListener(CaseNameBtn2Click);
        
        SetUpPages(InventoryCaseMenu);
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

    //ConsoleNameBtnClick-------------------------------------------
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
    
    public void ConsoleNameBtn3Click(){
        InfoCanvas.SetActive(true);
        GenesisScript.GenesisConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn4Click(){
        InfoCanvas.SetActive(true);
        SNESScript.SNESConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn5Click(){
        InfoCanvas.SetActive(true);
        PS1Script.PS1ConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn6Click(){
        InfoCanvas.SetActive(true);
        N64Script.N64ConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn7Click(){
        InfoCanvas.SetActive(true);
        SaturnScript.SaturnConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    

    //ControllerNameBtnClick-----------------------------------------
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
    
    public void ControllerNameBtn3Click(){
        InfoCanvas.SetActive(true);
        GenesisScript.GenesisControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn4Click(){
        InfoCanvas.SetActive(true);
        SNESScript.SNESControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn5Click(){
        InfoCanvas.SetActive(true);
        PS1Script.PS1ControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn6Click(){
        InfoCanvas.SetActive(true);
        N64Script.N64ControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn7Click(){
        InfoCanvas.SetActive(true);
        SaturnScript.SaturnControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    

    //CartridgeNameBtnClick-------------------------------------------
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
    public void CartridgeNameBtn3Click(){
        InfoCanvas.SetActive(true);
        GenesisScript.GenesisCartridgeInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CartridgeNameBtn4Click(){
        InfoCanvas.SetActive(true);
        SNESScript.SNESCartridgeInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CartridgeNameBtn5Click(){
        InfoCanvas.SetActive(true);
        N64Script.N64CartridgeInfo();
        Inventory_Sidebar.SetActive(false);
    }

    //CaseNameBtnClick------------------------------------------------
    public void CaseNameBtn1Click(){
        InfoCanvas.SetActive(true);
        PS1Script.PS1CaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn2Click(){
        InfoCanvas.SetActive(true);
        SaturnScript.SaturnCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    
    //ReturnBtnClick--------------------------------------------------
    public void ReturnButtonClick()
    {
        InfoCanvas.SetActive(false);
        Inventory_Sidebar.SetActive(true);
    }
}
