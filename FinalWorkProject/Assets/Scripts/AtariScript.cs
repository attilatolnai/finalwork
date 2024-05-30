using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class AtariScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;

[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isAtariCounted = false;
    private bool isAtariControllerCounted = false;
    private bool isAtariCartridgeCounted = false;
    private ItemCounter itemCounter;
    private ItemCounterAtari itemCounterAtari;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")]
    //ATARI SPRITES
    public Sprite AtariSprite;
    public Sprite AtariControllerSprite;
    public Sprite AtariCartridgeSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithAtariConsole;
    public GameObject Atari;
    private OVRGrabbable AtariGrabbable;
    private bool isAtariGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn1;
    public GameObject ConsoleImageSlot1;
    public GameObject ConsoleImageSlot1Atari;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithAtariController;
    public GameObject Atari_Controller;
    private OVRGrabbable AtariControllerGrabbable;
    private bool isAtariControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn1;
    public GameObject ControllerImageSlot1;
    public GameObject ControllerImageSlot1Atari;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithAtariCartridge;
    public GameObject Atari_Cartridge;
    private OVRGrabbable AtariCartridgeGrabbable;
    private bool isAtariCartridgeGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CartridgeNameBtn1;
    public GameObject CartridgeImageSlot1;
    public GameObject CartridgeImageSlot1Atari;

    void Start()
    {
        //Init AtariCounter to false
        isAtariCounted = false;

        //Find ItemCounter
        itemCounter = FindObjectOfType<ItemCounter>();
        itemCounterAtari = FindObjectOfType<ItemCounterAtari>();
        
        // Load sprites from Resources
        AtariSprite = Resources.Load<Sprite>("Images/Atari_console");
        AtariControllerSprite = Resources.Load<Sprite>("Images/Atari_controller");
        AtariCartridgeSprite = Resources.Load<Sprite>("Images/Atari_cartridge");

        // Set colors to white
        InteractWithAtariConsole.color = Color.white;
        InteractWithAtariController.color = Color.white;
        InteractWithAtariCartridge.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        AtariGrabbable = Atari.GetComponent<OVRGrabbable>();
        AtariControllerGrabbable = Atari_Controller.GetComponent<OVRGrabbable>();
        AtariCartridgeGrabbable = Atari_Cartridge.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot1Atari.SetActive(false);
        ControllerImageSlot1Atari.SetActive(false);
        CartridgeImageSlot1Atari.SetActive(false);
    }

    void Update(){
        //CONSOLE
        if (AtariGrabbable.isGrabbed && !isAtariGrabbed){
            GrabAtari();
            isAtariGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!AtariGrabbable.isGrabbed && isAtariGrabbed){
            isAtariGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (AtariControllerGrabbable.isGrabbed && !isAtariControllerGrabbed){
            GrabAtariController();
            isAtariControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!AtariControllerGrabbable.isGrabbed && isAtariControllerGrabbed){
            isAtariControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (AtariCartridgeGrabbable.isGrabbed && !isAtariCartridgeGrabbed){
            GrabAtariCartridge();
            isAtariCartridgeGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!AtariCartridgeGrabbable.isGrabbed && isAtariCartridgeGrabbed){
            isAtariCartridgeGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabAtari(){
        InteractWithAtariConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Atari Console";
        ConsoleImageSlot1Atari.SetActive(true);
        ConsoleImageSlot1.SetActive(false);
        ConsoleNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
        AtariConsoleInfo();
        if (!isAtariCounted){
            itemCounter.IncrementCounter();
            itemCounterAtari.IncrementCounterAtari();
            isAtariCounted = true;
        }
    }
    
    private void GrabAtariController(){
        InteractWithAtariController.color = Color.green;
        DebugText.text = "Item added to inventory: Atari Controller";
        ControllerImageSlot1Atari.SetActive(true);
        ControllerImageSlot1.SetActive(false);
        ControllerNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
        AtariControllerInfo();
        if (!isAtariControllerCounted){
            itemCounter.IncrementCounter();
            itemCounterAtari.IncrementCounterAtari();
            isAtariControllerCounted = true;
        }
    }
    
    private void GrabAtariCartridge(){
        InteractWithAtariCartridge.color = Color.green;
        DebugText.text = "Item added to inventory: Atari Cartridge";
        CartridgeImageSlot1Atari.SetActive(true);
        CartridgeImageSlot1.SetActive(false);
        CartridgeNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
        AtariCartridgeInfo();
        if (!isAtariCartridgeCounted){
            itemCounter.IncrementCounter();
            itemCounterAtari.IncrementCounterAtari();
            isAtariCartridgeCounted = true;
        }
    }
    

    // INFO FUNCTIONS
    public void AtariConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = AtariSprite;
        ItemDescriptionName.text = "Atari";
        ItemDescriptionText.text = "Made by: Atari, Inc.\n"+
        "Released: September 1977\n"+
        "About: The Atari 2600 was one of the first home video game consoles to use microprocessor-based hardware and ROM cartridges, allowing users to play a variety of games.\n"+
        "It played a pivotal role in the growth of the video game industry, popularizing home gaming and introducing iconic games like 'Space Invaders' and 'Pitfall!'.\n"+
        "The Atari 2600 remains a beloved and influential piece of gaming history.";
    }

    public void AtariControllerInfo(){
        ItemDescriptionImage.sprite = AtariControllerSprite;
        ItemDescriptionName.text = "Atari";
        ItemDescriptionText.text = "Made by: Atari, Inc.\n"+
        "About: A single-button digital joystick with 8-directional movement and a simple, but ergonomic design\n"+
        "The Atari 2600 controller is often referred simply as the 'joystick', featuring a single red button and a joystick for directional input.\n"+
        "It offered intuitive gameplay controls for the console's library of games and set a standard for future game controllers.";
    }

    public void AtariCartridgeInfo(){
        ItemDescriptionImage.sprite = AtariCartridgeSprite;
        ItemDescriptionName.text = "Atari";
        ItemDescriptionText.text = "Made by: Atari, Inc. and various other game developers.\n"+
        "The Atari 2600 cartridge, also known simply as a 'game cartridge' or 'cartridge', was the physical medium used to distribute games for the Atari 2600 console\n"+
        "These cartridges contained read-only memory (ROM) chips that stored game code and data, with varied storage capacities typically ranging from 2KB to 32KB\n"+
        "With their colorful labels and distinctive shapes, Atari 2600 cartridges became iconic symbols of the early video game era.";
    }
}