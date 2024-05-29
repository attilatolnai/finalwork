using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class XboxOneScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isXboxOneCounted = false;
    private bool isXboxOneControllerCounted = false;
    private bool isXboxOneCaseCounted = false;
    private ItemCounterXboxOne ItemCounterXboxOne;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //XboxOne SPRITES
    public Sprite XboxOneSprite;
    public Sprite XboxOneControllerSprite;
    public Sprite XboxOneCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithXboxOneConsole;
    public GameObject XboxOne;
    private OVRGrabbable XboxOneGrabbable;
    private bool isXboxOneGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn16;
    public GameObject ConsoleImageSlot16;
    public GameObject ConsoleImageSlot16XboxOne;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithXboxOneController;
    public GameObject XboxOne_Controller;
    private OVRGrabbable XboxOneControllerGrabbable;
    private bool isXboxOneControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn16;
    public GameObject ControllerImageSlot16;
    public GameObject ControllerImageSlot16XboxOne;
[Header("Case")]
    //CASE
    public TMP_Text InteractWithXboxOneCase;
    public GameObject XboxOne_Case;
    private OVRGrabbable XboxOneCaseGrabbable;
    private bool isXboxOneCaseGrabbed = false;
    //CASE IMAGES AND TEXT
    public TMP_Text CaseNameBtn11;
    public GameObject CaseImageSlot11;
    public GameObject CaseImageSlot11XboxOne;

    void Start()
    {
        //Init XboxOneCounter to false
        isXboxOneCounted = false;

        //Find ItemCounter
        ItemCounterXboxOne = FindObjectOfType<ItemCounterXboxOne>();
        
        // Load sprites from Resources
        XboxOneSprite = Resources.Load<Sprite>("Images/XboxOne_console");
        XboxOneControllerSprite = Resources.Load<Sprite>("Images/XboxOne_controller");
        XboxOneCaseSprite = Resources.Load<Sprite>("Images/XboxOne_case");

        // Set colors to white
        InteractWithXboxOneConsole.color = Color.white;
        InteractWithXboxOneController.color = Color.white;
        InteractWithXboxOneCase.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        XboxOneGrabbable = XboxOne.GetComponent<OVRGrabbable>();
        XboxOneControllerGrabbable = XboxOne_Controller.GetComponent<OVRGrabbable>();
        XboxOneCaseGrabbable = XboxOne_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot16XboxOne.SetActive(false);
        ControllerImageSlot16XboxOne.SetActive(false);
        CaseImageSlot11XboxOne.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (XboxOneGrabbable.isGrabbed && !isXboxOneGrabbed){
            GrabXboxOne();
            isXboxOneGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxOneGrabbable.isGrabbed && isXboxOneGrabbed){
            isXboxOneGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (XboxOneControllerGrabbable.isGrabbed && !isXboxOneControllerGrabbed){
            GrabXboxOneController();
            isXboxOneControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxOneControllerGrabbable.isGrabbed && isXboxOneControllerGrabbed){
            isXboxOneControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CASE
        if (XboxOneCaseGrabbable.isGrabbed && !isXboxOneCaseGrabbed){
            GrabXboxOneCase();
            isXboxOneCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxOneCaseGrabbable.isGrabbed && isXboxOneCaseGrabbed){
            isXboxOneCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabXboxOne(){
        InteractWithXboxOneConsole.color = Color.green;
        DebugText.text = "Item added to inventory: XboxOne Console";
        ConsoleImageSlot16XboxOne.SetActive(true);
        ConsoleImageSlot16.SetActive(false);
        ConsoleNameBtn16.GetComponentInChildren<TextMeshProUGUI>().text = "XboxOne";
        XboxOneConsoleInfo();
        if (!isXboxOneCounted){
            ItemCounterXboxOne.IncrementCounterXboxOne();
            isXboxOneCounted = true;
        }
    }
    private void GrabXboxOneController(){
        InteractWithXboxOneController.color = Color.green;
        DebugText.text = "Item added to inventory: XboxOne Controller";
        ControllerImageSlot16XboxOne.SetActive(true);
        ControllerImageSlot16.SetActive(false);
        ControllerNameBtn16.GetComponentInChildren<TextMeshProUGUI>().text = "XboxOne";
        XboxOneControllerInfo();
        if (!isXboxOneControllerCounted){
            ItemCounterXboxOne.IncrementCounterXboxOne();
            isXboxOneControllerCounted = true;
        }
    }
    
    private void GrabXboxOneCase(){
        InteractWithXboxOneCase.color = Color.green;
        DebugText.text = "Item added to inventory: XboxOne Case";
        CaseImageSlot11XboxOne.SetActive(true);
        CaseImageSlot11.SetActive(false);
        CaseNameBtn11.GetComponentInChildren<TextMeshProUGUI>().text = "XboxOne";
        XboxOneCaseInfo();
        if (!isXboxOneCaseCounted){
            ItemCounterXboxOne.IncrementCounterXboxOne();
            isXboxOneCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void XboxOneConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = XboxOneSprite;
        ItemDescriptionName.text = "XboxOne";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void XboxOneControllerInfo(){
        ItemDescriptionImage.sprite = XboxOneControllerSprite;
        ItemDescriptionName.text = "XboxOne";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void XboxOneCaseInfo(){
        ItemDescriptionImage.sprite = XboxOneCaseSprite;
        ItemDescriptionName.text = "XboxOne";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
