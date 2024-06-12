using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class SwitchScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isSwitchCounted = false;
    private bool isSwitchControllerCounted = false;
    private bool isSwitchCaseCounted = false;
    private ItemCounterSwitch ItemCounterSwitch;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //Switch SPRITES
    public Sprite SwitchSprite;
    public Sprite SwitchControllerSprite;
    public Sprite SwitchCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithSwitchConsole;
    public GameObject Switch;
    private OVRGrabbable SwitchGrabbable;
    private bool isSwitchGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn17;
    public GameObject ConsoleImageSlot17;
    public GameObject ConsoleImageSlot17Switch;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithSwitchController;
    public GameObject Switch_Controller;
    private OVRGrabbable SwitchControllerGrabbable;
    private bool isSwitchControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn17;
    public GameObject ControllerImageSlot17;
    public GameObject ControllerImageSlot17Switch;
[Header("Case")]
    //CASE
    public TMP_Text InteractWithSwitchCase;
    public GameObject Switch_Case;
    private OVRGrabbable SwitchCaseGrabbable;
    private bool isSwitchCaseGrabbed = false;
    //CASE IMAGES AND TEXT
    public TMP_Text CaseNameBtn12;
    public GameObject CaseImageSlot12;
    public GameObject CaseImageSlot12Switch;

    void Start()
    {
        //Init SwitchCounter to false
        isSwitchCounted = false;

        //Find ItemCounter
        ItemCounterSwitch = FindObjectOfType<ItemCounterSwitch>();
        
        // Load sprites from Resources
        SwitchSprite = Resources.Load<Sprite>("Images/Switch_console");
        SwitchControllerSprite = Resources.Load<Sprite>("Images/Switch_controller");
        SwitchCaseSprite = Resources.Load<Sprite>("Images/Switch_Case");

        // Set colors to black
        InteractWithSwitchConsole.color = Color.black;
        InteractWithSwitchController.color = Color.black;
        InteractWithSwitchCase.color = Color.black;
        
        // Get 'grabbable' from the gameObjects
        SwitchGrabbable = Switch.GetComponent<OVRGrabbable>();
        SwitchControllerGrabbable = Switch_Controller.GetComponent<OVRGrabbable>();
        SwitchCaseGrabbable = Switch_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot17Switch.SetActive(false);
        ControllerImageSlot17Switch.SetActive(false);
        CaseImageSlot12Switch.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (SwitchGrabbable.isGrabbed && !isSwitchGrabbed){
            GrabSwitch();
            isSwitchGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SwitchGrabbable.isGrabbed && isSwitchGrabbed){
            isSwitchGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (SwitchControllerGrabbable.isGrabbed && !isSwitchControllerGrabbed){
            GrabSwitchController();
            isSwitchControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SwitchControllerGrabbable.isGrabbed && isSwitchControllerGrabbed){
            isSwitchControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //Case
        if (SwitchCaseGrabbable.isGrabbed && !isSwitchCaseGrabbed){
            GrabSwitchCase();
            isSwitchCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SwitchCaseGrabbable.isGrabbed && isSwitchCaseGrabbed){
            isSwitchCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabSwitch(){
        InteractWithSwitchConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Switch Console";
        ConsoleImageSlot17Switch.SetActive(true);
        ConsoleImageSlot17.SetActive(false);
        ConsoleNameBtn17.GetComponentInChildren<TextMeshProUGUI>().text = "Switch";
        SwitchConsoleInfo();
        if (!isSwitchCounted){
            ItemCounterSwitch.IncrementCounterSwitch();
            isSwitchCounted = true;
        }
    }
    private void GrabSwitchController(){
        InteractWithSwitchController.color = Color.green;
        DebugText.text = "Item added to inventory: Switch Controller";
        ControllerImageSlot17Switch.SetActive(true);
        ControllerImageSlot17.SetActive(false);
        ControllerNameBtn17.GetComponentInChildren<TextMeshProUGUI>().text = "Switch";
        SwitchControllerInfo();
        if (!isSwitchControllerCounted){
            ItemCounterSwitch.IncrementCounterSwitch();
            isSwitchControllerCounted = true;
        }
    }
    
    private void GrabSwitchCase(){
        InteractWithSwitchCase.color = Color.green;
        DebugText.text = "Item added to inventory: Switch Case";
        CaseImageSlot12Switch.SetActive(true);
        CaseImageSlot12.SetActive(false);
        CaseNameBtn12.GetComponentInChildren<TextMeshProUGUI>().text = "Switch";
        SwitchCaseInfo();
        if (!isSwitchCaseCounted){
            ItemCounterSwitch.IncrementCounterSwitch();
            isSwitchCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void SwitchConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = SwitchSprite;
        ItemDescriptionName.text = "Switch";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "Released: 2017\n"+
        "About: The Nintendo Switch was developed and manufactured by Nintendo and released globally in 2017. It appealed to a broad audience, including both traditional gamers and casual players, and benefited heavily from strong sales during the COVID-19 pandemic. The Switch is still in production and as of current estimations it has sold over 141.32 million units worldwide, with a chance of overtaking Sony’s PlayStation 2 as the most sold console of all time.";
    }
    public void SwitchControllerInfo(){
        ItemDescriptionImage.sprite = SwitchControllerSprite;
        ItemDescriptionName.text = "Switch";
        ItemDescriptionText.text = "About: ...";
    }
    public void SwitchCaseInfo(){
        ItemDescriptionImage.sprite = SwitchCaseSprite;
        ItemDescriptionName.text = "Switch";
        ItemDescriptionText.text = "About: The Switch case often comes in a vibrant red color, echoing the signature hue of the Switch's Joy-Con controllers and adding a touch of Nintendo's playful aesthetic. Inside, the case features molded compartments to securely hold multiple game cartridges, ensuring they remain organized and protected during travel.";
    }
}
