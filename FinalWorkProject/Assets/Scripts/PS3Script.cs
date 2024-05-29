using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class PS3Script : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isPS3Counted = false;
    private bool isPS3ControllerCounted = false;
    private bool isPS3CaseCounted = false;
    private ItemCounterPS3 ItemCounterPS3;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //PS3 SPRITES
    public Sprite PS3Sprite;
    public Sprite PS3ControllerSprite;
    public Sprite PS3CaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithPS3Console;
    public GameObject PS3;
    private OVRGrabbable PS3Grabbable;
    private bool isPS3Grabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn12;
    public GameObject ConsoleImageSlot12;
    public GameObject ConsoleImageSlot12PS3;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithPS3Controller;
    public GameObject PS3_Controller;
    private OVRGrabbable PS3ControllerGrabbable;
    private bool isPS3ControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn12;
    public GameObject ControllerImageSlot12;
    public GameObject ControllerImageSlot12PS3;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithPS3Case;
    public GameObject PS3_Case;
    private OVRGrabbable PS3CaseGrabbable;
    private bool isPS3CaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn7;
    public GameObject CaseImageSlot7;
    public GameObject CaseImageSlot7PS3;

    void Start()
    {
        //Init PS3Counter to false
        isPS3Counted = false;

        //Find ItemCounter
        ItemCounterPS3 = FindObjectOfType<ItemCounterPS3>();
        
        // Load sprites from Resources
        PS3Sprite = Resources.Load<Sprite>("Images/PS3_console");
        PS3ControllerSprite = Resources.Load<Sprite>("Images/PS3_controller");
        PS3CaseSprite = Resources.Load<Sprite>("Images/PS3_case");

        // Set colors to white
        InteractWithPS3Console.color = Color.white;
        InteractWithPS3Controller.color = Color.white;
        InteractWithPS3Case.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        PS3Grabbable = PS3.GetComponent<OVRGrabbable>();
        PS3ControllerGrabbable = PS3_Controller.GetComponent<OVRGrabbable>();
        PS3CaseGrabbable = PS3_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot12PS3.SetActive(false);
        ControllerImageSlot12PS3.SetActive(false);
        CaseImageSlot7PS3.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (PS3Grabbable.isGrabbed && !isPS3Grabbed){
            GrabPS3();
            isPS3Grabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS3Grabbable.isGrabbed && isPS3Grabbed){
            isPS3Grabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (PS3ControllerGrabbable.isGrabbed && !isPS3ControllerGrabbed){
            GrabPS3Controller();
            isPS3ControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS3ControllerGrabbable.isGrabbed && isPS3ControllerGrabbed){
            isPS3ControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (PS3CaseGrabbable.isGrabbed && !isPS3CaseGrabbed){
            GrabPS3Case();
            isPS3CaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS3CaseGrabbable.isGrabbed && isPS3CaseGrabbed){
            isPS3CaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabPS3(){
        InteractWithPS3Console.color = Color.green;
        DebugText.text = "Item added to inventory: PS3 Console";
        ConsoleImageSlot12PS3.SetActive(true);
        ConsoleImageSlot12.SetActive(false);
        ConsoleNameBtn12.GetComponentInChildren<TextMeshProUGUI>().text = "PS3";
        PS3ConsoleInfo();
        if (!isPS3Counted){
            ItemCounterPS3.IncrementCounterPS3();
            isPS3Counted = true;
        }
    }
    private void GrabPS3Controller(){
        InteractWithPS3Controller.color = Color.green;
        DebugText.text = "Item added to inventory: PS3 Controller";
        ControllerImageSlot12PS3.SetActive(true);
        ControllerImageSlot12.SetActive(false);
        ControllerNameBtn12.GetComponentInChildren<TextMeshProUGUI>().text = "PS3";
        PS3ControllerInfo();
        if (!isPS3ControllerCounted){
            ItemCounterPS3.IncrementCounterPS3();
            isPS3ControllerCounted = true;
        }
    }
    
    private void GrabPS3Case(){
        InteractWithPS3Case.color = Color.green;
        DebugText.text = "Item added to inventory: PS3 Case";
        CaseImageSlot7PS3.SetActive(true);
        CaseImageSlot7.SetActive(false);
        CaseNameBtn7.GetComponentInChildren<TextMeshProUGUI>().text = "PS3";
        PS3CaseInfo();
        if (!isPS3CaseCounted){
            ItemCounterPS3.IncrementCounterPS3();
            isPS3CaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void PS3ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = PS3Sprite;
        ItemDescriptionName.text = "PS3";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS3ControllerInfo(){
        ItemDescriptionImage.sprite = PS3ControllerSprite;
        ItemDescriptionName.text = "PS3";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS3CaseInfo(){
        ItemDescriptionImage.sprite = PS3CaseSprite;
        ItemDescriptionName.text = "PS3";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
