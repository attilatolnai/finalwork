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
        }
        //CARTRIDGE
        if (AtariCartridgeGrabbable.isGrabbed && !isAtariCartridgeGrabbed){
            GrabAtariCartridge();
            isAtariCartridgeGrabbed = true;
        }
        //NES----------------------------------------------------------------------------------
        //CONSOLE
        if (NESGrabbable.isGrabbed && !isNESGrabbed){
            GrabNES();
            Debug.Log("The NES is grabbed");
            isNESGrabbed = true;
        }
        //CONTROLLER
        if (NESControllerGrabbable.isGrabbed && !isNESControllerGrabbed){
            GrabNESController();
            isNESControllerGrabbed = true;
        }
        //CARTRIDGE
        if (NESCartridgeGrabbable.isGrabbed && !isNESCartridgeGrabbed){
            GrabNESCartridge();
            isNESCartridgeGrabbed = true;
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

        // Update InfoCanvas components
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
    }
    private void GrabAtariCartridge(){
        InteractWithAtariCartridge.color = Color.green;
        CartridgeImageSlot1Atari.SetActive(true);
        CartridgeImageSlot1.SetActive(false);
        CartridgeNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
    }
    //NES
    private void GrabNES(){
        InteractWithNESConsole.color = Color.green;
        ConsoleImageSlot2NES.SetActive(true);
        ConsoleImageSlot2.SetActive(false);
        ConsoleNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
    }
    private void GrabNESController(){
        InteractWithNESController.color = Color.green;
        ControllerImageSlot2NES.SetActive(true);
        ControllerImageSlot2.SetActive(false);
        ControllerNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
    }
    private void GrabNESCartridge(){
        InteractWithNESCartridge.color = Color.green;
        CartridgeImageSlot2NES.SetActive(true);
        CartridgeImageSlot2.SetActive(false);
        CartridgeNameBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "NES";
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
