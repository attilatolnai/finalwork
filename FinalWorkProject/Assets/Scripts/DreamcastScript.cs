using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class DreamcastScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isDreamcastCounted = false;
    private bool isDreamcastControllerCounted = false;
    private bool isDreamcastCaseCounted = false;
    private ItemCounterGen6 ItemCounterGen6;
    private ItemCounterDreamcast ItemCounterDreamcast;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //Dreamcast SPRITES
    public Sprite DreamcastSprite;
    public Sprite DreamcastControllerSprite;
    public Sprite DreamcastCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithDreamcastConsole;
    public GameObject Dreamcast;
    private OVRGrabbable DreamcastGrabbable;
    private bool isDreamcastGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn10;
    public GameObject ConsoleImageSlot10;
    public GameObject ConsoleImageSlot10Dreamcast;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithDreamcastController;
    public GameObject Dreamcast_Controller;
    private OVRGrabbable DreamcastControllerGrabbable;
    private bool isDreamcastControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn10;
    public GameObject ControllerImageSlot10;
    public GameObject ControllerImageSlot10Dreamcast;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithDreamcastCase;
    public GameObject Dreamcast_Case;
    private OVRGrabbable DreamcastCaseGrabbable;
    private bool isDreamcastCaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn5;
    public GameObject CaseImageSlot5;
    public GameObject CaseImageSlot5Dreamcast;

    void Start()
    {
        //Init DreamcastCounter to false
        isDreamcastCounted = false;

        //Find ItemCounter
        ItemCounterGen6 = FindObjectOfType<ItemCounterGen6>();
        ItemCounterDreamcast = FindObjectOfType<ItemCounterDreamcast>();
        
        // Load sprites from Resources
        DreamcastSprite = Resources.Load<Sprite>("Images/Dreamcast_console");
        DreamcastControllerSprite = Resources.Load<Sprite>("Images/Dreamcast_controller");
        DreamcastCaseSprite = Resources.Load<Sprite>("Images/Dreamcast_case");

        // Set colors to black
        InteractWithDreamcastConsole.color = Color.black;
        InteractWithDreamcastController.color = Color.black;
        InteractWithDreamcastCase.color = Color.black;
        
        // Get 'grabbable' from the gameObjects
        DreamcastGrabbable = Dreamcast.GetComponent<OVRGrabbable>();
        DreamcastControllerGrabbable = Dreamcast_Controller.GetComponent<OVRGrabbable>();
        DreamcastCaseGrabbable = Dreamcast_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot10Dreamcast.SetActive(false);
        ControllerImageSlot10Dreamcast.SetActive(false);
        CaseImageSlot5Dreamcast.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (DreamcastGrabbable.isGrabbed && !isDreamcastGrabbed){
            GrabDreamcast();
            isDreamcastGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!DreamcastGrabbable.isGrabbed && isDreamcastGrabbed){
            isDreamcastGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (DreamcastControllerGrabbable.isGrabbed && !isDreamcastControllerGrabbed){
            GrabDreamcastController();
            isDreamcastControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!DreamcastControllerGrabbable.isGrabbed && isDreamcastControllerGrabbed){
            isDreamcastControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (DreamcastCaseGrabbable.isGrabbed && !isDreamcastCaseGrabbed){
            GrabDreamcastCase();
            isDreamcastCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!DreamcastCaseGrabbable.isGrabbed && isDreamcastCaseGrabbed){
            isDreamcastCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabDreamcast(){
        InteractWithDreamcastConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Dreamcast Console";
        ConsoleImageSlot10Dreamcast.SetActive(true);
        ConsoleImageSlot10.SetActive(false);
        ConsoleNameBtn10.GetComponentInChildren<TextMeshProUGUI>().text = "Dreamcast";
        DreamcastConsoleInfo();
        if (!isDreamcastCounted){
            ItemCounterGen6.IncrementCounterGen6();
            ItemCounterDreamcast.IncrementCounterDreamcast();
            isDreamcastCounted = true;
        }
    }
    private void GrabDreamcastController(){
        InteractWithDreamcastController.color = Color.green;
        DebugText.text = "Item added to inventory: Dreamcast Controller";
        ControllerImageSlot10Dreamcast.SetActive(true);
        ControllerImageSlot10.SetActive(false);
        ControllerNameBtn10.GetComponentInChildren<TextMeshProUGUI>().text = "Dreamcast";
        DreamcastControllerInfo();
        if (!isDreamcastControllerCounted){
            ItemCounterGen6.IncrementCounterGen6();
            ItemCounterDreamcast.IncrementCounterDreamcast();
            isDreamcastControllerCounted = true;
        }
    }
    
    private void GrabDreamcastCase(){
        InteractWithDreamcastCase.color = Color.green;
        DebugText.text = "Item added to inventory: Dreamcast Case";
        CaseImageSlot5Dreamcast.SetActive(true);
        CaseImageSlot5.SetActive(false);
        CaseNameBtn5.GetComponentInChildren<TextMeshProUGUI>().text = "Dreamcast";
        DreamcastCaseInfo();
        if (!isDreamcastCaseCounted){
            ItemCounterGen6.IncrementCounterGen6();
            ItemCounterDreamcast.IncrementCounterDreamcast();
            isDreamcastCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void DreamcastConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = DreamcastSprite;
        ItemDescriptionName.text = "Dreamcast";
        ItemDescriptionText.text = "Made by: Sega\n"+
        "Released: 1998 (Japan), 1999 (North America & Europe)\n"+
        "About: The Sega Dreamcast was a groundbreaking console that marked Sega's final foray into the hardware market\n"+ 
        "Known for its innovative features, such as online gaming capabilities and a built-in modem, the Dreamcast introduced\n"+
        "several iconic games. Despite its short lifespan, the Dreamcast left a lasting legacy and is remembered fondly for its\n"+
        "ahead-of-its-time technology and unique game library";
    }
    public void DreamcastControllerInfo(){
        ItemDescriptionImage.sprite = DreamcastControllerSprite;
        ItemDescriptionName.text = "Dreamcast";
        ItemDescriptionText.text = "Made by: Sega\n"+
        "About: The Dreamcast controller, designed for the Sega Dreamcast console, featured an innovative layout with a built-in\n"+
        "memory card slot for the VMU (Visual Memory Unit), providing additional screen functionality and game-saving capabilities.\n"+
        "Despite mixed reviews on its ergonomics, the Dreamcast controller is celebrated for its forward-thinking design and\n"+
        "integration with the console's advanced features.";
    }
    public void DreamcastCaseInfo(){
        ItemDescriptionImage.sprite = DreamcastCaseSprite;
        ItemDescriptionName.text = "Dreamcast";
        ItemDescriptionText.text = "About: The Dreamcast game case was a compact and sturdy plastic case designed to protect and store Dreamcast game discs.\n"+
        "Featuring a distinctive blue spine and clear front cover, displaying the cover art, game information, and instructions.\n"+
        "The design of the case reflected the sleek and modern aesthetic of the Dreamcast brand, making it an integral part of the overall presentation and appeal of the games\n"+
        "There were a total of 624 released games on the Dreamcast";
    }
}
