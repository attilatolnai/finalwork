using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class PS1Script : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isPS1Counted = false;
    private bool isPS1ControllerCounted = false;
    private bool isPS1CaseCounted = false;
    private ItemCounterPS1 ItemCounterPS1;
    private ItemCounterGen5 ItemCounterGen5;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //PS1 SPRITES
    public Sprite PS1Sprite;
    public Sprite PS1ControllerSprite;
    public Sprite PS1CaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithPS1Console;
    public GameObject PS1;
    private OVRGrabbable PS1Grabbable;
    private bool isPS1Grabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn5;
    public GameObject ConsoleImageSlot5;
    public GameObject ConsoleImageSlot5PS1;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithPS1Controller;
    public GameObject PS1_Controller;
    private OVRGrabbable PS1ControllerGrabbable;
    private bool isPS1ControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn5;
    public GameObject ControllerImageSlot5;
    public GameObject ControllerImageSlot5PS1;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithPS1Case;
    public GameObject PS1_Case;
    private OVRGrabbable PS1CaseGrabbable;
    private bool isPS1CaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn2;
    public GameObject CaseImageSlot2;
    public GameObject CaseImageSlot2PS1;

    void Start()
    {
        //Init PS1Counter to false
        isPS1Counted = false;

        //Find ItemCounter
        
        ItemCounterPS1 = FindObjectOfType<ItemCounterPS1>();
        ItemCounterGen5 = FindObjectOfType<ItemCounterGen5>();
        
        // Load sprites from Resources
        PS1Sprite = Resources.Load<Sprite>("Images/PS1_console");
        PS1ControllerSprite = Resources.Load<Sprite>("Images/PS1_controller");
        PS1CaseSprite = Resources.Load<Sprite>("Images/PS1_case");

        // Set colors to white
        InteractWithPS1Console.color = Color.white;
        InteractWithPS1Controller.color = Color.white;
        InteractWithPS1Case.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        PS1Grabbable = PS1.GetComponent<OVRGrabbable>();
        PS1ControllerGrabbable = PS1_Controller.GetComponent<OVRGrabbable>();
        PS1CaseGrabbable = PS1_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot5PS1.SetActive(false);
        ControllerImageSlot5PS1.SetActive(false);
        CaseImageSlot2PS1.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (PS1Grabbable.isGrabbed && !isPS1Grabbed){
            GrabPS1();
            isPS1Grabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS1Grabbable.isGrabbed && isPS1Grabbed){
            isPS1Grabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (PS1ControllerGrabbable.isGrabbed && !isPS1ControllerGrabbed){
            GrabPS1Controller();
            isPS1ControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS1ControllerGrabbable.isGrabbed && isPS1ControllerGrabbed){
            isPS1ControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (PS1CaseGrabbable.isGrabbed && !isPS1CaseGrabbed){
            GrabPS1Case();
            isPS1CaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS1CaseGrabbable.isGrabbed && isPS1CaseGrabbed){
            isPS1CaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabPS1(){
        InteractWithPS1Console.color = Color.green;
        DebugText.text = "Item added to inventory: PS1 Console";
        ConsoleImageSlot5PS1.SetActive(true);
        ConsoleImageSlot5.SetActive(false);
        ConsoleNameBtn5.GetComponentInChildren<TextMeshProUGUI>().text = "PS1";
        PS1ConsoleInfo();
        if (!isPS1Counted){
            ItemCounterGen5.IncrementCounterGen5();
            ItemCounterPS1.IncrementCounterPS1();
            isPS1Counted = true;
        }
    }
    private void GrabPS1Controller(){
        InteractWithPS1Controller.color = Color.green;
        DebugText.text = "Item added to inventory: PS1 Controller";
        ControllerImageSlot5PS1.SetActive(true);
        ControllerImageSlot5.SetActive(false);
        ControllerNameBtn5.GetComponentInChildren<TextMeshProUGUI>().text = "PS1";
        PS1ControllerInfo();
        if (!isPS1ControllerCounted){
            ItemCounterGen5.IncrementCounterGen5();
            ItemCounterPS1.IncrementCounterPS1();
            isPS1ControllerCounted = true;
        }
    }
    
    private void GrabPS1Case(){
        InteractWithPS1Case.color = Color.green;
        DebugText.text = "Item added to inventory: PS1 Case";
        CaseImageSlot2PS1.SetActive(true);
        CaseImageSlot2.SetActive(false);
        CaseNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "PS1";
        PS1CaseInfo();
        if (!isPS1CaseCounted){
            ItemCounterGen5.IncrementCounterGen5();
            ItemCounterPS1.IncrementCounterPS1();
            isPS1CaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void PS1ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = PS1Sprite;
        ItemDescriptionName.text = "PS1";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS1ControllerInfo(){
        ItemDescriptionImage.sprite = PS1ControllerSprite;
        ItemDescriptionName.text = "PS1";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS1CaseInfo(){
        ItemDescriptionImage.sprite = PS1CaseSprite;
        ItemDescriptionName.text = "PS1";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
