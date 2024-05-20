using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class CheckObjectives : MonoBehaviour
{
    //CANVAS
    public GameObject DoorCanvas;

    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;

    //SPRITES
    public Sprite AtariSprite;
    public Sprite AtariControllerSprite;
    public Sprite AtariCartridgeSprite;
    public Sprite NESSprite;
    public Sprite NESControllerSprite;
    public Sprite NESCartridgeSprite;

    //ATARI-------------------------------------------------------------------------
    //CONSOLE
    public TMP_Text InteractWithAtariConsole;
    public GameObject Atari;
    private OVRGrabbable AtariGrabbable;
    private bool isAtariGrabbed = false;
    //CONSOLE IMAGES AND TEXT
    public TMP_Text ConsoleNameBtn1;
    public GameObject ConsoleImageSlot1;
    public GameObject ConsoleImageSlot1Atari;

    //CONTROLLER
    public TMP_Text InteractWithAtariController;
    public GameObject Atari_Controller;
    private OVRGrabbable AtariControllerGrabbable;
    private bool isAtariControllerGrabbed = false;
    //CONTROLLER IMAGES AND TEXT
    public TMP_Text ControllerNameBtn1;
    public GameObject ControllerImageSlot1;
    public GameObject ControllerImageSlot1Atari;

    //CARTRIDGE
    public TMP_Text InteractWithAtariCartridge;
    public GameObject Atari_Cartridge;
    private OVRGrabbable AtariCartridgeGrabbable;
    private bool isAtariCartridgeGrabbed = false;
    //CARTRIDGE IMAGES AND TEXT
    public TMP_Text CartridgeNameBtn1;
    public GameObject CartridgeImageSlot1;
    public GameObject CartridgeImageSlot1Atari;

    //NES----------------------------------------------------------------------------
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
    

    private void Start()
    {
        // Disable DoorCanvas
        DoorCanvas.SetActive(false);

        // Disable InfoCanvas
        InfoCanvas.SetActive(false);

        // Load sprites from Resources
        AtariSprite = Resources.Load<Sprite>("Images/Atari_console");
        AtariControllerSprite = Resources.Load<Sprite>("Images/Atari_controller");
        AtariCartridgeSprite = Resources.Load<Sprite>("Images/Atari_cartridge");
        NESSprite = Resources.Load<Sprite>("Images/NES_console");
        NESControllerSprite = Resources.Load<Sprite>("Images/NES_controller");
        NESCartridgeSprite = Resources.Load<Sprite>("Images/NES_cartridge");

        // Set initial InfoCanvas components
        ItemDescriptionImage.sprite = null;
        ItemDescriptionName.text = "???";
        ItemDescriptionText.text = "???";

        // Set colors to white
        InteractWithAtariConsole.color = Color.white;
        InteractWithAtariController.color = Color.white;
        InteractWithAtariCartridge.color = Color.white;
        InteractWithNESConsole.color = Color.white;
        InteractWithNESController.color = Color.white;
        InteractWithAtariCartridge.color = Color.white;
        // Get 'grabbable' from the gameObjects
        AtariGrabbable = Atari.GetComponent<OVRGrabbable>();
        AtariControllerGrabbable = Atari_Controller.GetComponent<OVRGrabbable>();
        AtariCartridgeGrabbable = Atari_Cartridge.GetComponent<OVRGrabbable>();
        NESGrabbable = NES.GetComponent<OVRGrabbable>();
        NESControllerGrabbable = NES_Controller.GetComponent<OVRGrabbable>();
        NESCartridgeGrabbable = NES_Cartridge.GetComponent<OVRGrabbable>();
        

        ConsoleImageSlot1Atari.SetActive(false);
        ControllerImageSlot1Atari.SetActive(false);
        CartridgeImageSlot1Atari.SetActive(false);
        ConsoleImageSlot2NES.SetActive(false);
        ControllerImageSlot2NES.SetActive(false);
        CartridgeImageSlot2NES.SetActive(false);
    }

    private void Update()
    {
        //ATARI----------------------------------------------------------------------------------
        //CONSOLE
        if (AtariGrabbable.isGrabbed && !isAtariGrabbed){
            GrabAtari();
            Debug.Log("The Atari is grabbed");
            isAtariGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!AtariGrabbable.isGrabbed && isAtariGrabbed){
            isAtariGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CONTROLLER
        if (AtariControllerGrabbable.isGrabbed && !isAtariControllerGrabbed){
            GrabAtariController();
            isAtariControllerGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!AtariControllerGrabbable.isGrabbed && isAtariControllerGrabbed){
            isAtariControllerGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //CARTRIDGE
        if (AtariCartridgeGrabbable.isGrabbed && !isAtariCartridgeGrabbed){
            GrabAtariCartridge();
            isAtariCartridgeGrabbed = true;
            InfoCanvas.SetActive(true);
        }
        else if (!AtariCartridgeGrabbable.isGrabbed && isAtariCartridgeGrabbed){
            isAtariCartridgeGrabbed = false;
            InfoCanvas.SetActive(false);
        }
        //NES----------------------------------------------------------------------------------
        //CONSOLE
        if (NESGrabbable.isGrabbed && !isNESGrabbed){
            GrabNES();
            Debug.Log("The NES is grabbed");
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

        //OBJECTIVES DONE-------------------------------------------------------------------
        //Check if all objectives have been completed
        if (CheckAllObjectivesDone()){
            DoorCanvas.SetActive(true);
        }
    }

    //GRAB FUNCTIONS------------------------------------------------------------------------------------------------------------------------------
    //ATARI
    private void GrabAtari(){
        InteractWithAtariConsole.color = Color.green;
        ConsoleImageSlot1Atari.SetActive(true);
        ConsoleImageSlot1.SetActive(false);
        ConsoleNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
        AtariConsoleInfo();
    }
    public void AtariConsoleInfo(){
        //Update InfoCanvas
        ItemDescriptionImage.sprite = AtariSprite;
        ItemDescriptionName.text = "Atari";
        ItemDescriptionText.text = "Made by: Atari, Inc.\n"+
        "Released: September 1977\n"+
        "About: The Atari 2600 was one of the first home video game consoles to use microprocessor-based hardware and ROM cartridges, allowing users to play a variety of games.\n"+
        "It played a pivotal role in the growth of the video game industry, popularizing home gaming and introducing iconic games like 'Space Invaders' and 'Pitfall!'.\n"+
        "The Atari 2600 remains a beloved and influential piece of gaming history.";
    }

    private void GrabAtariController(){
        InteractWithAtariController.color = Color.green;
        ControllerImageSlot1Atari.SetActive(true);
        ControllerImageSlot1.SetActive(false);
        ControllerNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
        AtariControllerInfo();
    }
    public void AtariControllerInfo(){
        ItemDescriptionImage.sprite = AtariControllerSprite;
        ItemDescriptionName.text = "Atari";
        ItemDescriptionText.text = "Made by: Atari, Inc.\n"+
        "About: A single-button digital joystick with 8-directional movement and a simple, but ergonomic design\n"+
        "The Atari 2600 controller is often referred simply as the 'joystick', featuring a single red button and a joystick for directional input.\n"+
        "It offered intuitive gameplay controls for the console's library of games and set a standard for future game controllers.";
    }

    private void GrabAtariCartridge(){
        InteractWithAtariCartridge.color = Color.green;
        CartridgeImageSlot1Atari.SetActive(true);
        CartridgeImageSlot1.SetActive(false);
        CartridgeNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
        AtariCartridgeInfo();
    }
    public void AtariCartridgeInfo(){
        ItemDescriptionImage.sprite = AtariCartridgeSprite;
        ItemDescriptionName.text = "Atari";
        ItemDescriptionText.text = "Made by: Atari, Inc. and various other game developers.\n"+
        "The Atari 2600 cartridge, also known simply as a 'game cartridge' or 'cartridge', was the physical medium used to distribute games for the Atari 2600 console\n"+
        "These cartridges contained read-only memory (ROM) chips that stored game code and data, with varied storage capacities typically ranging from 2KB to 32KB\n"+
        "With their colorful labels and distinctive shapes, Atari 2600 cartridges became iconic symbols of the early video game era.";
    }

    //NES
    private void GrabNES(){
        InteractWithNESConsole.color = Color.green;
        ConsoleImageSlot2NES.SetActive(true);
        ConsoleImageSlot2.SetActive(false);
        ConsoleNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
        NESConsoleInfo();
    }
    public void NESConsoleInfo(){
        ItemDescriptionImage.sprite = NESSprite;
        ItemDescriptionName.text = "NES";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "Released: July 1983 (Japan), October 1985 (North America), September 1986 (Europe)\n"+
        "About: The Nintendo Entertainment System (NES) revolutionized the home gaming industry upon its release. Developed by Nintendo, it became one of the best-selling consoles of its time, introducing iconic franchises like 'Super Mario Bros.', 'The Legend of Zelda', and 'Metroid'.\n"+
        "With its distinctive gray box design and rectangular controller, the NES became an enduring symbol of 1980s pop culture and remains beloved by gamers worldwide.";
    }

    private void GrabNESController(){
        InteractWithNESController.color = Color.green;
        ControllerImageSlot2NES.SetActive(true);
        ControllerImageSlot2.SetActive(false);
        ControllerNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
        NESControllerInfo();
    }
    public void NESControllerInfo(){
        ItemDescriptionImage.sprite = NESControllerSprite;
        ItemDescriptionName.text = "NES";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "About: The NES controller, also referred to as the 'NES gamepad', was the primary input device for the Nintendo Entertainment System (NES). With its rectangular design housing a directional pad (D-pad), 'Start' and 'Select' buttons, and 'A' and 'B' buttons, it established a benchmark for future console controllers.\n"+
        "Its straightforward yet efficient layout ensured seamless gameplay control and significantly contributed to the NES's success and the enduring popularity of its iconic game library.";
    }

    private void GrabNESCartridge(){
        InteractWithNESCartridge.color = Color.green;
        CartridgeImageSlot2NES.SetActive(true);
        CartridgeImageSlot2.SetActive(false);
        CartridgeNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
        NESCartridgeInfo();
    }
    public void NESCartridgeInfo(){
        ItemDescriptionImage.sprite = NESCartridgeSprite;
        ItemDescriptionName.text = "NES";
        ItemDescriptionText.text = "Made by: Nintendo\n"+
        "About: The NES cartridge, also known simply as a 'game cartridge' or 'NES cartridge', served as the physical medium for distributing games on the Nintendo Entertainment System (NES). \n"+
        "Produced by various game developers alongside Nintendo, these cartridges contained read-only memory (ROM) chips storing game code and data.\n"+
        "They facilitated a diverse range of gaming experiences and played a pivotal role in establishing the NES as one of the most iconic consoles in gaming history.";
    }


    private bool CheckAllObjectivesDone(){
        // Check if all objectives are done
        return InteractWithAtariConsole.color == Color.green && 
        InteractWithAtariController.color == Color.green &&
        InteractWithAtariCartridge.color == Color.green &&
        InteractWithNESConsole.color == Color.green &&
        InteractWithNESController.color == Color.green &&
        InteractWithAtariCartridge.color == Color.green;
    }
}
