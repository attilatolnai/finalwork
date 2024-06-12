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
    private ItemCounterGen5 ItemCounterGen5;
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
        ItemCounterGen5 = FindObjectOfType<ItemCounterGen5>();
        ItemCounterSaturn = FindObjectOfType<ItemCounterSaturn>();
        
        // Load sprites from Resources
        SaturnSprite = Resources.Load<Sprite>("Images/Saturn_console");
        SaturnControllerSprite = Resources.Load<Sprite>("Images/Saturn_controller");
        SaturnCaseSprite = Resources.Load<Sprite>("Images/Saturn_case");

        // Set colors to black
        InteractWithSaturnConsole.color = Color.black;
        InteractWithSaturnController.color = Color.black;
        InteractWithSaturnCase.color = Color.black;
        
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
            ItemCounterGen5.IncrementCounterGen5();
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
            ItemCounterGen5.IncrementCounterGen5();
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
            ItemCounterGen5.IncrementCounterGen5();
            ItemCounterSaturn.IncrementCounterSaturn();
            isSaturnCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void SaturnConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = SaturnSprite;
        ItemDescriptionName.text = "Saturn";
        ItemDescriptionText.text = "Made by: Sega\n"+
        "Released: 1994\n"+
        "About: The Sega Saturn was developed and manufactured by Sega and had a strong start in Japan, but its early release in North America, which surprised retailers and consumers, led to a rocky launch.\n"+
        "The Saturn faced competition from the PlayStation and Nintendo 64, which impacted its commercial success and led to being the least successful console between the 3, having only sold approximately 9.26 million units worldwide. While the Saturn’s arcade ports and 2D games were praised, it struggled to compete in the emerging 3D gaming market. ";
    }
    public void SaturnControllerInfo(){
        ItemDescriptionImage.sprite = SaturnControllerSprite;
        ItemDescriptionName.text = "Saturn";
        ItemDescriptionText.text = "About: The Sega Saturn controller is celebrated for its comfortable, rounded design and advanced button layout. It features a cross-shaped D-pad on the left side. On the right side, it has six action buttons arranged labeled A, B, C, X, Y, and Z.\n"+
        "The controller also includes 'Start' and 'Select' buttons in the center for pausing games and navigating menus. Additionally, the two shoulder buttons, L and R, on the top edge, add further versatility and control.";
    }
    public void SaturnCaseInfo(){
        ItemDescriptionImage.sprite = SaturnCaseSprite;
        ItemDescriptionName.text = "Saturn";
        ItemDescriptionText.text = "About: The Sega Saturn case is a tall, plastic clamshell design used to protect and display Sega Saturn game discs. The front cover features detailed artwork and the game's title while the inside contains a plastic tray with a spindle to securely hold the game disc, and it also includes clips or a sleeve to hold the instruction manual or other inserts.";
    }
}
