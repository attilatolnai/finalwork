using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class DreamcastScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isDreamcastCounted = false;
    private bool isDreamcastControllerCounted = false;
    private bool isDreamcastCaseCounted = false;
    private ItemCounterDreamcast ItemCounterDreamcast;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //Dreamcast SPRITES
    public Sprite DreamcastSprite;
    public Sprite DreamcastControllerSprite;
    public Sprite DreamcastCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithDreamcastConsole;
    public GameObject Dreamcast;
    private OVRGrabbable DreamcastGrabbable;
    private bool isDreamcastGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn10;
    public GameObject ConsoleImageSlot10;
    public GameObject ConsoleImageSlot10Dreamcast;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithDreamcastController;
    public GameObject Dreamcast_Controller;
    private OVRGrabbable DreamcastControllerGrabbable;
    private bool isDreamcastControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn10;
    public GameObject ControllerImageSlot10;
    public GameObject ControllerImageSlot10Dreamcast;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithDreamcastCase;
    public GameObject Dreamcast_Case;
    private OVRGrabbable DreamcastCaseGrabbable;
    private bool isDreamcastCaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn5;
    public GameObject CaseImageSlot5;
    public GameObject CaseImageSlot5Dreamcast;

    void Start()
    {
        //Init DreamcastCounter to false
        isDreamcastCounted = false;

        //Find ItemCounter
        ItemCounterDreamcast = FindObjectOfType<ItemCounterDreamcast>();
        
        // Load sprites from Resources
        DreamcastSprite = Resources.Load<Sprite>("Images/Dreamcast_console");
        DreamcastControllerSprite = Resources.Load<Sprite>("Images/Dreamcast_controller");
        DreamcastCaseSprite = Resources.Load<Sprite>("Images/Dreamcast_case");

        // Set colors to white
        InteractWithDreamcastConsole.color = Color.white;
        InteractWithDreamcastController.color = Color.white;
        InteractWithDreamcastCase.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        DreamcastGrabbable = Dreamcast.GetComponent<OVRGrabbable>();
        DreamcastControllerGrabbable = Dreamcast_Controller.GetComponent<OVRGrabbable>();
        DreamcastCaseGrabbable = Dreamcast_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot10Dreamcast.SetActive(false);
        ControllerImageSlot10Dreamcast.SetActive(false);
        CaseImageSlot5Dreamcast.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (DreamcastGrabbable.isGrabbed && !isDreamcastGrabbed){
            GrabDreamcast();
            isDreamcastGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!DreamcastGrabbable.isGrabbed && isDreamcastGrabbed){
            isDreamcastGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (DreamcastControllerGrabbable.isGrabbed && !isDreamcastControllerGrabbed){
            GrabDreamcastController();
            isDreamcastControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!DreamcastControllerGrabbable.isGrabbed && isDreamcastControllerGrabbed){
            isDreamcastControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (DreamcastCaseGrabbable.isGrabbed && !isDreamcastCaseGrabbed){
            GrabDreamcastCase();
            isDreamcastCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!DreamcastCaseGrabbable.isGrabbed && isDreamcastCaseGrabbed){
            isDreamcastCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabDreamcast(){
        InteractWithDreamcastConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Dreamcast Console";
        ConsoleImageSlot10Dreamcast.SetActive(true);
        ConsoleImageSlot10.SetActive(false);
        ConsoleNameBtn10.GetComponentInChildren<TextMeshProUGUI>().text = "Dreamcast";
        DreamcastConsoleInfo();
        if (!isDreamcastCounted){
            ItemCounterDreamcast.IncrementCounterDreamcast();
            isDreamcastCounted = true;
        }
    }
    private void GrabDreamcastController(){
        InteractWithDreamcastController.color = Color.green;
        DebugText.text = "Item added to inventory: Dreamcast Controller";
        ControllerImageSlot10Dreamcast.SetActive(true);
        ControllerImageSlot10.SetActive(false);
        ControllerNameBtn10.GetComponentInChildren<TextMeshProUGUI>().text = "Dreamcast";
        DreamcastControllerInfo();
        if (!isDreamcastControllerCounted){
            ItemCounterDreamcast.IncrementCounterDreamcast();
            isDreamcastControllerCounted = true;
        }
    }
    
    private void GrabDreamcastCase(){
        InteractWithDreamcastCase.color = Color.green;
        DebugText.text = "Item added to inventory: Dreamcast Case";
        CaseImageSlot5Dreamcast.SetActive(true);
        CaseImageSlot5.SetActive(false);
        CaseNameBtn5.GetComponentInChildren<TextMeshProUGUI>().text = "Dreamcast";
        DreamcastCaseInfo();
        if (!isDreamcastCaseCounted){
            ItemCounterDreamcast.IncrementCounterDreamcast();
            isDreamcastCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void DreamcastConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = DreamcastSprite;
        ItemDescriptionName.text = "Dreamcast";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void DreamcastControllerInfo(){
        ItemDescriptionImage.sprite = DreamcastControllerSprite;
        ItemDescriptionName.text = "Dreamcast";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void DreamcastCaseInfo(){
        ItemDescriptionImage.sprite = DreamcastCaseSprite;
        ItemDescriptionName.text = "Dreamcast";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
