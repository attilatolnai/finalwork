using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class N64Script : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("Refrences Item Counter")]
    //ITEM COUNTER
    private bool isN64Counted = false;
    private bool isN64ControllerCounted = false;
    private bool isN64CartridgeCounted = false;
    private ItemCounterN64 ItemCounterN64;
[Header("Refrences Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("Refrences Sprites")] 
    //N64 SPRITES
    public Sprite N64Sprite;
    public Sprite N64ControllerSprite;
    public Sprite N64CartridgeSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithN64Console;
    public GameObject N64;
    private OVRGrabbable N64Grabbable;
    private bool isN64Grabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn6;
    public GameObject ConsoleImageSlot6;
    public GameObject ConsoleImageSlot6N64;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithN64Controller;
    public GameObject N64_Controller;
    private OVRGrabbable N64ControllerGrabbable;
    private bool isN64ControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn6;
    public GameObject ControllerImageSlot6;
    public GameObject ControllerImageSlot6N64;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithN64Cartridge;
    public GameObject N64_Cartridge;
    private OVRGrabbable N64CartridgeGrabbable;
    private bool isN64CartridgeGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CartridgeNameBtn5;
    public GameObject CartridgeImageSlot5;
    public GameObject CartridgeImageSlot5N64;

    void Start()
    {
        //Init N64Counter to false
        isN64Counted = false;

        //Find ItemCounter
        ItemCounterN64 = FindObjectOfType<ItemCounterN64>();
        
        // Load sprites from Resources
        N64Sprite = Resources.Load<Sprite>("Images/N64_console");
        N64ControllerSprite = Resources.Load<Sprite>("Images/N64_controller");
        N64CartridgeSprite = Resources.Load<Sprite>("Images/N64_Cartridge");

        // Set colors to white
        InteractWithN64Console.color = Color.white;
        InteractWithN64Controller.color = Color.white;
        InteractWithN64Cartridge.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        N64Grabbable = N64.GetComponent<OVRGrabbable>();
        N64ControllerGrabbable = N64_Controller.GetComponent<OVRGrabbable>();
        N64CartridgeGrabbable = N64_Cartridge.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot6N64.SetActive(false);
        ControllerImageSlot6N64.SetActive(false);
        CartridgeImageSlot5N64.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (N64Grabbable.isGrabbed && !isN64Grabbed){
            GrabN64();
            isN64Grabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!N64Grabbable.isGrabbed && isN64Grabbed){
            isN64Grabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (N64ControllerGrabbable.isGrabbed && !isN64ControllerGrabbed){
            GrabN64Controller();
            isN64ControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!N64ControllerGrabbable.isGrabbed && isN64ControllerGrabbed){
            isN64ControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (N64CartridgeGrabbable.isGrabbed && !isN64CartridgeGrabbed){
            GrabN64Cartridge();
            isN64CartridgeGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!N64CartridgeGrabbable.isGrabbed && isN64CartridgeGrabbed){
            isN64CartridgeGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabN64(){
        InteractWithN64Console.color = Color.green;
        DebugText.text = "Item added to inventory: N64 Console";
        ConsoleImageSlot6N64.SetActive(true);
        ConsoleImageSlot6.SetActive(false);
        ConsoleNameBtn6.GetComponentInChildren<TextMeshProUGUI>().text = "N64";
        N64ConsoleInfo();
        if (!isN64Counted){
            ItemCounterN64.IncrementCounterN64();
            isN64Counted = true;
        }
    }
    private void GrabN64Controller(){
        InteractWithN64Controller.color = Color.green;
        DebugText.text = "Item added to inventory: N64 Controller";
        ControllerImageSlot6N64.SetActive(true);
        ControllerImageSlot6.SetActive(false);
        ControllerNameBtn6.GetComponentInChildren<TextMeshProUGUI>().text = "N64";
        N64ControllerInfo();
        if (!isN64ControllerCounted){
            ItemCounterN64.IncrementCounterN64();
            isN64ControllerCounted = true;
        }
    }
    
    private void GrabN64Cartridge(){
        InteractWithN64Cartridge.color = Color.green;
        DebugText.text = "Item added to inventory: N64 Cartridge";
        CartridgeImageSlot5N64.SetActive(true);
        CartridgeImageSlot5.SetActive(false);
        CartridgeNameBtn5.GetComponentInChildren<TextMeshProUGUI>().text = "N64";
        N64CartridgeInfo();
        if (!isN64CartridgeCounted){
            ItemCounterN64.IncrementCounterN64();
            isN64CartridgeCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void N64ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = N64Sprite;
        ItemDescriptionName.text = "N64";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void N64ControllerInfo(){
        ItemDescriptionImage.sprite = N64ControllerSprite;
        ItemDescriptionName.text = "N64";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void N64CartridgeInfo(){
        ItemDescriptionImage.sprite = N64CartridgeSprite;
        ItemDescriptionName.text = "N64";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
