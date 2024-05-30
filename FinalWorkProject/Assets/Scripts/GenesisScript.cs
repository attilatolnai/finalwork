using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class GenesisScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("Refrences Item Counter")]
    //ITEM COUNTER
    private bool isGenesisCounted = false;
    private bool isGenesisControllerCounted = false;
    private bool isGenesisCartridgeCounted = false;
    private ItemCounterGen4 itemCounterGen4;
    private ItemCounterGenesis ItemCounterGenesis;
[Header("Refrences Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("Refrences Sprites")] 
    //GENESIS SPRITES
    public Sprite GenesisSprite;
    public Sprite GenesisControllerSprite;
    public Sprite GenesisCartridgeSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithGenesisConsole;
    public GameObject Genesis;
    private OVRGrabbable GenesisGrabbable;
    private bool isGenesisGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn3;
    public GameObject ConsoleImageSlot3;
    public GameObject ConsoleImageSlot3Genesis;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithGenesisController;
    public GameObject Genesis_Controller;
    private OVRGrabbable GenesisControllerGrabbable;
    private bool isGenesisControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn3;
    public GameObject ControllerImageSlot3;
    public GameObject ControllerImageSlot3Genesis;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithGenesisCartridge;
    public GameObject Genesis_Cartridge;
    private OVRGrabbable GenesisCartridgeGrabbable;
    private bool isGenesisCartridgeGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CartridgeNameBtn3;
    public GameObject CartridgeImageSlot3;
    public GameObject CartridgeImageSlot3Genesis;

    void Start()
    {
        //Init GenesisCounter to false
        isGenesisCounted = false;

        //Find ItemCounter
        itemCounterGen4 = FindObjectOfType<ItemCounterGen4>();
        ItemCounterGenesis = FindObjectOfType<ItemCounterGenesis>();
        
        // Load sprites from Resources
        GenesisSprite = Resources.Load<Sprite>("Images/Genesis_console");
        GenesisControllerSprite = Resources.Load<Sprite>("Images/Genesis_controller");
        GenesisCartridgeSprite = Resources.Load<Sprite>("Images/Genesis_cartridge");

        // Set colors to white
        InteractWithGenesisConsole.color = Color.white;
        InteractWithGenesisController.color = Color.white;
        InteractWithGenesisCartridge.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        GenesisGrabbable = Genesis.GetComponent<OVRGrabbable>();
        GenesisControllerGrabbable = Genesis_Controller.GetComponent<OVRGrabbable>();
        GenesisCartridgeGrabbable = Genesis_Cartridge.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot3Genesis.SetActive(false);
        ControllerImageSlot3Genesis.SetActive(false);
        CartridgeImageSlot3Genesis.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (GenesisGrabbable.isGrabbed && !isGenesisGrabbed){
            GrabGenesis();
            isGenesisGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!GenesisGrabbable.isGrabbed && isGenesisGrabbed){
            isGenesisGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (GenesisControllerGrabbable.isGrabbed && !isGenesisControllerGrabbed){
            GrabGenesisController();
            isGenesisControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!GenesisControllerGrabbable.isGrabbed && isGenesisControllerGrabbed){
            isGenesisControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (GenesisCartridgeGrabbable.isGrabbed && !isGenesisCartridgeGrabbed){
            GrabGenesisCartridge();
            isGenesisCartridgeGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!GenesisCartridgeGrabbable.isGrabbed && isGenesisCartridgeGrabbed){
            isGenesisCartridgeGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabGenesis(){
        InteractWithGenesisConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Genesis Console";
        ConsoleImageSlot3Genesis.SetActive(true);
        ConsoleImageSlot3.SetActive(false);
        ConsoleNameBtn3.GetComponentInChildren<TextMeshProUGUI>().text = "Genesis";
        GenesisConsoleInfo();
        if (!isGenesisCounted){
            itemCounterGen4.IncrementCounterGen4();
            ItemCounterGenesis.IncrementCounterGenesis();
            isGenesisCounted = true;
        }
    }
    private void GrabGenesisController(){
        InteractWithGenesisController.color = Color.green;
        DebugText.text = "Item added to inventory: Genesis Controller";
        ControllerImageSlot3Genesis.SetActive(true);
        ControllerImageSlot3.SetActive(false);
        ControllerNameBtn3.GetComponentInChildren<TextMeshProUGUI>().text = "Genesis";
        GenesisControllerInfo();
        if (!isGenesisControllerCounted){
            itemCounterGen4.IncrementCounterGen4();
            ItemCounterGenesis.IncrementCounterGenesis();
            isGenesisControllerCounted = true;
        }
    }
    
    private void GrabGenesisCartridge(){
        InteractWithGenesisCartridge.color = Color.green;
        DebugText.text = "Item added to inventory: Genesis Cartridge";
        CartridgeImageSlot3Genesis.SetActive(true);
        CartridgeImageSlot3.SetActive(false);
        CartridgeNameBtn3.GetComponentInChildren<TextMeshProUGUI>().text = "Genesis";
        GenesisCartridgeInfo();
        if (!isGenesisCartridgeCounted){
            itemCounterGen4.IncrementCounterGen4();
            ItemCounterGenesis.IncrementCounterGenesis();
            isGenesisCartridgeCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void GenesisConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = GenesisSprite;
        ItemDescriptionName.text = "Genesis";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void GenesisControllerInfo(){
        ItemDescriptionImage.sprite = GenesisControllerSprite;
        ItemDescriptionName.text = "Genesis";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void GenesisCartridgeInfo(){
        ItemDescriptionImage.sprite = GenesisCartridgeSprite;
        ItemDescriptionName.text = "Genesis";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}