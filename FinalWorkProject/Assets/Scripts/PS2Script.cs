using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class PS2Script : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isPS2Counted = false;
    private bool isPS2ControllerCounted = false;
    private bool isPS2CaseCounted = false;
    private ItemCounterGen6 ItemCounterGen6;
    private ItemCounterPS2 ItemCounterPS2;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //PS2 SPRITES
    public Sprite PS2Sprite;
    public Sprite PS2ControllerSprite;
    public Sprite PS2CaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithPS2Console;
    public GameObject PS2;
    private OVRGrabbable PS2Grabbable;
    private bool isPS2Grabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn8;
    public GameObject ConsoleImageSlot8;
    public GameObject ConsoleImageSlot8PS2;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithPS2Controller;
    public GameObject PS2_Controller;
    private OVRGrabbable PS2ControllerGrabbable;
    private bool isPS2ControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn8;
    public GameObject ControllerImageSlot8;
    public GameObject ControllerImageSlot8PS2;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithPS2Case;
    public GameObject PS2_Case;
    private OVRGrabbable PS2CaseGrabbable;
    private bool isPS2CaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn3;
    public GameObject CaseImageSlot3;
    public GameObject CaseImageSlot3PS2;

    void Start()
    {
        //Init PS2Counter to false
        isPS2Counted = false;

        //Find ItemCounter
        ItemCounterGen6 = FindObjectOfType<ItemCounterGen6>();
        ItemCounterPS2 = FindObjectOfType<ItemCounterPS2>();
        
        // Load sprites from Resources
        PS2Sprite = Resources.Load<Sprite>("Images/PS2_console");
        PS2ControllerSprite = Resources.Load<Sprite>("Images/PS2_controller");
        PS2CaseSprite = Resources.Load<Sprite>("Images/PS2_case");

        // Set colors to black
        InteractWithPS2Console.color = Color.black;
        InteractWithPS2Controller.color = Color.black;
        InteractWithPS2Case.color = Color.black;
        
        // Get 'grabbable' from the gameObjects
        PS2Grabbable = PS2.GetComponent<OVRGrabbable>();
        PS2ControllerGrabbable = PS2_Controller.GetComponent<OVRGrabbable>();
        PS2CaseGrabbable = PS2_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot8PS2.SetActive(false);
        ControllerImageSlot8PS2.SetActive(false);
        CaseImageSlot3PS2.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (PS2Grabbable.isGrabbed && !isPS2Grabbed){
            GrabPS2();
            isPS2Grabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS2Grabbable.isGrabbed && isPS2Grabbed){
            isPS2Grabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (PS2ControllerGrabbable.isGrabbed && !isPS2ControllerGrabbed){
            GrabPS2Controller();
            isPS2ControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS2ControllerGrabbable.isGrabbed && isPS2ControllerGrabbed){
            isPS2ControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (PS2CaseGrabbable.isGrabbed && !isPS2CaseGrabbed){
            GrabPS2Case();
            isPS2CaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS2CaseGrabbable.isGrabbed && isPS2CaseGrabbed){
            isPS2CaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabPS2(){
        InteractWithPS2Console.color = Color.green;
        DebugText.text = "Item added to inventory: PS2 Console";
        ConsoleImageSlot8PS2.SetActive(true);
        ConsoleImageSlot8.SetActive(false);
        ConsoleNameBtn8.GetComponentInChildren<TextMeshProUGUI>().text = "PS2";
        PS2ConsoleInfo();
        if (!isPS2Counted){
            ItemCounterGen6.IncrementCounterGen6();
            ItemCounterPS2.IncrementCounterPS2();
            isPS2Counted = true;
        }
    }
    private void GrabPS2Controller(){
        InteractWithPS2Controller.color = Color.green;
        DebugText.text = "Item added to inventory: PS2 Controller";
        ControllerImageSlot8PS2.SetActive(true);
        ControllerImageSlot8.SetActive(false);
        ControllerNameBtn8.GetComponentInChildren<TextMeshProUGUI>().text = "PS2";
        PS2ControllerInfo();
        if (!isPS2ControllerCounted){
            ItemCounterGen6.IncrementCounterGen6();
            ItemCounterPS2.IncrementCounterPS2();
            isPS2ControllerCounted = true;
        }
    }
    
    private void GrabPS2Case(){
        InteractWithPS2Case.color = Color.green;
        DebugText.text = "Item added to inventory: PS2 Case";
        CaseImageSlot3PS2.SetActive(true);
        CaseImageSlot3.SetActive(false);
        CaseNameBtn3.GetComponentInChildren<TextMeshProUGUI>().text = "PS2";
        PS2CaseInfo();
        if (!isPS2CaseCounted){
            ItemCounterGen6.IncrementCounterGen6();
            ItemCounterPS2.IncrementCounterPS2();
            isPS2CaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void PS2ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = PS2Sprite;
        ItemDescriptionName.text = "PS2";
        ItemDescriptionText.text = "Made by: Sony Computer Entertainment \n"+
        "Released: 2000 \n"+
        "About: Successor to the PlayStation, The PS2 had a slick black design and supported CD-ROM, DVD-ROM, and PlayStation game discs, which allowed users to play PlayStation games.\n"+
        "A major selling point for the PlayStation 2 was the support of DVD playback, meaning that the PS2 could be used as a DVD player to watch movies.";
    }
    public void PS2ControllerInfo(){
        ItemDescriptionImage.sprite = PS2ControllerSprite;
        ItemDescriptionName.text = "PS2";
        ItemDescriptionText.text = "About: The PS2 controller, called DualShock2 was an improvement on the design of the original DualShock with and released with 2 analog sticks";
    }
    public void PS2CaseInfo(){
        ItemDescriptionImage.sprite = PS2CaseSprite;
        ItemDescriptionName.text = "PS2";
        ItemDescriptionText.text = "About: A PlayStation 2 game case is a plastic clamshell box, typically black or dark blue.\n"+
        "The PS2 had a library of 3,429 games, and the last game released for the console was 'Pro Evolution Soccer 2014', which released a week before the launch of the PlayStation 4!";
    }
}
