using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class CheckObjectivesGen4 : MonoBehaviour
{
    //DebugText
    public TMP_Text CompletedText;
[Header("References Canvases")]
    public GameObject DoorCanvas;
    public GameObject TVCanvas;
    public GameObject TVCanvasGenesis;
    public GameObject TVCanvasSNES;
[Header("References Current Generation Scripts")]
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;
[Header("References Previous Generation Scripts")]
    public AtariScript AtariScript;
    public NESScript NESScript;
[Header("Console Image Slots")]
    public GameObject ConsoleImageSlot1Atari;
    public GameObject ConsoleImageSlot2NES;
[Header("Controller Image Slots")]
    public GameObject ControllerImageSlot1Atari;
    public GameObject ControllerImageSlot2NES;
[Header("Cartridge Image Slots")]
    public GameObject CartridgeImageSlot1Atari;
    public GameObject CartridgeImageSlot2NES;

[Header("References Info Canvas")]
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;

    private void Start(){
        DoorCanvas.SetActive(true);

        // Disable TVCanvas
        TVCanvas.SetActive(false);
        TVCanvasGenesis.SetActive(false);
        TVCanvasSNES.SetActive(false);

        // Disable InfoCanvas
        InfoCanvas.SetActive(false);

        // Set initial InfoCanvas components
        ItemDescriptionImage.sprite = null;
        ItemDescriptionName.text = "???";
        ItemDescriptionText.text = "???";

        //Enable previous items
        ConsoleImageSlot1Atari.SetActive(true);
        ControllerImageSlot1Atari.SetActive(true);
        CartridgeImageSlot1Atari.SetActive(true);
        ConsoleImageSlot2NES.SetActive(true);
        ControllerImageSlot2NES.SetActive(true);
        CartridgeImageSlot2NES.SetActive(true);
    }

    private void Update()
    {
        if(CheckGenesisObjectivesDone()){
            TVCanvasGenesis.SetActive(true);
        }
        if(CheckSNESObjectivesDone()){
            TVCanvasSNES.SetActive(true);
        }
        if (CheckAllObjectivesDone()){
            CompletedText.text = "Congratulations! You completed Room 2!";
            TVCanvas.SetActive(true);
        }
    }

    private bool CheckGenesisObjectivesDone(){
        return GenesisScript.InteractWithGenesisConsole.color == Color.green &&
               GenesisScript.InteractWithGenesisController.color == Color.green &&
               GenesisScript.InteractWithGenesisCartridge.color == Color.green;
    }

    private bool CheckSNESObjectivesDone()
    {
        return SNESScript.InteractWithSNESConsole.color == Color.green &&
               SNESScript.InteractWithSNESController.color == Color.green &&
               SNESScript.InteractWithSNESCartridge.color == Color.green;
    }

    private bool CheckAllObjectivesDone(){
        return GenesisScript.InteractWithGenesisConsole.color == Color.green &&
               GenesisScript.InteractWithGenesisController.color == Color.green &&
               GenesisScript.InteractWithGenesisCartridge.color == Color.green &&
               SNESScript.InteractWithSNESConsole.color == Color.green &&
               SNESScript.InteractWithSNESController.color == Color.green &&
               SNESScript.InteractWithSNESCartridge.color == Color.green;
    }
}
