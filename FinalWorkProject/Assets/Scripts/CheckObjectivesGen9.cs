using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class CheckObjectivesGen9 : MonoBehaviour
{
    //DebugText
    public TMP_Text CompletedText;
[Header("References Canvases")]
    public GameObject DoorCanvas;
    public GameObject TVCanvas;
    public GameObject TVCanvasPS5;
    public GameObject TVCanvasXboxSeries;
[Header("References Current Generation Scripts")]
    public PS5Script PS5Script;
    public XboxSeriesScript XboxSeriesScript;
[Header("References Previous Generation Scripts")]
    public AtariScript AtariScript;
    public NESScript NESScript;
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;
    public PS1Script PS1Script;
    public N64Script N64Script;
    public SaturnScript SaturnScript;
    public PS2Script PS2Script;
    public GamecubeScript GamecubeScript;
    public DreamcastScript DreamcastScript;
    public XboxScript XboxScript;
    public PS3Script PS3Script;
    public Xbox360Script Xbox360Script;
    public WiiScript WiiScript;
    public PS4Script PS4Script;
    public XboxOneScript XboxOneScript;
    public SwitchScript SwitchScript;
[Header("Console Image Slots")]
    public GameObject ConsoleImageSlot1Atari;
    public GameObject ConsoleImageSlot2NES;
    public GameObject ConsoleImageSlot3Genesis;
    public GameObject ConsoleImageSlot4SNES;
    public GameObject ConsoleImageSlot5PS1;
    public GameObject ConsoleImageSlot6N64;
    public GameObject ConsoleImageSlot7Saturn;
    public GameObject ConsoleImageSlot8PS2;
    public GameObject ConsoleImageSlot9Gamecube;
    public GameObject ConsoleImageSlot10Dreamcast;
    public GameObject ConsoleImageSlot11Xbox;
    public GameObject ConsoleImageSlot12PS3;
    public GameObject ConsoleImageSlot13Xbox360;
    public GameObject ConsoleImageSlot14Wii;
    public GameObject ConsoleImageSlot15PS4;
    public GameObject ConsoleImageSlot16XboxOne;
    public GameObject ConsoleImageSlot17Switch;
[Header("Controller Image Slots")]
    public GameObject ControllerImageSlot1Atari;
    public GameObject ControllerImageSlot2NES;
    public GameObject ControllerImageSlot3Genesis;
    public GameObject ControllerImageSlot4SNES;
    public GameObject ControllerImageSlot5PS1;
    public GameObject ControllerImageSlot6N64;
    public GameObject ControllerImageSlot7Saturn;
    public GameObject ControllerImageSlot8PS2;
    public GameObject ControllerImageSlot9Gamecube;
    public GameObject ControllerImageSlot10Dreamcast;
    public GameObject ControllerImageSlot11Xbox;
    public GameObject ControllerImageSlot12PS3;
    public GameObject ControllerImageSlot13Xbox360;
    public GameObject ControllerImageSlot14Wii;
    public GameObject ControllerImageSlot15PS4;
    public GameObject ControllerImageSlot16XboxOne;
    public GameObject ControllerImageSlot17Switch;
[Header("Cartridge Image Slots")]
    public GameObject CartridgeImageSlot1Atari;
    public GameObject CartridgeImageSlot2NES;
    public GameObject CartridgeImageSlot3Genesis;
    public GameObject CartridgeImageSlot4SNES;
    public GameObject CartridgeImageSlot5N64;
[Header("Case Image Slots")]
    public GameObject CaseImageSlot1Saturn;
    public GameObject CaseImageSlot2PS1;
    public GameObject CaseImageSlot3PS2;
    public GameObject CaseImageSlot4Gamecube;
    public GameObject CaseImageSlot5Dreamcast;
    public GameObject CaseImageSlot6Xbox;
    public GameObject CaseImageSlot7PS3;
    public GameObject CaseImageSlot8Xbox360;
    public GameObject CaseImageSlot9Wii;
    public GameObject CaseImageSlot10PS4;
    public GameObject CaseImageSlot11XboxOne;
    public GameObject CaseImageSlot12Switch;
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
        TVCanvasPS5.SetActive(false);
        TVCanvasXboxSeries.SetActive(false);

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
        ControllerImageSlot8PS2.SetActive(true);
        ControllerImageSlot9Gamecube.SetActive(true);
        ControllerImageSlot10Dreamcast.SetActive(true);
        ControllerImageSlot11Xbox.SetActive(true);
        ControllerImageSlot12PS3.SetActive(true);
        ControllerImageSlot13Xbox360.SetActive(true);
        ControllerImageSlot14Wii.SetActive(true);
        ControllerImageSlot15PS4.SetActive(true);
        ControllerImageSlot16XboxOne.SetActive(true);
        ControllerImageSlot17Switch.SetActive(true);

        CartridgeImageSlot1Atari.SetActive(true);
        CartridgeImageSlot2NES.SetActive(true);
        CartridgeImageSlot3Genesis.SetActive(true);
        CartridgeImageSlot4SNES.SetActive(true);
        CartridgeImageSlot5N64.SetActive(true);

        CaseImageSlot1Saturn.SetActive(true);
        CaseImageSlot2PS1.SetActive(true);
        CaseImageSlot3PS2.SetActive(true);
        CaseImageSlot4Gamecube.SetActive(true);
        CaseImageSlot5Dreamcast.SetActive(true);
        CaseImageSlot6Xbox.SetActive(true);
        CaseImageSlot7PS3.SetActive(true);
        CaseImageSlot8Xbox360.SetActive(true);
        CaseImageSlot9Wii.SetActive(true);
        CaseImageSlot10PS4.SetActive(true);
        CaseImageSlot11XboxOne.SetActive(true);
        CaseImageSlot12Switch.SetActive(true);
    }

    private void Update()
    {
        if(CheckPS5ObjectivesDone()){
            TVCanvasPS5.SetActive(true);
        }
        if(CheckXboxSeriesObjectivesDone()){
            TVCanvasXboxSeries.SetActive(true);
        }
        if (CheckAllObjectivesDone()){
            CompletedText.text = "Congratulations! You completed Room 7!";
            TVCanvas.SetActive(true);
        }
    }

    private bool CheckPS5ObjectivesDone(){
        return PS5Script.InteractWithPS5Console.color == Color.green &&
               PS5Script.InteractWithPS5Controller.color == Color.green &&
               PS5Script.InteractWithPS5Case.color == Color.green;
    }

    private bool CheckXboxSeriesObjectivesDone()
    {
        return XboxSeriesScript.InteractWithXboxSeriesConsole.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesController.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesCase.color == Color.green;
    }
    private bool CheckAllObjectivesDone(){
        return PS5Script.InteractWithPS5Console.color == Color.green &&
               PS5Script.InteractWithPS5Controller.color == Color.green &&
               PS5Script.InteractWithPS5Case.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesConsole.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesController.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesCase.color == Color.green;
    }
}
