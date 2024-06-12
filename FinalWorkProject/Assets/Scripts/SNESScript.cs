using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class SNESScript : MonoBehaviour
{
    //DebugText
    public TMP_Text DebugText;
[Header("Refrences Item Counter")]
    //ITEM COUNTER
    private bool isSNESCounted = false;
    private bool isSNESControllerCounted = false;
    private bool isSNESCartridgeCounted = false;
    private ItemCounterGen4 itemCounterGen4;
    private ItemCounterSNES ItemCounterSNES;
[Header("Refrences Info Canvas")]
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;
[Header("Refrences Sprites")]
    //SNES SPRITES
    public Sprite SNESSprite;
    public Sprite SNESControllerSprite;
    public Sprite SNESCartridgeSprite;
[Header("Console")]
    //CONSOLE
    public TMP_Text InteractWithSNESConsole;
    public GameObject SNES;
    private OVRGrabbable SNESGrabbable;
    private bool isSNESGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn4;
    public GameObject ConsoleImageSlot4;
    public GameObject ConsoleImageSlot4SNES;
[Header("Controller")]
    //CONTROLLER
    public TMP_Text InteractWithSNESController;
    public GameObject SNES_Controller;
    private OVRGrabbable SNESControllerGrabbable;
    private bool isSNESControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn4;
    public GameObject ControllerImageSlot4;
    public GameObject ControllerImageSlot4SNES;
[Header("Cartridge")]
    //CARTRIDGE
    public TMP_Text InteractWithSNESCartridge;
    public GameObject SNES_Cartridge;
    private OVRGrabbable SNESCartridgeGrabbable;
    private bool isSNESCartridgeGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CartridgeNameBtn4;
    public GameObject CartridgeImageSlot4;
    public GameObject CartridgeImageSlot4SNES;

    void Start()
    {
        //Init SNESCounter to false
        isSNESCounted = false;

        //Find ItemCounter
        itemCounterGen4 = FindObjectOfType<ItemCounterGen4>();
        ItemCounterSNES = FindObjectOfType<ItemCounterSNES>();
        
        // Load sprites from Resources
        SNESSprite = Resources.Load<Sprite>("Images/SNES_console");
        SNESControllerSprite = Resources.Load<Sprite>("Images/SNES_controller");
        SNESCartridgeSprite = Resources.Load<Sprite>("Images/SNES_cartridge");

        // Set colors to black
        InteractWithSNESConsole.color = Color.black;
        InteractWithSNESController.color = Color.black;
        InteractWithSNESCartridge.color = Color.black;
        
        // Get 'grabbable' from the gameObjects
        SNESGrabbable = SNES.GetComponent<OVRGrabbable>();
        SNESControllerGrabbable = SNES_Controller.GetComponent<OVRGrabbable>();
        SNESCartridgeGrabbable = SNES_Cartridge.GetComponent<OVRGrabbable>();
        
        // Disable images
        ConsoleImageSlot4SNES.SetActive(false);
        ControllerImageSlot4SNES.SetActive(false);
        CartridgeImageSlot4SNES.SetActive(false);
    }
        
    void Update(){
        //CONSOLE
        if (SNESGrabbable.isGrabbed && !isSNESGrabbed){
            GrabSNES();
            isSNESGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SNESGrabbable.isGrabbed && isSNESGrabbed){
            isSNESGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (SNESControllerGrabbable.isGrabbed && !isSNESControllerGrabbed){
            GrabSNESController();
            isSNESControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SNESControllerGrabbable.isGrabbed && isSNESControllerGrabbed){
            isSNESControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (SNESCartridgeGrabbable.isGrabbed && !isSNESCartridgeGrabbed){
            GrabSNESCartridge();
            isSNESCartridgeGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!SNESCartridgeGrabbable.isGrabbed && isSNESCartridgeGrabbed){
            isSNESCartridgeGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabSNES(){
        InteractWithSNESConsole.color = Color.green;
        DebugText.text = "Item added to inventory: SNES Console";
        ConsoleImageSlot4SNES.SetActive(true);
        ConsoleImageSlot4.SetActive(false);
        ConsoleNameBtn4.GetComponentInChildren<TextMeshProUGUI>().text = "SNES";
        SNESConsoleInfo();
        if (!isSNESCounted){
            itemCounterGen4.IncrementCounterGen4();
            ItemCounterSNES.IncrementCounterSNES();
            isSNESCounted = true;
        }
    }
    private void GrabSNESController(){
        InteractWithSNESController.color = Color.green;
        DebugText.text = "Item added to inventory: SNES Controller";
        ControllerImageSlot4SNES.SetActive(true);
        ControllerImageSlot4.SetActive(false);
        ControllerNameBtn4.GetComponentInChildren<TextMeshProUGUI>().text = "SNES";
        SNESControllerInfo();
        if (!isSNESControllerCounted){
            itemCounterGen4.IncrementCounterGen4();
            ItemCounterSNES.IncrementCounterSNES();
            isSNESControllerCounted = true;
        }
    }
    
    private void GrabSNESCartridge(){
        InteractWithSNESCartridge.color = Color.green;
        DebugText.text = "Item added to inventory: SNES Cartridge";
        CartridgeImageSlot4SNES.SetActive(true);
        CartridgeImageSlot4.SetActive(false);
        CartridgeNameBtn4.GetComponentInChildren<TextMeshProUGUI>().text = "SNES";
        SNESCartridgeInfo();
        if (!isSNESCartridgeCounted){
            itemCounterGen4.IncrementCounterGen4();
            ItemCounterSNES.IncrementCounterSNES();
            isSNESCartridgeCounted = true;
        }
    }

    // INFO FUNCTIONS
    public void SNESConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = SNESSprite;
        ItemDescriptionName.text = "SNES";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "Released: 1990\n"+
        "About: The 'Super Nintendo Entertainment System' had a different name in Japan and Europe, where it was released under the 'Super Famicom' name.\n"+
        "The SNES had 2 different color schemes depending on the region: a gray and purple color scheme in the US and a more grey console, but more colorful controller in Europe.";
    }
    public void SNESControllerInfo(){
        ItemDescriptionImage.sprite = SNESControllerSprite;
        ItemDescriptionName.text = "SNES";
        ItemDescriptionText.text = "About: The SNES controller is known for its rounded, ergonomic design, which improved comfort during extended play sessions. It features a cross-shaped D-pad on the left side for precise directional control. On the right side, it has four action buttons labeled A, B, X, and Y, arranged in a diamond pattern, providing versatile input options for games.\n"+
        "The controller also includes 'Start' and 'Select' buttons in the center, used for pausing games and navigating menus. Additionally, it introduced shoulder buttons, L and R, on the top edge of the controller.";
    }
    public void SNESCartridgeInfo(){
        ItemDescriptionImage.sprite = SNESCartridgeSprite;
        ItemDescriptionName.text = "SNES";
        ItemDescriptionText.text = "About: The SNES cartridge is a compact, rectangular plastic module used to store and play video games on the Super Nintendo Entertainment System. Each cartridge contains a printed circuit board with ROM chips that hold the game data, and sometimes additional chips for enhanced graphics or processing capabilities. The front of the cartridge features a label with the game's title and artwork.\n"+
        "Cartridges are inserted into a top-loading slot on the SNES console, connecting via a 62-pin edge connector to the system.";
    }
}
