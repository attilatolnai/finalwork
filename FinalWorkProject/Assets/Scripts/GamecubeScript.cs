using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class GamecubeScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("References Item Counter")]
    //ITEM COUNTER
    private bool isGamecubeCounted = false;
    private bool isGamecubeControllerCounted = false;
    private bool isGamecubeCaseCounted = false;
    private ItemCounterGamecube ItemCounterGamecube;
[Header("References Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("References Sprites")] 
    //Gamecube SPRITES
    public Sprite GamecubeSprite;
    public Sprite GamecubeControllerSprite;
    public Sprite GamecubeCaseSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithGamecubeConsole;
    public GameObject Gamecube;
    private OVRGrabbable GamecubeGrabbable;
    private bool isGamecubeGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn9;
    public GameObject ConsoleImageSlot9;
    public GameObject ConsoleImageSlot9Gamecube;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithGamecubeController;
    public GameObject Gamecube_Controller;
    private OVRGrabbable GamecubeControllerGrabbable;
    private bool isGamecubeControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn9;
    public GameObject ControllerImageSlot9;
    public GameObject ControllerImageSlot9Gamecube;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithGamecubeCase;
    public GameObject Gamecube_Case;
    private OVRGrabbable GamecubeCaseGrabbable;
    private bool isGamecubeCaseGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CaseNameBtn4;
    public GameObject CaseImageSlot4;
    public GameObject CaseImageSlot4Gamecube;

    void Start()
    {
        //Init GamecubeCounter to false
        isGamecubeCounted = false;

        //Find ItemCounter
        ItemCounterGamecube = FindObjectOfType<ItemCounterGamecube>();
        
        // Load sprites from Resources
        GamecubeSprite = Resources.Load<Sprite>("Images/Gamecube_console");
        GamecubeControllerSprite = Resources.Load<Sprite>("Images/Gamecube_controller");
        GamecubeCaseSprite = Resources.Load<Sprite>("Images/Gamecube_case");

        // Set colors to white
        InteractWithGamecubeConsole.color = Color.white;
        InteractWithGamecubeController.color = Color.white;
        InteractWithGamecubeCase.color = Color.white;
        
        // Get 'grabbable' from the gameObjects
        GamecubeGrabbable = Gamecube.GetComponent<OVRGrabbable>();
        GamecubeControllerGrabbable = Gamecube_Controller.GetComponent<OVRGrabbable>();
        GamecubeCaseGrabbable = Gamecube_Case.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot9Gamecube.SetActive(false);
        ControllerImageSlot9Gamecube.SetActive(false);
        CaseImageSlot4Gamecube.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (GamecubeGrabbable.isGrabbed && !isGamecubeGrabbed){
            GrabGamecube();
            isGamecubeGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!GamecubeGrabbable.isGrabbed && isGamecubeGrabbed){
            isGamecubeGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (GamecubeControllerGrabbable.isGrabbed && !isGamecubeControllerGrabbed){
            GrabGamecubeController();
            isGamecubeControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!GamecubeControllerGrabbable.isGrabbed && isGamecubeControllerGrabbed){
            isGamecubeControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (GamecubeCaseGrabbable.isGrabbed && !isGamecubeCaseGrabbed){
            GrabGamecubeCase();
            isGamecubeCaseGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!GamecubeCaseGrabbable.isGrabbed && isGamecubeCaseGrabbed){
            isGamecubeCaseGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabGamecube(){
        InteractWithGamecubeConsole.color = Color.green;
        DebugText.text = "Item added to inventory: Gamecube Console";
        ConsoleImageSlot9Gamecube.SetActive(true);
        ConsoleImageSlot9.SetActive(false);
        ConsoleNameBtn9.GetComponentInChildren<TextMeshProUGUI>().text = "Gamecube";
        GamecubeConsoleInfo();
        if (!isGamecubeCounted){
            ItemCounterGamecube.IncrementCounterGamecube();
            isGamecubeCounted = true;
        }
    }
    private void GrabGamecubeController(){
        InteractWithGamecubeController.color = Color.green;
        DebugText.text = "Item added to inventory: Gamecube Controller";
        ControllerImageSlot9Gamecube.SetActive(true);
        ControllerImageSlot9.SetActive(false);
        ControllerNameBtn9.GetComponentInChildren<TextMeshProUGUI>().text = "Gamecube";
        GamecubeControllerInfo();
        if (!isGamecubeControllerCounted){
            ItemCounterGamecube.IncrementCounterGamecube();
            isGamecubeControllerCounted = true;
        }
    }
    
    private void GrabGamecubeCase(){
        InteractWithGamecubeCase.color = Color.green;
        DebugText.text = "Item added to inventory: Gamecube Case";
        CaseImageSlot4Gamecube.SetActive(true);
        CaseImageSlot4.SetActive(false);
        CaseNameBtn4.GetComponentInChildren<TextMeshProUGUI>().text = "Gamecube";
        GamecubeCaseInfo();
        if (!isGamecubeCaseCounted){
            ItemCounterGamecube.IncrementCounterGamecube();
            isGamecubeCaseCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void GamecubeConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = GamecubeSprite;
        ItemDescriptionName.text = "Gamecube";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void GamecubeControllerInfo(){
        ItemDescriptionImage.sprite = GamecubeControllerSprite;
        ItemDescriptionName.text = "Gamecube";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
    public void GamecubeCaseInfo(){
        ItemDescriptionImage.sprite = GamecubeCaseSprite;
        ItemDescriptionName.text = "Gamecube";
        ItemDescriptionText.text = "Made by: ...\n"+
        "Released: ...\n"+
        "About: ...";
    }
}
