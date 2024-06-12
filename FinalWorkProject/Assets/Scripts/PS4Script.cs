using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class PS4Script : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isPS4Counted = false;
    private bool isPS4ControllerCounted = false;
    private bool isPS4CaseCounted = false;
    private ItemCounterPS4 ItemCounterPS4;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //PS4 SPRITES
    public Sprite PS4Sprite;
    public Sprite PS4ControllerSprite;
    public Sprite PS4CaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithPS4Console;
    public GameObject PS4;
    private OVRGrabbable PS4Grabbable;
    private bool isPS4Grabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn15;
    public GameObject ConsoleImageSlot15;
    public GameObject ConsoleImageSlot15PS4;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithPS4Controller;
    public GameObject PS4_Controller;
    private OVRGrabbable PS4ControllerGrabbable;
    private bool isPS4ControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn15;
    public GameObject ControllerImageSlot15;
    public GameObject ControllerImageSlot15PS4;
[Header("Case")]
    //CASE
    public TMP_Text InteractWithPS4Case;
    public GameObject PS4_Case;
    private OVRGrabbable PS4CaseGrabbable;
    private bool isPS4CaseGrabbed = false;
    //CASE IMAGES AND TEXT
    public TMP_Text CaseNameBtn10;
    public GameObject CaseImageSlot10;
    public GameObject CaseImageSlot10PS4;

    void Start()
    {
        //Init PS4Counter to false
        isPS4Counted = false;

        //Find ItemCounter
        ItemCounterPS4 = FindObjectOfType<ItemCounterPS4>();
        
        // Load sprites from Resources
        PS4Sprite = Resources.Load<Sprite>("Images/PS4_console");
        PS4ControllerSprite = Resources.Load<Sprite>("Images/PS4_controller");
        PS4CaseSprite = Resources.Load<Sprite>("Images/PS4_case");

        // Set colors to black
        InteractWithPS4Console.color = Color.black;
        InteractWithPS4Controller.color = Color.black;
        InteractWithPS4Case.color = Color.black;
        
        // Get 'grabbable' from the gameObjects
        PS4Grabbable = PS4.GetComponent<OVRGrabbable>();
        PS4ControllerGrabbable = PS4_Controller.GetComponent<OVRGrabbable>();
        PS4CaseGrabbable = PS4_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot15PS4.SetActive(false);
        ControllerImageSlot15PS4.SetActive(false);
        CaseImageSlot10PS4.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (PS4Grabbable.isGrabbed && !isPS4Grabbed){
            GrabPS4();
            isPS4Grabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS4Grabbable.isGrabbed && isPS4Grabbed){
            isPS4Grabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (PS4ControllerGrabbable.isGrabbed && !isPS4ControllerGrabbed){
            GrabPS4Controller();
            isPS4ControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS4ControllerGrabbable.isGrabbed && isPS4ControllerGrabbed){
            isPS4ControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CASE
        if (PS4CaseGrabbable.isGrabbed && !isPS4CaseGrabbed){
            GrabPS4Case();
            isPS4CaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS4CaseGrabbable.isGrabbed && isPS4CaseGrabbed){
            isPS4CaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabPS4(){
        InteractWithPS4Console.color = Color.green;
        DebugText.text = "Item added to inventory: PS4 Console";
        ConsoleImageSlot15PS4.SetActive(true);
        ConsoleImageSlot15.SetActive(false);
        ConsoleNameBtn15.GetComponentInChildren<TextMeshProUGUI>().text = "PS4";
        PS4ConsoleInfo();
        if (!isPS4Counted){
            ItemCounterPS4.IncrementCounterPS4();
            isPS4Counted = true;
        }
    }
    private void GrabPS4Controller(){
        InteractWithPS4Controller.color = Color.green;
        DebugText.text = "Item added to inventory: PS4 Controller";
        ControllerImageSlot15PS4.SetActive(true);
        ControllerImageSlot15.SetActive(false);
        ControllerNameBtn15.GetComponentInChildren<TextMeshProUGUI>().text = "PS4";
        PS4ControllerInfo();
        if (!isPS4ControllerCounted){
            ItemCounterPS4.IncrementCounterPS4();
            isPS4ControllerCounted = true;
        }
    }
    
    private void GrabPS4Case(){
        InteractWithPS4Case.color = Color.green;
        DebugText.text = "Item added to inventory: PS4 Case";
        CaseImageSlot10PS4.SetActive(true);
        CaseImageSlot10.SetActive(false);
        CaseNameBtn10.GetComponentInChildren<TextMeshProUGUI>().text = "PS4";
        PS4CaseInfo();
        if (!isPS4CaseCounted){
            ItemCounterPS4.IncrementCounterPS4();
            isPS4CaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void PS4ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = PS4Sprite;
        ItemDescriptionName.text = "PS4";
        ItemDescriptionText.text = "Made by: Sony Computer Entertainment\n"+
        "Released: 2013\n"+
        "About: The PlayStation 4 was developed and manufactured by Sony Interactive Entertainment and released everywhere late 2013. The PlayStation 4 is praised for its strong game library, which include many critically acclaimed exclusive titles and a wide array of third-party games. ";
    }
    public void PS4ControllerInfo(){
        ItemDescriptionImage.sprite = PS4ControllerSprite;
        ItemDescriptionName.text = "PS4";
        ItemDescriptionText.text = "About: The PS4 game case is a sleek, modern blue plastic case, slightly slimmer than its predecessor, designed to house and showcase PlayStation 4 game discs. Inside, the case includes a sturdy plastic tray with a central spindle to securely hold the disc, along with clips or a sleeve for any included inserts or manuals.";
    }
    public void PS4CaseInfo(){
        ItemDescriptionImage.sprite = PS4CaseSprite;
        ItemDescriptionName.text = "PS4";
        ItemDescriptionText.text = "About: The DualShock 4 introduces a touchpad at the center, offering new possibilities for intuitive input and gameplay mechanics. Additionally, it includes a share button, enabling seamless social interaction and content sharing directly from the controller.";
    }
}
