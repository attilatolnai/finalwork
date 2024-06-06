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
    private ItemCounterGen6 ItemCounterGen6;
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
        ItemCounterGen6 = FindObjectOfType<ItemCounterGen6>();
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
            ItemCounterGen6.IncrementCounterGen6();
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
            ItemCounterGen6.IncrementCounterGen6();
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
            ItemCounterGen6.IncrementCounterGen6();
            ItemCounterXbox.IncrementCounterXbox();
            isXboxCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void XboxConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = XboxSprite;
        ItemDescriptionName.text = "Xbox";
        ItemDescriptionText.text = "Made by: Microsoft\n"+
        "Released: 2001 & 2002\n"+
        "About: The Xbox was Microsoft's entry into the console market\n"+
        "The Xbox was the first console with a built-in hard drive, which was used for saving games and storing downloadable content.\n"+
        "It supported online gaming through its Xbox Live service, which was a major innovation at the time and set the standard for future online gaming services.";
    }
    public void XboxControllerInfo(){
        ItemDescriptionImage.sprite = XboxControllerSprite;
        ItemDescriptionName.text = "Xbox";
        ItemDescriptionText.text = "About: The controller for the Xbox was nicknamed the 'Duke' because of its large size.\n"+
        "It has two analog sticks, a directional pad, six action buttons, and two analog triggers. It was later replaced by the smaller 'Controller S' due to player feedback";
    }
    public void XboxCaseInfo(){
        ItemDescriptionImage.sprite = XboxCaseSprite;
        ItemDescriptionName.text = "Xbox";
        ItemDescriptionText.text = "About: Xbox game cases use the standard DVD size, approximately 7.5 x 5.5 inches, and were typically green colored, making them easily distinguishable from other gaming platforms.";
    }
}