using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class SaturnScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("Refrences Item Counter")]
    //ITEM COUNTER
    private bool isSaturnCounted = false;
    private bool isSaturnControllerCounted = false;
    private bool isSaturnCaseCounted = false;
    private ItemCounterSaturn ItemCounterSaturn;
[Header("Refrences Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("Refrences Sprites")] 
    //Saturn SPRITES
    public Sprite SaturnSprite;
    public Sprite SaturnControllerSprite;
    public Sprite SaturnCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithSaturnConsole;
    public GameObject Saturn;
    private OVRGrabbable SaturnGrabbable;
    private bool isSaturnGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn7;
    public GameObject ConsoleImageSlot7;
    public GameObject ConsoleImageSlot7Saturn;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithSaturnController;
    public GameObject Saturn_Controller;
    private OVRGrabbable SaturnControllerGrabbable;
    private bool isSaturnControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn7;
    public GameObject ControllerImageSlot7;
    public GameObject ControllerImageSlot7Saturn;
[Header("Case")]
    //CARTRIDGE
    public TMP_Text InteractWithSaturnCase;
    public GameObject Saturn_Case;
    private OVRGrabbable SaturnCaseGrabbable;
    private bool isSaturnCaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn1;
    public GameObject CaseImageSlot1;
    public GameObject CaseImageSlot1Saturn;

    void Start()
    {
        //Init SaturnCounter to false
        isSaturnCounted = false;

        //Find ItemCounter
        ItemCounterSaturn = FindObjectOfType<ItemCounterSaturn>();
        
        // Load sprites from Resources
        SaturnSprite = Resources.Load<Sprite>("Images/Saturn_console");
        SaturnControllerSprite = Resources.Load<Sprite>("Images/Saturn_controller");
        SaturnCaseSprite = Resources.Load<Sprite>("Images/Saturn_case");

        // Set colors to white
        InteractWithSaturnConsole.color = Color.white;
        InteractWithSaturnController.color = Color.white;
        InteractWithSaturnCase.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        SaturnGrabbable = Saturn.GetComponent<OVRGrabbable>();
        SaturnControllerGrabbable = Saturn_Controller.GetComponent<OVRGrabbable>();
        SaturnCaseGrabbable = Saturn_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot7Saturn.SetActive(false);
        ControllerImageSlot7Saturn.SetActive(false);
        CaseImageSlot1Saturn.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (SaturnGrabbable.isGrabbed && !isSaturnGrabbed){
            GrabSaturn();
            isSaturnGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SaturnGrabbable.isGrabbed && isSaturnGrabbed){
            isSaturnGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (SaturnControllerGrabbable.isGrabbed && !isSaturnControllerGrabbed){
            GrabSaturnController();
            isSaturnControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SaturnControllerGrabbable.isGrabbed && isSaturnControllerGrabbed){
            isSaturnControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (SaturnCaseGrabbable.isGrabbed && !isSaturnCaseGrabbed){
            GrabSaturnCase();
            isSaturnCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SaturnCaseGrabbable.isGrabbed && isSaturnCaseGrabbed){
            isSaturnCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabSaturn(){
        InteractWithSaturnConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Saturn Console";
        ConsoleImageSlot7Saturn.SetActive(true);
        ConsoleImageSlot7.SetActive(false);
        ConsoleNameBtn7.GetComponentInChildren<TextMeshProUGUI>().text = "Saturn";
        SaturnConsoleInfo();
        if (!isSaturnCounted){
            ItemCounterSaturn.IncrementCounterSaturn();
            isSaturnCounted = true;
        }
    }
    private void GrabSaturnController(){
        InteractWithSaturnController.color = Color.green;
        DebugText.text = "Item added to inventory: Saturn Controller";
        ControllerImageSlot7Saturn.SetActive(true);
        ControllerImageSlot7.SetActive(false);
        ControllerNameBtn7.GetComponentInChildren<TextMeshProUGUI>().text = "Saturn";
        SaturnControllerInfo();
        if (!isSaturnControllerCounted){
            ItemCounterSaturn.IncrementCounterSaturn();
            isSaturnControllerCounted = true;
        }
    }
    
    private void GrabSaturnCase(){
        InteractWithSaturnCase.color = Color.green;
        DebugText.text = "Item added to inventory: Saturn Case";
        CaseImageSlot1Saturn.SetActive(true);
        CaseImageSlot1.SetActive(false);
        CaseNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Saturn";
        SaturnCaseInfo();
        if (!isSaturnCaseCounted){
            ItemCounterSaturn.IncrementCounterSaturn();
            isSaturnCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void SaturnConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = SaturnSprite;
        ItemDescriptionName.text = "Saturn";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void SaturnControllerInfo(){
        ItemDescriptionImage.sprite = SaturnControllerSprite;
        ItemDescriptionName.text = "Saturn";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void SaturnCaseInfo(){
        ItemDescriptionImage.sprite = SaturnCaseSprite;
        ItemDescriptionName.text = "Saturn";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
