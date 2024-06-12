using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class Xbox360Script : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isXbox360Counted = false;
    private bool isXbox360ControllerCounted = false;
    private bool isXbox360CaseCounted = false;
    private ItemCounterXbox360 ItemCounterXbox360;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //Xbox360 SPRITES
    public Sprite Xbox360Sprite;
    public Sprite Xbox360ControllerSprite;
    public Sprite Xbox360CaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithXbox360Console;
    public GameObject Xbox360;
    private OVRGrabbable Xbox360Grabbable;
    private bool isXbox360Grabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn13;
    public GameObject ConsoleImageSlot13;
    public GameObject ConsoleImageSlot13Xbox360;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithXbox360Controller;
    public GameObject Xbox360_Controller;
    private OVRGrabbable Xbox360ControllerGrabbable;
    private bool isXbox360ControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn13;
    public GameObject ControllerImageSlot13;
    public GameObject ControllerImageSlot13Xbox360;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithXbox360Case;
    public GameObject Xbox360_Case;
    private OVRGrabbable Xbox360CaseGrabbable;
    private bool isXbox360CaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn8;
    public GameObject CaseImageSlot8;
    public GameObject CaseImageSlot8Xbox360;

    void Start()
    {
        //Init Xbox360Counter to false
        isXbox360Counted = false;

        //Find ItemCounter
        ItemCounterXbox360 = FindObjectOfType<ItemCounterXbox360>();
        
        // Load sprites from Resources
        Xbox360Sprite = Resources.Load<Sprite>("Images/Xbox360_console");
        Xbox360ControllerSprite = Resources.Load<Sprite>("Images/Xbox360_controller");
        Xbox360CaseSprite = Resources.Load<Sprite>("Images/Xbox360_case");

        // Set colors to black
        InteractWithXbox360Console.color = Color.black;
        InteractWithXbox360Controller.color = Color.black;
        InteractWithXbox360Case.color = Color.black;
        
        // Get 'grabbable' from the gameObjects
        Xbox360Grabbable = Xbox360.GetComponent<OVRGrabbable>();
        Xbox360ControllerGrabbable = Xbox360_Controller.GetComponent<OVRGrabbable>();
        Xbox360CaseGrabbable = Xbox360_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot13Xbox360.SetActive(false);
        ControllerImageSlot13Xbox360.SetActive(false);
        CaseImageSlot8Xbox360.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (Xbox360Grabbable.isGrabbed && !isXbox360Grabbed){
            GrabXbox360();
            isXbox360Grabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!Xbox360Grabbable.isGrabbed && isXbox360Grabbed){
            isXbox360Grabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (Xbox360ControllerGrabbable.isGrabbed && !isXbox360ControllerGrabbed){
            GrabXbox360Controller();
            isXbox360ControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!Xbox360ControllerGrabbable.isGrabbed && isXbox360ControllerGrabbed){
            isXbox360ControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (Xbox360CaseGrabbable.isGrabbed && !isXbox360CaseGrabbed){
            GrabXbox360Case();
            isXbox360CaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!Xbox360CaseGrabbable.isGrabbed && isXbox360CaseGrabbed){
            isXbox360CaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabXbox360(){
        InteractWithXbox360Console.color = Color.green;
        DebugText.text = "Item added to inventory: Xbox360 Console";
        ConsoleImageSlot13Xbox360.SetActive(true);
        ConsoleImageSlot13.SetActive(false);
        ConsoleNameBtn13.GetComponentInChildren<TextMeshProUGUI>().text = "Xbox360";
        Xbox360ConsoleInfo();
        if (!isXbox360Counted){
            ItemCounterXbox360.IncrementCounterXbox360();
            isXbox360Counted = true;
        }
    }
    private void GrabXbox360Controller(){
        InteractWithXbox360Controller.color = Color.green;
        DebugText.text = "Item added to inventory: Xbox360 Controller";
        ControllerImageSlot13Xbox360.SetActive(true);
        ControllerImageSlot13.SetActive(false);
        ControllerNameBtn13.GetComponentInChildren<TextMeshProUGUI>().text = "Xbox360";
        Xbox360ControllerInfo();
        if (!isXbox360ControllerCounted){
            ItemCounterXbox360.IncrementCounterXbox360();
            isXbox360ControllerCounted = true;
        }
    }
    
    private void GrabXbox360Case(){
        InteractWithXbox360Case.color = Color.green;
        DebugText.text = "Item added to inventory: Xbox360 Case";
        CaseImageSlot8Xbox360.SetActive(true);
        CaseImageSlot8.SetActive(false);
        CaseNameBtn8.GetComponentInChildren<TextMeshProUGUI>().text = "Xbox360";
        Xbox360CaseInfo();
        if (!isXbox360CaseCounted){
            ItemCounterXbox360.IncrementCounterXbox360();
            isXbox360CaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void Xbox360ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = Xbox360Sprite;
        ItemDescriptionName.text = "Xbox360";
        ItemDescriptionText.text = "Made by: Microsoft\n"+
        "Released: 2005\n"+
        "About: The Xbox 360 was developed and manufactured by Microsoft and released late 2005 globally. The console featured a sleek, customizable design with interchangeable faceplates and a concave shape. The Xbox 360 was a significant commercial success, even with its initial hardware issues, notably the 'Red Ring of Death'. The Xbox 360 introduced the Kinect motion-sensing accessory, an answer to Nintendo’s Wii, which allowed for controller-free gaming and the use of voice commands.";
    }
    public void Xbox360ControllerInfo(){
        ItemDescriptionImage.sprite = Xbox360ControllerSprite;
        ItemDescriptionName.text = "Xbox360";
        ItemDescriptionText.text = "About: The Xbox 360 controller is lauded for its balanced design and ergonomic comfort. It is powered by 2 AA batteries on the back of the controller. There is also a wireless version of the controller, for a seamless and clutter-free gaming experience.";
    }
    public void Xbox360CaseInfo(){
        ItemDescriptionImage.sprite = Xbox360CaseSprite;
        ItemDescriptionName.text = "Xbox360";
        ItemDescriptionText.text = "About: The Xbox 360 game case is a standard-sized plastic DVD case designed to protect and display Xbox 360 game discs. This design, usually in a distinctive green color, became synonymous with the Xbox 360 brand during its lifespan from the mid-2000s to the mid-2010s";
    }
}
