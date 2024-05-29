using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class XboxScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isXboxCounted = false;
    private bool isXboxControllerCounted = false;
    private bool isXboxCaseCounted = false;
    private ItemCounterXbox ItemCounterXbox;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //Xbox SPRITES
    public Sprite XboxSprite;
    public Sprite XboxControllerSprite;
    public Sprite XboxCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithXboxConsole;
    public GameObject Xbox;
    private OVRGrabbable XboxGrabbable;
    private bool isXboxGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn11;
    public GameObject ConsoleImageSlot11;
    public GameObject ConsoleImageSlot11Xbox;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithXboxController;
    public GameObject Xbox_Controller;
    private OVRGrabbable XboxControllerGrabbable;
    private bool isXboxControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn11;
    public GameObject ControllerImageSlot11;
    public GameObject ControllerImageSlot11Xbox;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithXboxCase;
    public GameObject Xbox_Case;
    private OVRGrabbable XboxCaseGrabbable;
    private bool isXboxCaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn6;
    public GameObject CaseImageSlot6;
    public GameObject CaseImageSlot6Xbox;

    void Start()
    {
        //Init XboxCounter to false
        isXboxCounted = false;

        //Find ItemCounter
        ItemCounterXbox = FindObjectOfType<ItemCounterXbox>();
        
        // Load sprites from Resources
        XboxSprite = Resources.Load<Sprite>("Images/Xbox_console");
        XboxControllerSprite = Resources.Load<Sprite>("Images/Xbox_controller");
        XboxCaseSprite = Resources.Load<Sprite>("Images/Xbox_case");

        // Set colors to white
        InteractWithXboxConsole.color = Color.white;
        InteractWithXboxController.color = Color.white;
        InteractWithXboxCase.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        XboxGrabbable = Xbox.GetComponent<OVRGrabbable>();
        XboxControllerGrabbable = Xbox_Controller.GetComponent<OVRGrabbable>();
        XboxCaseGrabbable = Xbox_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot11Xbox.SetActive(false);
        ControllerImageSlot11Xbox.SetActive(false);
        CaseImageSlot6Xbox.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (XboxGrabbable.isGrabbed && !isXboxGrabbed){
            GrabXbox();
            isXboxGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxGrabbable.isGrabbed && isXboxGrabbed){
            isXboxGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (XboxControllerGrabbable.isGrabbed && !isXboxControllerGrabbed){
            GrabXboxController();
            isXboxControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxControllerGrabbable.isGrabbed && isXboxControllerGrabbed){
            isXboxControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (XboxCaseGrabbable.isGrabbed && !isXboxCaseGrabbed){
            GrabXboxCase();
            isXboxCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxCaseGrabbable.isGrabbed && isXboxCaseGrabbed){
            isXboxCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabXbox(){
        InteractWithXboxConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Xbox Console";
        ConsoleImageSlot11Xbox.SetActive(true);
        ConsoleImageSlot11.SetActive(false);
        ConsoleNameBtn11.GetComponentInChildren<TextMeshProUGUI>().text = "Xbox";
        XboxConsoleInfo();
        if (!isXboxCounted){
            ItemCounterXbox.IncrementCounterXbox();
            isXboxCounted = true;
        }
    }
    private void GrabXboxController(){
        InteractWithXboxController.color = Color.green;
        DebugText.text = "Item added to inventory: Xbox Controller";
        ControllerImageSlot11Xbox.SetActive(true);
        ControllerImageSlot11.SetActive(false);
        ControllerNameBtn11.GetComponentInChildren<TextMeshProUGUI>().text = "Xbox";
        XboxControllerInfo();
        if (!isXboxControllerCounted){
            ItemCounterXbox.IncrementCounterXbox();
            isXboxControllerCounted = true;
        }
    }
    
    private void GrabXboxCase(){
        InteractWithXboxCase.color = Color.green;
        DebugText.text = "Item added to inventory: Xbox Case";
        CaseImageSlot6Xbox.SetActive(true);
        CaseImageSlot6.SetActive(false);
        CaseNameBtn6.GetComponentInChildren<TextMeshProUGUI>().text = "Xbox";
        XboxCaseInfo();
        if (!isXboxCaseCounted){
            ItemCounterXbox.IncrementCounterXbox();
            isXboxCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void XboxConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = XboxSprite;
        ItemDescriptionName.text = "Xbox";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void XboxControllerInfo(){
        ItemDescriptionImage.sprite = XboxControllerSprite;
        ItemDescriptionName.text = "Xbox";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void XboxCaseInfo(){
        ItemDescriptionImage.sprite = XboxCaseSprite;
        ItemDescriptionName.text = "Xbox";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}