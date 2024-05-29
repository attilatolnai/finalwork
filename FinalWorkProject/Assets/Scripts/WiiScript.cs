using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class WiiScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isWiiCounted = false;
    private bool isWiiControllerCounted = false;
    private bool isWiiCaseCounted = false;
    private ItemCounterWii ItemCounterWii;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //Wii SPRITES
    public Sprite WiiSprite;
    public Sprite WiiControllerSprite;
    public Sprite WiiCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithWiiConsole;
    public GameObject Wii;
    private OVRGrabbable WiiGrabbable;
    private bool isWiiGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn14;
    public GameObject ConsoleImageSlot14;
    public GameObject ConsoleImageSlot14Wii;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithWiiController;
    public GameObject Wii_Controller;
    private OVRGrabbable WiiControllerGrabbable;
    private bool isWiiControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn14;
    public GameObject ControllerImageSlot14;
    public GameObject ControllerImageSlot14Wii;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithWiiCase;
    public GameObject Wii_Case;
    private OVRGrabbable WiiCaseGrabbable;
    private bool isWiiCaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn9;
    public GameObject CaseImageSlot9;
    public GameObject CaseImageSlot9Wii;

    void Start()
    {
        //Init WiiCounter to false
        isWiiCounted = false;

        //Find ItemCounter
        ItemCounterWii = FindObjectOfType<ItemCounterWii>();
        
        // Load sprites from Resources
        WiiSprite = Resources.Load<Sprite>("Images/Wii_console");
        WiiControllerSprite = Resources.Load<Sprite>("Images/Wii_controller");
        WiiCaseSprite = Resources.Load<Sprite>("Images/Wii_case");

        // Set colors to white
        InteractWithWiiConsole.color = Color.white;
        InteractWithWiiController.color = Color.white;
        InteractWithWiiCase.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        WiiGrabbable = Wii.GetComponent<OVRGrabbable>();
        WiiControllerGrabbable = Wii_Controller.GetComponent<OVRGrabbable>();
        WiiCaseGrabbable = Wii_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot14Wii.SetActive(false);
        ControllerImageSlot14Wii.SetActive(false);
        CaseImageSlot9Wii.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (WiiGrabbable.isGrabbed && !isWiiGrabbed){
            GrabWii();
            isWiiGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!WiiGrabbable.isGrabbed && isWiiGrabbed){
            isWiiGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (WiiControllerGrabbable.isGrabbed && !isWiiControllerGrabbed){
            GrabWiiController();
            isWiiControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!WiiControllerGrabbable.isGrabbed && isWiiControllerGrabbed){
            isWiiControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (WiiCaseGrabbable.isGrabbed && !isWiiCaseGrabbed){
            GrabWiiCase();
            isWiiCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!WiiCaseGrabbable.isGrabbed && isWiiCaseGrabbed){
            isWiiCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabWii(){
        InteractWithWiiConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Wii Console";
        ConsoleImageSlot14Wii.SetActive(true);
        ConsoleImageSlot14.SetActive(false);
        ConsoleNameBtn14.GetComponentInChildren<TextMeshProUGUI>().text = "Wii";
        WiiConsoleInfo();
        if (!isWiiCounted){
            ItemCounterWii.IncrementCounterWii();
            isWiiCounted = true;
        }
    }
    private void GrabWiiController(){
        InteractWithWiiController.color = Color.green;
        DebugText.text = "Item added to inventory: Wii Controller";
        ControllerImageSlot14Wii.SetActive(true);
        ControllerImageSlot14.SetActive(false);
        ControllerNameBtn14.GetComponentInChildren<TextMeshProUGUI>().text = "Wii";
        WiiControllerInfo();
        if (!isWiiControllerCounted){
            ItemCounterWii.IncrementCounterWii();
            isWiiControllerCounted = true;
        }
    }
    
    private void GrabWiiCase(){
        InteractWithWiiCase.color = Color.green;
        DebugText.text = "Item added to inventory: Wii Case";
        CaseImageSlot9Wii.SetActive(true);
        CaseImageSlot9.SetActive(false);
        CaseNameBtn9.GetComponentInChildren<TextMeshProUGUI>().text = "Wii";
        WiiCaseInfo();
        if (!isWiiCaseCounted){
            ItemCounterWii.IncrementCounterWii();
            isWiiCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void WiiConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = WiiSprite;
        ItemDescriptionName.text = "Wii";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void WiiControllerInfo(){
        ItemDescriptionImage.sprite = WiiControllerSprite;
        ItemDescriptionName.text = "Wii";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void WiiCaseInfo(){
        ItemDescriptionImage.sprite = WiiCaseSprite;
        ItemDescriptionName.text = "Wii";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
