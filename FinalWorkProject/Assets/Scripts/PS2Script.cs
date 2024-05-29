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
        ItemCounterPS2 = FindObjectOfType<ItemCounterPS2>();
        
        // Load sprites from Resources
        PS2Sprite = Resources.Load<Sprite>("Images/PS2_console");
        PS2ControllerSprite = Resources.Load<Sprite>("Images/PS2_controller");
        PS2CaseSprite = Resources.Load<Sprite>("Images/PS2_case");

        // Set colors to white
        InteractWithPS2Console.color = Color.white;
        InteractWithPS2Controller.color = Color.white;
        InteractWithPS2Case.color = Color.white;
        
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
            ItemCounterPS2.IncrementCounterPS2();
            isPS2CaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void PS2ConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = PS2Sprite;
        ItemDescriptionName.text = "PS2";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS2ControllerInfo(){
        ItemDescriptionImage.sprite = PS2ControllerSprite;
        ItemDescriptionName.text = "PS2";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void PS2CaseInfo(){
        ItemDescriptionImage.sprite = PS2CaseSprite;
        ItemDescriptionName.text = "PS2";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
