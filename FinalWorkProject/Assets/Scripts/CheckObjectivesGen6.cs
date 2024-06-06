using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class CheckObjectivesGen6 : MonoBehaviour
{
    //DebugText
    public TMP_Text CompletedText;
[Header("References Canvases")]
    public GameObject DoorCanvas;
    public GameObject TVCanvas;
    public GameObject TVCanvasPS2;
    public GameObject TVCanvasGamecube;
    public GameObject TVCanvasDreamcast;
    public GameObject TVCanvasXbox;
[Header("References Current Generation Scripts")]
    public PS2Script PS2Script;
    public GamecubeScript GamecubeScript;
    public DreamcastScript DreamcastScript;
    public XboxScript XboxScript;
[Header("References Previous Generation Scripts")]
    public AtariScript AtariScript;
    public NESScript NESScript;
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;
    public PS1Script PS1Script;
    public N64Script N64Script;
    public SaturnScript SaturnScript;
[Header("Console Image Slots")]
    public GameObject ConsoleImageSlot1Atari;
    public GameObject ConsoleImageSlot2NES;
    public GameObject ConsoleImageSlot3Genesis;
    public GameObject ConsoleImageSlot4SNES;
    public GameObject ConsoleImageSlot5PS1;
    public GameObject ConsoleImageSlot6N64;
    public GameObject ConsoleImageSlot7Saturn;
[Header("Controller Image Slots")]
    public GameObject ControllerImageSlot1Atari;
    public GameObject ControllerImageSlot2NES;
    public GameObject ControllerImageSlot3Genesis;
    public GameObject ControllerImageSlot4SNES;
    public GameObject ControllerImageSlot5PS1;
    public GameObject ControllerImageSlot6N64;
    public GameObject ControllerImageSlot7Saturn;
[Header("Cartridge Image Slots")]
    public GameObject CartridgeImageSlot1Atari;
    public GameObject CartridgeImageSlot2NES;
    public GameObject CartridgeImageSlot3Genesis;
    public GameObject CartridgeImageSlot4SNES;
    public GameObject CartridgeImageSlot5N64;
[Header("Case Image Slots")]
    public GameObject CaseImageSlot1Saturn;
    public GameObject CaseImageSlot2PS1;
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
        TVCanvasPS2.SetActive(false);
        TVCanvasGamecube.SetActive(false);
        TVCanvasDreamcast.SetActive(false);
        TVCanvasXbox.SetActive(false);

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
        ConsoleImageSlot5PS1.SetActive(true);
        ConsoleImageSlot6N64.SetActive(true);
        ConsoleImageSlot7Saturn.SetActive(true);

        ControllerImageSlot1Atari.SetActive(true);
        ControllerImageSlot2NES.SetActive(true);
        ControllerImageSlot3Genesis.SetActive(true);
        ControllerImageSlot4SNES.SetActive(true);
        ControllerImageSlot5PS1.SetActive(true);
        ControllerImageSlot6N64.SetActive(true);
        ControllerImageSlot7Saturn.SetActive(true);

        CartridgeImageSlot1Atari.SetActive(true);
        CartridgeImageSlot2NES.SetActive(true);
        CartridgeImageSlot3Genesis.SetActive(true);
        CartridgeImageSlot4SNES.SetActive(true);
        CartridgeImageSlot5N64.SetActive(true);

        CaseImageSlot1Saturn.SetActive(true);
        CaseImageSlot2PS1.SetActive(true);
    }

    private void Update()
    {
        if(CheckPS2ObjectivesDone()){
            TVCanvasPS2.SetActive(true);
        }
        if(CheckGamecubeObjectivesDone()){
            TVCanvasGamecube.SetActive(true);
        }
        if(CheckDreamcastObjectivesDone()){
            TVCanvasDreamcast.SetActive(true);
        }
        if(CheckXboxObjectivesDone()){
            TVCanvasXbox.SetActive(true);
        }
        if (CheckAllObjectivesDone()){
            CompletedText.text = "Congratulations! You completed Room 4!";
            TVCanvas.SetActive(true);
        }
    }

    private bool CheckPS2ObjectivesDone(){
        return PS2Script.InteractWithPS2Console.color == Color.green &&
               PS2Script.InteractWithPS2Controller.color == Color.green &&
               PS2Script.InteractWithPS2Case.color == Color.green;
    }

    private bool CheckGamecubeObjectivesDone()
    {
        return GamecubeScript.InteractWithGamecubeConsole.color == Color.green &&
               GamecubeScript.InteractWithGamecubeController.color == Color.green &&
               GamecubeScript.InteractWithGamecubeCase.color == Color.green;
    }
    private bool CheckDreamcastObjectivesDone()
    {
        return DreamcastScript.InteractWithDreamcastConsole.color == Color.green &&
               DreamcastScript.InteractWithDreamcastController.color == Color.green &&
               DreamcastScript.InteractWithDreamcastCase.color == Color.green;
    }
    private bool CheckXboxObjectivesDone()
    {
        return XboxScript.InteractWithXboxConsole.color == Color.green &&
               XboxScript.InteractWithXboxController.color == Color.green &&
               XboxScript.InteractWithXboxCase.color == Color.green;
    }

    private bool CheckAllObjectivesDone(){
        return PS2Script.InteractWithPS2Console.color == Color.green &&
               PS2Script.InteractWithPS2Controller.color == Color.green &&
               PS2Script.InteractWithPS2Case.color == Color.green &&
               GamecubeScript.InteractWithGamecubeConsole.color == Color.green &&
               GamecubeScript.InteractWithGamecubeController.color == Color.green &&
               GamecubeScript.InteractWithGamecubeCase.color == Color.green &&
               DreamcastScript.InteractWithDreamcastConsole.color == Color.green &&
               DreamcastScript.InteractWithDreamcastController.color == Color.green &&
               DreamcastScript.InteractWithDreamcastCase.color == Color.green &&
               XboxScript.InteractWithXboxConsole.color == Color.green &&
               XboxScript.InteractWithXboxController.color == Color.green &&
               XboxScript.InteractWithXboxCase.color == Color.green;
    }
}
