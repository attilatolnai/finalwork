using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class NESScript : MonoBehaviour
{
    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;

    //NES SPRITES
    public Sprite NESSprite;
    public Sprite NESControllerSprite;
    public Sprite NESCartridgeSprite;

    //CONSOLE
    public TMP_Text InteractWithNESConsole;
    public GameObject NES;
    private OVRGrabbable NESGrabbable;
    private bool isNESGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn2;
    public GameObject ConsoleImageSlot2;
    public GameObject ConsoleImageSlot2NES;

    //CONTROLLER
    public TMP_Text InteractWithNESController;
    public GameObject NES_Controller;
    private OVRGrabbable NESControllerGrabbable;
    private bool isNESControllerGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ControllerNameBtn2;
    public GameObject ControllerImageSlot2;
    public GameObject ControllerImageSlot2NES;

    //CARTRIDGE
    public TMP_Text InteractWithNESCartridge;
    public GameObject NES_Cartridge;
    private OVRGrabbable NESCartridgeGrabbable;
    private bool isNESCartridgeGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CartridgeNameBtn2;
    public GameObject CartridgeImageSlot2;
    public GameObject CartridgeImageSlot2NES;


    void Start()
    {
        // Load sprites from Resources
        NESSprite = Resources.Load<Sprite>("Images/NES_console");
        NESControllerSprite = Resources.Load<Sprite>("Images/NES_controller");
        NESCartridgeSprite = Resources.Load<Sprite>("Images/NES_cartridge");

        // Set colors to white
        InteractWithNESConsole.color = Color.white;
        InteractWithNESController.color = Color.white;
        InteractWithNESCartridge.color = Color.white;

        // Get 'grabbable' from the gameObjects
        NESGrabbable = NES.GetComponent<OVRGrabbable>();
        NESControllerGrabbable = NES_Controller.GetComponent<OVRGrabbable>();
        NESCartridgeGrabbable = NES_Cartridge.GetComponent<OVRGrabbable>();

        // Disable images
        ConsoleImageSlot2NES.SetActive(false);
        ControllerImageSlot2NES.SetActive(false);
        CartridgeImageSlot2NES.SetActive(false);
    }

    void Update()
    {
        //CONSOLE
        if (NESGrabbable.isGrabbed && !isNESGrabbed){
            GrabNES();
            isNESGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!NESGrabbable.isGrabbed && isNESGrabbed){
            isNESGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (NESControllerGrabbable.isGrabbed && !isNESControllerGrabbed){
            GrabNESController();
            isNESControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!NESControllerGrabbable.isGrabbed && isNESControllerGrabbed){
            isNESControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (NESCartridgeGrabbable.isGrabbed && !isNESCartridgeGrabbed){
            GrabNESCartridge();
            isNESCartridgeGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!NESCartridgeGrabbable.isGrabbed && isNESCartridgeGrabbed){
            isNESCartridgeGrabbed = false;
            InfoCanvas.SetActive(false);
        }
    }

    //GRAB FUNCTIONS
    private void GrabNES(){
        InteractWithNESConsole.color = Color.green;
        ConsoleImageSlot2NES.SetActive(true);
        ConsoleImageSlot2.SetActive(false);
        ConsoleNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
        NESConsoleInfo();
    }
    
    private void GrabNESController(){
        InteractWithNESController.color = Color.green;
        ControllerImageSlot2NES.SetActive(true);
        ControllerImageSlot2.SetActive(false);
        ControllerNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
        NESControllerInfo();
    }

    private void GrabNESCartridge(){
        InteractWithNESCartridge.color = Color.green;
        CartridgeImageSlot2NES.SetActive(true);
        CartridgeImageSlot2.SetActive(false);
        CartridgeNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
        NESCartridgeInfo();
    }
    
    // INFO FUNCTIONS
    public void NESConsoleInfo(){
        ItemDescriptionImage.sprite = NESSprite;
        ItemDescriptionName.text = "NES";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "Released: July 1983 (Japan), October 1985 (North America), September 1986 (Europe)\n"+
        "About: The Nintendo Entertainment System (NES) revolutionized the home gaming industry upon its release. Developed by Nintendo, it became one of the best-selling consoles of its time, introducing iconic franchises like 'Super Mario Bros.', 'The Legend of Zelda', and 'Metroid'.\n"+
        "With its distinctive gray box design and rectangular controller, the NES became an enduring symbol of 1980s pop culture and remains beloved by gamers worldwide.";
    }

    public void NESControllerInfo(){
        ItemDescriptionImage.sprite = NESControllerSprite;
        ItemDescriptionName.text = "NES";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "About: The NES controller, also referred to as the 'NES gamepad', was the primary input device for the Nintendo Entertainment System (NES). With its rectangular design housing a directional pad (D-pad), 'Start' and 'Select' buttons, and 'A' and 'B' buttons, it established a benchmark for future console controllers.\n"+
        "Its straightforward yet efficient layout ensured seamless gameplay control and significantly contributed to the NES's success and the enduring popularity of its iconic game library.";
    }

    public void NESCartridgeInfo(){
        ItemDescriptionImage.sprite = NESCartridgeSprite;
        ItemDescriptionName.text = "NES";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "About: The NES cartridge, also known simply as a 'game cartridge' or 'NES cartridge', served as the physical medium for distributing games on the Nintendo Entertainment System (NES). \n"+
        "Produced by various game developers alongside Nintendo, these cartridges contained read-only memory (ROM) chips storing game code and data.\n"+
        "They facilitated a diverse range of gaming experiences and played a pivotal role in establishing the NES as one of the most iconic consoles in gaming history.";
    }
}
