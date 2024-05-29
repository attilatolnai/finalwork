using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class PS5Script : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isPS5Counted = false;
    private bool isPS5ControllerCounted = false;
    private bool isPS5CaseCounted = false;
    private ItemCounterPS5 ItemCounterPS5;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //PS5 SPRITES
    public Sprite PS5Sprite;
    public Sprite PS5ControllerSprite;
    public Sprite PS5CaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithPS5Console;
    public GameObject PS5;
    private OVRGrabbable PS5Grabbable;
    private bool isPS5Grabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn18;
    public GameObject ConsoleImageSlot18;
    public GameObject ConsoleImageSlot18PS5;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithPS5Controller;
    public GameObject PS5_Controller;
    private OVRGrabbable PS5ControllerGrabbable;
    private bool isPS5ControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn18;
    public GameObject ControllerImageSlot18;
    public GameObject ControllerImageSlot18PS5;
[Header("Case")]
    //CASE
    public TMP_Text InteractWithPS5Case;
    public GameObject PS5_Case;
    private OVRGrabbable PS5CaseGrabbable;
    private bool isPS5CaseGrabbed = false;
    //CASE IMAGES AND TEXT
    public TMP_Text CaseNameBtn13;
    public GameObject CaseImageSlot13;
    public GameObject CaseImageSlot13PS5;

    void Start()
    {
        //Init PS5Counter to false
        isPS5Counted = false;

        //Find ItemCounter
        ItemCounterPS5 = FindObjectOfType<ItemCounterPS5>();
        
        // Load sprites from Resources
        PS5Sprite = Resources.Load<Sprite>("Images/PS5_console");
        PS5ControllerSprite = Resources.Load<Sprite>("Images/PS5_controller");
        PS5CaseSprite = Resources.Load<Sprite>("Images/PS5_case");

        // Set colors to white
        InteractWithPS5Console.color = Color.white;
        InteractWithPS5Controller.color = Color.white;
        InteractWithPS5Case.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        PS5Grabbable = PS5.GetComponent<OVRGrabbable>();
        PS5ControllerGrabbable = PS5_Controller.GetComponent<OVRGrabbable>();
        PS5CaseGrabbable = PS5_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot18PS5.SetActive(false);
        ControllerImageSlot18PS5.SetActive(false);
        CaseImageSlot13PS5.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (PS5Grabbable.isGrabbed && !isPS5Grabbed){
            GrabPS5();
            isPS5Grabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS5Grabbable.isGrabbed && isPS5Grabbed){
            isPS5Grabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (PS5ControllerGrabbable.isGrabbed && !isPS5ControllerGrabbed){
            GrabPS5Controller();
            isPS5ControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS5ControllerGrabbable.isGrabbed && isPS5ControllerGrabbed){
            isPS5ControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CASE
        if (PS5CaseGrabbable.isGrabbed && !isPS5CaseGrabbed){
            GrabPS5Case();
            isPS5CaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!PS5CaseGrabbable.isGrabbed && isPS5CaseGrabbed){
            isPS5CaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabPS5(){
        InteractWithPS5Console.color = Color.green;
        DebugText.text = "Item added to inventory: PS5 Console";
        ConsoleImageSlot18PS5.SetActive(true);
        ConsoleImageSlot18.SetActive(false);
        ConsoleNameBtn18.GetComponentInChildren<TextMeshProUGUI>().text = "PS5";
        PS5ConsoleInfo();
        if (!isPS5Counted){
            ItemCounterPS5.IncrementCounterPS5();
            isPS5Counted = true;
        }
    }
    private void GrabPS5Controller(){
        InteractWithPS5Controller.color = Color.green;
        DebugText.text = "Item added to inventory: PS5 Controller";
        ControllerImageSlot18PS5.SetActive(true);
        ControllerImageSlot18.SetActive(false);
        ControllerNameBtn18.GetComponentInChildren<TextMeshProUGUI>().text = "PS5";
        PS5ControllerInfo();
        if (!isPS5ControllerCounted){
            ItemCounterPS5.IncrementCounterPS5();
            isPS5ControllerCounted = true;
        }
    }
    
    private void GrabPS5Case(){
        InteractWithPS5Case.color = Color.green;
        DebugText.text = "Item added to inventory: PS5 Case";
        CaseImageSlot13PS5.SetActive(true);
        CaseImageSlot13.SetActive(false);
        CaseNameBtn13.GetComponentInChildren<TextMeshProUGUI>().text = "PS5";
        PS5CaseInfo();
        if (!isPS5CaseCounted){
            ItemCounterPS5.IncrementCounterPS5();
            isPS5CaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void PS5ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = PS5Sprite;
        ItemDescriptionName.text = "PS5";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS5ControllerInfo(){
        ItemDescriptionImage.sprite = PS5ControllerSprite;
        ItemDescriptionName.text = "PS5";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS5CaseInfo(){
        ItemDescriptionImage.sprite = PS5CaseSprite;
        ItemDescriptionName.text = "PS5";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
