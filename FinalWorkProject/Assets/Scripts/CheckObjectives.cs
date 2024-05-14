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

    private void Start()
    {
        // Disable DoorCanvas
        DoorCanvas.SetActive(false);

        // Set colors to white
        InteractWithAtariConsole.color = Color.white;
        InteractWithAtariController.color = Color.white;
        InteractWithAtariCartridge.color = Color.white;
        // Get 'grabbable' from the gameObjects
        AtariGrabbable = Atari.GetComponent<OVRGrabbable>();
        AtariControllerGrabbable = Atari_Controller.GetComponent<OVRGrabbable>();
        AtariCartridgeGrabbable = Atari_Cartridge.GetComponent<OVRGrabbable>();
        

        ConsoleImageSlot1Atari.SetActive(false);
        ControllerImageSlot1Atari.SetActive(false);
        CartridgeImageSlot1Atari.SetActive(false);
    }

    private void Update()
    {
        //ATARI-----------------------------------------------------------------------------------------------------------------------------------------------------
        //CONSOLE
        if (AtariGrabbable.isGrabbed && !isAtariGrabbed)
        {
            GrabAtari();
            Debug.Log("The Atari is grabbed");
            isAtariGrabbed = true;
        }
        //CONTROLLER
        if (AtariControllerGrabbable.isGrabbed && !isAtariControllerGrabbed)
        {
            GrabAtariController();
            isAtariControllerGrabbed = true;
        }
        //CARTRIDGE
        if (AtariCartridgeGrabbable.isGrabbed && !isAtariCartridgeGrabbed)
        {
            GrabAtariCartridge();
            isAtariCartridgeGrabbed = true;
        }

        //Check if all objectives have been completed
        if (CheckAllObjectivesDone())
        {
            DoorCanvas.SetActive(true);
        }
    }

    private void GrabAtari()
    {
        InteractWithAtariConsole.color = Color.green;
        ConsoleImageSlot1Atari.SetActive(true);
        ConsoleImageSlot1.SetActive(false);
        ConsoleNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
    }

    private void GrabAtariController()
    {
        InteractWithAtariController.color = Color.green;
        ControllerImageSlot1Atari.SetActive(true);
        ControllerImageSlot1.SetActive(false);
        ControllerNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
    }

    private void GrabAtariCartridge()
    {
        InteractWithAtariCartridge.color = Color.green;
        CartridgeImageSlot1Atari.SetActive(true);
        CartridgeImageSlot1.SetActive(false);
        CartridgeNameBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Atari 2600";
    }

    private bool CheckAllObjectivesDone()
    {
        // Check if all objectives are done
        return InteractWithAtariConsole.color == Color.green && 
        InteractWithAtariController.color == Color.green &&
        InteractWithAtariCartridge.color == Color.green;
    }
}
