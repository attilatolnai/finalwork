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
    public PS2Script PS2Script;
    public GamecubeScript GamecubeScript;
    public DreamcastScript DreamcastScript;
    public XboxScript XboxScript;
    public PS3Script PS3Script;
    public WiiScript WiiScript;
    public Xbox360Script Xbox360Script;
    public PS4Script PS4Script;
    public XboxOneScript XboxOneScript;
    public SwitchScript SwitchScript;
    public PS5Script PS5Script;
    public XboxSeriesScript XboxSeriesScript;

[Header("References Inventory Menus")]
    public GameObject InventoryMenu;
    public GameObject InventoryConsoleMenu;
    public GameObject InventoryControllerMenu;
    public GameObject InventoryCartridgeMenu;
    public GameObject InventoryCaseMenu;
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
    public Button ConsoleNameBtn8;
    public Button ConsoleNameBtn9;
    public Button ConsoleNameBtn10;
    public Button ConsoleNameBtn11;
    public Button ConsoleNameBtn12;
    public Button ConsoleNameBtn13;
    public Button ConsoleNameBtn14;
    public Button ConsoleNameBtn15;
    public Button ConsoleNameBtn16;
    public Button ConsoleNameBtn17;
    public Button ConsoleNameBtn18;
    public Button ConsoleNameBtn19;
[Header("References ControllerNameBtn's")]
    public Button ControllerNameBtn1;
    public Button ControllerNameBtn2;
    public Button ControllerNameBtn3;
    public Button ControllerNameBtn4;
    public Button ControllerNameBtn5;
    public Button ControllerNameBtn6;
    public Button ControllerNameBtn7;
    public Button ControllerNameBtn8;
    public Button ControllerNameBtn9;
    public Button ControllerNameBtn10;
    public Button ControllerNameBtn11;
    public Button ControllerNameBtn12;
    public Button ControllerNameBtn13;
    public Button ControllerNameBtn14;
    public Button ControllerNameBtn15;
    public Button ControllerNameBtn16;
    public Button ControllerNameBtn17;
    public Button ControllerNameBtn18;
    public Button ControllerNameBtn19;
[Header("References CartridgeNameBtn's")]
    public Button CartridgeNameBtn1;
    public Button CartridgeNameBtn2;
    public Button CartridgeNameBtn3;
    public Button CartridgeNameBtn4;
    public Button CartridgeNameBtn5;
[Header("References CaseNameBtn's")]
    public Button CaseNameBtn1;
    public Button CaseNameBtn2;
    public Button CaseNameBtn3;
    public Button CaseNameBtn4;
    public Button CaseNameBtn5;
    public Button CaseNameBtn6;
    public Button CaseNameBtn7;
    public Button CaseNameBtn8;
    public Button CaseNameBtn9;
    public Button CaseNameBtn10;
    public Button CaseNameBtn11;
    public Button CaseNameBtn12;
    public Button CaseNameBtn13;
    public Button CaseNameBtn14;
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

    private void SetUpPages(GameObject menu){
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

    private void ShowPage(int pageIndex){
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
        ConsoleNameBtn1.onClick.AddListener(ConsoleNameBtn1Click);
        ConsoleNameBtn2.onClick.AddListener(ConsoleNameBtn2Click);
        ConsoleNameBtn3.onClick.AddListener(ConsoleNameBtn3Click);
        ConsoleNameBtn4.onClick.AddListener(ConsoleNameBtn4Click);
        ConsoleNameBtn5.onClick.AddListener(ConsoleNameBtn5Click);
        ConsoleNameBtn6.onClick.AddListener(ConsoleNameBtn6Click);
        ConsoleNameBtn7.onClick.AddListener(ConsoleNameBtn7Click);
        ConsoleNameBtn8.onClick.AddListener(ConsoleNameBtn8Click);
        ConsoleNameBtn9.onClick.AddListener(ConsoleNameBtn9Click);
        ConsoleNameBtn10.onClick.AddListener(ConsoleNameBtn10Click);
        ConsoleNameBtn11.onClick.AddListener(ConsoleNameBtn11Click);
        ConsoleNameBtn12.onClick.AddListener(ConsoleNameBtn12Click);
        ConsoleNameBtn13.onClick.AddListener(ConsoleNameBtn13Click);
        ConsoleNameBtn14.onClick.AddListener(ConsoleNameBtn14Click);
        ConsoleNameBtn15.onClick.AddListener(ConsoleNameBtn15Click);
        ConsoleNameBtn16.onClick.AddListener(ConsoleNameBtn16Click);
        ConsoleNameBtn17.onClick.AddListener(ConsoleNameBtn17Click);
        ConsoleNameBtn18.onClick.AddListener(ConsoleNameBtn18Click);
        ConsoleNameBtn19.onClick.AddListener(ConsoleNameBtn19Click);
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
        ControllerNameBtn1.onClick.AddListener(ControllerNameBtn1Click);
        ControllerNameBtn2.onClick.AddListener(ControllerNameBtn2Click);
        ControllerNameBtn3.onClick.AddListener(ControllerNameBtn3Click);
        ControllerNameBtn4.onClick.AddListener(ControllerNameBtn4Click);
        ControllerNameBtn5.onClick.AddListener(ControllerNameBtn5Click);
        ControllerNameBtn6.onClick.AddListener(ControllerNameBtn6Click);
        ControllerNameBtn7.onClick.AddListener(ControllerNameBtn7Click);
        ControllerNameBtn8.onClick.AddListener(ControllerNameBtn8Click);
        ControllerNameBtn9.onClick.AddListener(ControllerNameBtn9Click);
        ControllerNameBtn10.onClick.AddListener(ControllerNameBtn10Click);
        ControllerNameBtn11.onClick.AddListener(ControllerNameBtn11Click);
        ControllerNameBtn12.onClick.AddListener(ControllerNameBtn12Click);
        ControllerNameBtn13.onClick.AddListener(ControllerNameBtn13Click);
        ControllerNameBtn14.onClick.AddListener(ControllerNameBtn14Click);
        ControllerNameBtn15.onClick.AddListener(ControllerNameBtn15Click);
        ControllerNameBtn16.onClick.AddListener(ControllerNameBtn16Click);
        ControllerNameBtn17.onClick.AddListener(ControllerNameBtn17Click);
        ControllerNameBtn18.onClick.AddListener(ControllerNameBtn18Click);
        ControllerNameBtn19.onClick.AddListener(ControllerNameBtn19Click);
       
        SetUpPages(InventoryControllerMenu);
    }

    public void CartridgeBtnClick(){
        //Enable InventoryCartridgeMenu and disable the rest
        InventoryMenu.SetActive(false);
        InventoryConsoleMenu.SetActive(false);
        InventoryControllerMenu.SetActive(false);
        InventoryCartridgeMenu.SetActive(true);
        InventoryCaseMenu.SetActive(false);
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
        CaseNameBtn1.onClick.AddListener(CaseNameBtn1Click);
        CaseNameBtn2.onClick.AddListener(CaseNameBtn2Click);
        CaseNameBtn3.onClick.AddListener(CaseNameBtn3Click);
        CaseNameBtn4.onClick.AddListener(CaseNameBtn4Click);
        CaseNameBtn5.onClick.AddListener(CaseNameBtn5Click);
        CaseNameBtn6.onClick.AddListener(CaseNameBtn6Click);
        CaseNameBtn7.onClick.AddListener(CaseNameBtn7Click);
        CaseNameBtn8.onClick.AddListener(CaseNameBtn8Click);
        CaseNameBtn9.onClick.AddListener(CaseNameBtn9Click);
        CaseNameBtn10.onClick.AddListener(CaseNameBtn10Click);
        CaseNameBtn11.onClick.AddListener(CaseNameBtn11Click);
        CaseNameBtn12.onClick.AddListener(CaseNameBtn12Click);
        CaseNameBtn13.onClick.AddListener(CaseNameBtn13Click);
        CaseNameBtn14.onClick.AddListener(CaseNameBtn14Click);
        
        SetUpPages(InventoryCaseMenu);
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
    public void ConsoleNameBtn8Click(){
        InfoCanvas.SetActive(true);
        PS2Script.PS2ConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn9Click(){
        InfoCanvas.SetActive(true);
        GamecubeScript.GamecubeConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn10Click(){
        InfoCanvas.SetActive(true);
        DreamcastScript.DreamcastConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn11Click(){
        InfoCanvas.SetActive(true);
        XboxScript.XboxConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn12Click(){
        InfoCanvas.SetActive(true);
        PS3Script.PS3ConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn13Click(){
        InfoCanvas.SetActive(true);
        WiiScript.WiiConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn14Click(){
        InfoCanvas.SetActive(true);
        Xbox360Script.Xbox360ConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn15Click(){
        InfoCanvas.SetActive(true);
        PS4Script.PS4ConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn16Click(){
        InfoCanvas.SetActive(true);
        XboxOneScript.XboxOneConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn17Click(){
        InfoCanvas.SetActive(true);
        SwitchScript.SwitchConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn18Click(){
        InfoCanvas.SetActive(true);
        PS5Script.PS5ConsoleInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ConsoleNameBtn19Click(){
        InfoCanvas.SetActive(true);
        XboxSeriesScript.XboxSeriesConsoleInfo();
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
    public void ControllerNameBtn8Click(){
        InfoCanvas.SetActive(true);
        PS2Script.PS2ControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn9Click(){
        InfoCanvas.SetActive(true);
        GamecubeScript.GamecubeControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn10Click(){
        InfoCanvas.SetActive(true);
        DreamcastScript.DreamcastControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn11Click(){
        InfoCanvas.SetActive(true);
        XboxScript.XboxControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn12Click(){
        InfoCanvas.SetActive(true);
        PS3Script.PS3ControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn13Click(){
        InfoCanvas.SetActive(true);
        WiiScript.WiiControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn14Click(){
        InfoCanvas.SetActive(true);
        Xbox360Script.Xbox360ControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn15Click(){
        InfoCanvas.SetActive(true);
        PS4Script.PS4ControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn16Click(){
        InfoCanvas.SetActive(true);
        XboxOneScript.XboxOneControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn17Click(){
        InfoCanvas.SetActive(true);
        SwitchScript.SwitchControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn18Click(){
        InfoCanvas.SetActive(true);
        PS5Script.PS5ControllerInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void ControllerNameBtn19Click(){
        InfoCanvas.SetActive(true);
        XboxSeriesScript.XboxSeriesControllerInfo();
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
    public void CaseNameBtn3Click(){
        InfoCanvas.SetActive(true);
        PS2Script.PS2CaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn4Click(){
        InfoCanvas.SetActive(true);
        GamecubeScript.GamecubeCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn5Click(){
        InfoCanvas.SetActive(true);
        DreamcastScript.DreamcastCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn6Click(){
        InfoCanvas.SetActive(true);
        XboxScript.XboxCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn7Click(){
        InfoCanvas.SetActive(true);
        PS3Script.PS3CaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn8Click(){
        InfoCanvas.SetActive(true);
        WiiScript.WiiCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn9Click(){
        InfoCanvas.SetActive(true);
        Xbox360Script.Xbox360CaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn10Click(){
        InfoCanvas.SetActive(true);
        PS4Script.PS4CaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn11Click(){
        InfoCanvas.SetActive(true);
        XboxOneScript.XboxOneCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn12Click(){
        InfoCanvas.SetActive(true);
        SwitchScript.SwitchCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn13Click(){
        InfoCanvas.SetActive(true);
        PS5Script.PS5CaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    public void CaseNameBtn14Click(){
        InfoCanvas.SetActive(true);
        XboxSeriesScript.XboxSeriesCaseInfo();
        Inventory_Sidebar.SetActive(false);
    }
    
    //ReturnBtnClick--------------------------------------------------
    public void ReturnButtonClick()
    {
        InfoCanvas.SetActive(false);
        Inventory_Sidebar.SetActive(true);
    }
}
