using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class CheckObjectivesGen5 : MonoBehaviour
{
    //DebugText
    public TMP_Text CompletedText;
[Header("References Canvases")]
    public GameObject DoorCanvas;
    public GameObject TVCanvas;
    public GameObject TVCanvasPS1;
    public GameObject TVCanvasSaturn;
    public GameObject TVCanvasN64;
[Header("References Current Generation Scripts")]
    public PS1Script PS1Script;
    public SaturnScript SaturnScript;
    public N64Script N64Script;
[Header("References Previous Generation Scripts")]
    public AtariScript AtariScript;
    public NESScript NESScript;
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;
[Header("Console Image Slots")]
    public GameObject ConsoleImageSlot1Atari;
    public GameObject ConsoleImageSlot2NES;
    public GameObject ConsoleImageSlot3Genesis;
    public GameObject ConsoleImageSlot4SNES;
[Header("Controller Image Slots")]
    public GameObject ControllerImageSlot1Atari;
    public GameObject ControllerImageSlot2NES;
    public GameObject ControllerImageSlot3Genesis;
    public GameObject ControllerImageSlot4SNES;
[Header("Cartridge Image Slots")]
    public GameObject CartridgeImageSlot1Atari;
    public GameObject CartridgeImageSlot2NES;
    public GameObject CartridgeImageSlot3Genesis;
    public GameObject CartridgeImageSlot4SNES;
[Header("References Info Canvas")]
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;

    private void Start()
    {
        DoorCanvas.SetActive(true);

        // Disable TVCanvas
        TVCanvas.SetActive(false);
        TVCanvasPS1.SetActive(false);
        TVCanvasSaturn.SetActive(false);
        TVCanvasN64.SetActive(false);

        // Disable InfoCanvas
        InfoCanvas.SetActive(false);

        // Set initial InfoCanvas components
        ItemDescriptionImage.sprite = null;
        ItemDescriptionName.text = "???";
        ItemDescriptionText.text = "???";

        //Enable previous items
        ConsoleImageSlot1Atari.SetActive(true);
        ConsoleImageSlot2NES.SetActive(true);
        ConsoleImageSlot3Genesis.SetActive(true);
        ConsoleImageSlot4SNES.SetActive(true);
        ControllerImageSlot1Atari.SetActive(true);
        ControllerImageSlot2NES.SetActive(true);
        ControllerImageSlot3Genesis.SetActive(true);
        ControllerImageSlot4SNES.SetActive(true);
        CartridgeImageSlot1Atari.SetActive(true);
        CartridgeImageSlot2NES.SetActive(true);
        CartridgeImageSlot3Genesis.SetActive(true);
        CartridgeImageSlot4SNES.SetActive(true);
    }

    private void Update()
    {
        if(CheckPS1ObjectivesDone()){
            TVCanvasPS1.SetActive(true);
        }
        if(CheckSaturnObjectivesDone()){
            TVCanvasSaturn.SetActive(true);
        }
        if(CheckN64ObjectivesDone()){
            TVCanvasN64.SetActive(true);
        }
        if (CheckAllObjectivesDone()){
            CompletedText.text = "Congratulations! You completed Room 2!";
            TVCanvas.SetActive(true);
        }
    }

    private bool CheckPS1ObjectivesDone(){
        return PS1Script.InteractWithPS1Console.color == Color.green &&
               PS1Script.InteractWithPS1Controller.color == Color.green &&
               PS1Script.InteractWithPS1Case.color == Color.green;
    }

    private bool CheckSaturnObjectivesDone()
    {
        return SaturnScript.InteractWithSaturnConsole.color == Color.green &&
               SaturnScript.InteractWithSaturnController.color == Color.green &&
               SaturnScript.InteractWithSaturnCase.color == Color.green;
    }
    private bool CheckN64ObjectivesDone()
    {
        return N64Script.InteractWithN64Console.color == Color.green &&
               N64Script.InteractWithN64Controller.color == Color.green &&
               N64Script.InteractWithN64Cartridge.color == Color.green;
    }

    private bool CheckAllObjectivesDone(){
        return PS1Script.InteractWithPS1Console.color == Color.green &&
               PS1Script.InteractWithPS1Controller.color == Color.green &&
               PS1Script.InteractWithPS1Case.color == Color.green &&
               SaturnScript.InteractWithSaturnConsole.color == Color.green &&
               SaturnScript.InteractWithSaturnController.color == Color.green &&
               SaturnScript.InteractWithSaturnCase.color == Color.green &&
               N64Script.InteractWithN64Console.color == Color.green &&
               N64Script.InteractWithN64Controller.color == Color.green &&
               N64Script.InteractWithN64Cartridge.color == Color.green;
    }
}
