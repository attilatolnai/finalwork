using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class XboxSeriesScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isXboxSeriesCounted = false;
    private bool isXboxSeriesControllerCounted = false;
    private bool isXboxSeriesCaseCounted = false;
    private ItemCounterXboxSeries ItemCounterXboxSeries;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //XboxSeries SPRITES
    public Sprite XboxSeriesSprite;
    public Sprite XboxSeriesControllerSprite;
    public Sprite XboxSeriesCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithXboxSeriesConsole;
    public GameObject XboxSeries;
    private OVRGrabbable XboxSeriesGrabbable;
    private bool isXboxSeriesGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn19;
    public GameObject ConsoleImageSlot19;
    public GameObject ConsoleImageSlot19XboxSeries;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithXboxSeriesController;
    public GameObject XboxSeries_Controller;
    private OVRGrabbable XboxSeriesControllerGrabbable;
    private bool isXboxSeriesControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn19;
    public GameObject ControllerImageSlot19;
    public GameObject ControllerImageSlot19XboxSeries;
[Header("Case")]
    //CASE
    public TMP_Text InteractWithXboxSeriesCase;
    public GameObject XboxSeries_Case;
    private OVRGrabbable XboxSeriesCaseGrabbable;
    private bool isXboxSeriesCaseGrabbed = false;
    //CASE IMAGES AND TEXT
    public TMP_Text CaseNameBtn14;
    public GameObject CaseImageSlot14;
    public GameObject CaseImageSlot14XboxSeries;

    void Start()
    {
        //Init XboxSeriesCounter to false
        isXboxSeriesCounted = false;

        //Find ItemCounter
        ItemCounterXboxSeries = FindObjectOfType<ItemCounterXboxSeries>();
        
        // Load sprites from Resources
        XboxSeriesSprite = Resources.Load<Sprite>("Images/XboxSeries_console");
        XboxSeriesControllerSprite = Resources.Load<Sprite>("Images/XboxSeries_controller");
        XboxSeriesCaseSprite = Resources.Load<Sprite>("Images/XboxSeries_case");

        // Set colors to white
        InteractWithXboxSeriesConsole.color = Color.white;
        InteractWithXboxSeriesController.color = Color.white;
        InteractWithXboxSeriesCase.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        XboxSeriesGrabbable = XboxSeries.GetComponent<OVRGrabbable>();
        XboxSeriesControllerGrabbable = XboxSeries_Controller.GetComponent<OVRGrabbable>();
        XboxSeriesCaseGrabbable = XboxSeries_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot19XboxSeries.SetActive(false);
        ControllerImageSlot19XboxSeries.SetActive(false);
        CaseImageSlot14XboxSeries.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (XboxSeriesGrabbable.isGrabbed && !isXboxSeriesGrabbed){
            GrabXboxSeries();
            isXboxSeriesGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxSeriesGrabbable.isGrabbed && isXboxSeriesGrabbed){
            isXboxSeriesGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (XboxSeriesControllerGrabbable.isGrabbed && !isXboxSeriesControllerGrabbed){
            GrabXboxSeriesController();
            isXboxSeriesControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxSeriesControllerGrabbable.isGrabbed && isXboxSeriesControllerGrabbed){
            isXboxSeriesControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CASE
        if (XboxSeriesCaseGrabbable.isGrabbed && !isXboxSeriesCaseGrabbed){
            GrabXboxSeriesCase();
            isXboxSeriesCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!XboxSeriesCaseGrabbable.isGrabbed && isXboxSeriesCaseGrabbed){
            isXboxSeriesCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabXboxSeries(){
        InteractWithXboxSeriesConsole.color = Color.green;
        DebugText.text = "Item added to inventory: XboxSeries Console";
        ConsoleImageSlot19XboxSeries.SetActive(true);
        ConsoleImageSlot19.SetActive(false);
        ConsoleNameBtn19.GetComponentInChildren<TextMeshProUGUI>().text = "XboxSeries";
        XboxSeriesConsoleInfo();
        if (!isXboxSeriesCounted){
            ItemCounterXboxSeries.IncrementCounterXboxSeries();
            isXboxSeriesCounted = true;
        }
    }
    private void GrabXboxSeriesController(){
        InteractWithXboxSeriesController.color = Color.green;
        DebugText.text = "Item added to inventory: XboxSeries Controller";
        ControllerImageSlot19XboxSeries.SetActive(true);
        ControllerImageSlot19.SetActive(false);
        ControllerNameBtn19.GetComponentInChildren<TextMeshProUGUI>().text = "XboxSeries";
        XboxSeriesControllerInfo();
        if (!isXboxSeriesControllerCounted){
            ItemCounterXboxSeries.IncrementCounterXboxSeries();
            isXboxSeriesControllerCounted = true;
        }
    }
    
    private void GrabXboxSeriesCase(){
        InteractWithXboxSeriesCase.color = Color.green;
        DebugText.text = "Item added to inventory: XboxSeries Case";
        CaseImageSlot14XboxSeries.SetActive(true);
        CaseImageSlot14.SetActive(false);
        CaseNameBtn14.GetComponentInChildren<TextMeshProUGUI>().text = "XboxSeries";
        XboxSeriesCaseInfo();
        if (!isXboxSeriesCaseCounted){
            ItemCounterXboxSeries.IncrementCounterXboxSeries();
            isXboxSeriesCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void XboxSeriesConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = XboxSeriesSprite;
        ItemDescriptionName.text = "XboxSeries";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void XboxSeriesControllerInfo(){
        ItemDescriptionImage.sprite = XboxSeriesControllerSprite;
        ItemDescriptionName.text = "XboxSeries";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void XboxSeriesCaseInfo(){
        ItemDescriptionImage.sprite = XboxSeriesCaseSprite;
        ItemDescriptionName.text = "XboxSeries";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
