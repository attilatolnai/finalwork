using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using OculusSampleFramework;

public class CheckObjectivesMuseum : MonoBehaviour
{
    //DebugText
    public TMP_Text CompletedText;

    //CANVAS
[Header("Other Canvas")]
    public GameObject DoorCanvas;
    public GameObject TVCanvas;
[Header("Gen3 TV")]
    public GameObject TVCanvasAtari;
    public GameObject TVCanvasNES;
[Header("Gen4 TV")]
    public GameObject TVCanvasGenesis;
    public GameObject TVCanvasSNES;
[Header("Gen5 TV")]
    public GameObject TVCanvasPS1;
    public GameObject TVCanvasSaturn;
    public GameObject TVCanvasN64;
[Header("Gen6 TV")]
    public GameObject TVCanvasPS2;
    public GameObject TVCanvasGamecube;
    public GameObject TVCanvasDreamcast;
    public GameObject TVCanvasXbox;
[Header("Gen7 TV")]
    public GameObject TVCanvasPS3;
    public GameObject TVCanvasXbox360;
    public GameObject TVCanvasWii;
[Header("Gen8 TV")]
    public GameObject TVCanvasPS4;
    public GameObject TVCanvasXboxOne;
    public GameObject TVCanvasSwitch;
[Header("Gen9 TV")]
    public GameObject TVCanvasPS5;
    public GameObject TVCanvasXboxSeries;


    //SCRIPTS
[Header("Gen3 Scripts")]
    public AtariScript AtariScript;
    public NESScript NESScript;
[Header("Gen4 Scripts")]
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;
[Header("Gen5 Scripts")]
    public PS1Script PS1Script;
    public N64Script N64Script;
    public SaturnScript SaturnScript;
[Header("Gen6 Scripts")]
    public PS2Script PS2Script;
    public GamecubeScript GamecubeScript;
    public DreamcastScript DreamcastScript;
    public XboxScript XboxScript;
[Header("Gen7 Scripts")]
    public PS3Script PS3Script;
    public Xbox360Script Xbox360Script;
    public WiiScript WiiScript;
[Header("Gen8 Scripts")]
    public PS4Script PS4Script;
    public XboxOneScript XboxOneScript;
    public SwitchScript SwitchScript;
[Header("Gen9 Scripts")]
    public PS5Script PS5Script;
    public XboxSeriesScript XboxSeriesScript;
    //INFOCANVAS
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
        TVCanvasAtari.SetActive(false);
        TVCanvasNES.SetActive(false);
        TVCanvasGenesis.SetActive(false);
        TVCanvasSNES.SetActive(false);
        TVCanvasPS1.SetActive(false);
        TVCanvasSaturn.SetActive(false);
        TVCanvasN64.SetActive(false);
        TVCanvasPS2.SetActive(false);
        TVCanvasGamecube.SetActive(false);
        TVCanvasDreamcast.SetActive(false);
        TVCanvasXbox.SetActive(false);
        TVCanvasPS3.SetActive(false);
        TVCanvasXbox360.SetActive(false);
        TVCanvasWii.SetActive(false);
        TVCanvasPS4.SetActive(false);
        TVCanvasXboxOne.SetActive(false);
        TVCanvasSwitch.SetActive(false);
        TVCanvasPS5.SetActive(false);
        TVCanvasXboxSeries.SetActive(false);

        // Disable InfoCanvas
        InfoCanvas.SetActive(false);

        // Set initial InfoCanvas components
        ItemDescriptionImage.sprite = null;
        ItemDescriptionName.text = "???";
        ItemDescriptionText.text = "???";
    }

    private void Update()
    {
        if(CheckAtariObjectivesDone()){
            TVCanvasAtari.SetActive(true);
        }
        if(CheckNESObjectivesDone()){
            TVCanvasNES.SetActive(true);
        }
        if(CheckGenesisObjectivesDone()){
            TVCanvasGenesis.SetActive(true);
        }
        if(CheckSNESObjectivesDone()){
            TVCanvasSNES.SetActive(true);
        }
        if(CheckPS1ObjectivesDone()){
            TVCanvasPS1.SetActive(true);
        }
        if(CheckSaturnObjectivesDone()){
            TVCanvasSaturn.SetActive(true);
        }
        if(CheckN64ObjectivesDone()){
            TVCanvasN64.SetActive(true);
        }
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
        if(CheckPS3ObjectivesDone()){
            TVCanvasPS3.SetActive(true);
        }
        if(CheckXbox360ObjectivesDone()){
            TVCanvasXbox360.SetActive(true);
        }
        if(CheckWiiObjectivesDone()){
            TVCanvasWii.SetActive(true);
        }
        if(CheckPS4ObjectivesDone()){
            TVCanvasPS4.SetActive(true);
        }
        if(CheckXboxOneObjectivesDone()){
            TVCanvasXboxOne.SetActive(true);
        }
        if(CheckSwitchObjectivesDone()){
            TVCanvasSwitch.SetActive(true);
        }
        if(CheckPS5ObjectivesDone()){
            TVCanvasPS5.SetActive(true);
        }
        if(CheckXboxSeriesObjectivesDone()){
            TVCanvasXboxSeries.SetActive(true);
        }
        if (CheckAllObjectivesDone()){
            CompletedText.text = "Congratulations! You completed the museum!";
            TVCanvas.SetActive(true);
        }
    }

    private bool CheckAtariObjectivesDone(){
        return AtariScript.InteractWithAtariConsole.color == Color.green &&
               AtariScript.InteractWithAtariController.color == Color.green &&
               AtariScript.InteractWithAtariCartridge.color == Color.green;
    }

    private bool CheckNESObjectivesDone(){
        return NESScript.InteractWithNESConsole.color == Color.green &&
               NESScript.InteractWithNESController.color == Color.green &&
               NESScript.InteractWithNESCartridge.color == Color.green;
    }
    private bool CheckGenesisObjectivesDone(){
        return GenesisScript.InteractWithGenesisConsole.color == Color.green &&
               GenesisScript.InteractWithGenesisController.color == Color.green &&
               GenesisScript.InteractWithGenesisCartridge.color == Color.green;
    }

    private bool CheckSNESObjectivesDone(){
        return SNESScript.InteractWithSNESConsole.color == Color.green &&
               SNESScript.InteractWithSNESController.color == Color.green &&
               SNESScript.InteractWithSNESCartridge.color == Color.green;
    }

    private bool CheckPS1ObjectivesDone(){
        return PS1Script.InteractWithPS1Console.color == Color.green &&
               PS1Script.InteractWithPS1Controller.color == Color.green &&
               PS1Script.InteractWithPS1Case.color == Color.green;
    }
    private bool CheckSaturnObjectivesDone(){
        return SaturnScript.InteractWithSaturnConsole.color == Color.green &&
               SaturnScript.InteractWithSaturnController.color == Color.green &&
               SaturnScript.InteractWithSaturnCase.color == Color.green;
    }

    private bool CheckN64ObjectivesDone(){
        return N64Script.InteractWithN64Console.color == Color.green &&
               N64Script.InteractWithN64Controller.color == Color.green &&
               N64Script.InteractWithN64Cartridge.color == Color.green;
    }

    private bool CheckPS2ObjectivesDone(){
        return PS2Script.InteractWithPS2Console.color == Color.green &&
               PS2Script.InteractWithPS2Controller.color == Color.green &&
               PS2Script.InteractWithPS2Case.color == Color.green;
    }

    private bool CheckGamecubeObjectivesDone(){
        return GamecubeScript.InteractWithGamecubeConsole.color == Color.green &&
               GamecubeScript.InteractWithGamecubeController.color == Color.green &&
               GamecubeScript.InteractWithGamecubeCase.color == Color.green;
    }

    private bool CheckDreamcastObjectivesDone(){
        return DreamcastScript.InteractWithDreamcastConsole.color == Color.green &&
               DreamcastScript.InteractWithDreamcastController.color == Color.green &&
               DreamcastScript.InteractWithDreamcastCase.color == Color.green;
    }

    private bool CheckXboxObjectivesDone(){
        return XboxScript.InteractWithXboxConsole.color == Color.green &&
               XboxScript.InteractWithXboxController.color == Color.green &&
               XboxScript.InteractWithXboxCase.color == Color.green;
    }

    private bool CheckPS3ObjectivesDone(){
        return PS3Script.InteractWithPS3Console.color == Color.green &&
               PS3Script.InteractWithPS3Controller.color == Color.green &&
               PS3Script.InteractWithPS3Case.color == Color.green;
    }

    private bool CheckXbox360ObjectivesDone(){
        return Xbox360Script.InteractWithXbox360Console.color == Color.green &&
               Xbox360Script.InteractWithXbox360Controller.color == Color.green &&
               Xbox360Script.InteractWithXbox360Case.color == Color.green;
    }

    private bool CheckWiiObjectivesDone(){
        return WiiScript.InteractWithWiiConsole.color == Color.green &&
               WiiScript.InteractWithWiiController.color == Color.green &&
               WiiScript.InteractWithWiiCase.color == Color.green;
    }

    private bool CheckPS4ObjectivesDone(){
        return PS4Script.InteractWithPS4Console.color == Color.green &&
               PS4Script.InteractWithPS4Controller.color == Color.green &&
               PS4Script.InteractWithPS4Case.color == Color.green;
    }

    private bool CheckXboxOneObjectivesDone(){
        return XboxOneScript.InteractWithXboxOneConsole.color == Color.green &&
               XboxOneScript.InteractWithXboxOneController.color == Color.green &&
               XboxOneScript.InteractWithXboxOneCase.color == Color.green;
    }

    private bool CheckSwitchObjectivesDone(){
        return SwitchScript.InteractWithSwitchConsole.color == Color.green &&
               SwitchScript.InteractWithSwitchController.color == Color.green &&
               SwitchScript.InteractWithSwitchCase.color == Color.green;
    }

    private bool CheckPS5ObjectivesDone(){
        return PS5Script.InteractWithPS5Console.color == Color.green &&
               PS5Script.InteractWithPS5Controller.color == Color.green &&
               PS5Script.InteractWithPS5Case.color == Color.green;
    }

    private bool CheckXboxSeriesObjectivesDone(){
        return XboxSeriesScript.InteractWithXboxSeriesConsole.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesController.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesCase.color == Color.green;
    }

    private bool CheckAllObjectivesDone(){
        return AtariScript.InteractWithAtariConsole.color == Color.green &&
               AtariScript.InteractWithAtariController.color == Color.green &&
               AtariScript.InteractWithAtariCartridge.color == Color.green &&
               NESScript.InteractWithNESConsole.color == Color.green &&
               NESScript.InteractWithNESController.color == Color.green &&
               NESScript.InteractWithNESCartridge.color == Color.green &&
               GenesisScript.InteractWithGenesisConsole.color == Color.green &&
               GenesisScript.InteractWithGenesisController.color == Color.green &&
               GenesisScript.InteractWithGenesisCartridge.color == Color.green &&
               SNESScript.InteractWithSNESConsole.color == Color.green &&
               SNESScript.InteractWithSNESController.color == Color.green &&
               SNESScript.InteractWithSNESCartridge.color == Color.green &&
               PS1Script.InteractWithPS1Console.color == Color.green &&
               PS1Script.InteractWithPS1Controller.color == Color.green &&
               PS1Script.InteractWithPS1Case.color == Color.green &&
               SaturnScript.InteractWithSaturnConsole.color == Color.green &&
               SaturnScript.InteractWithSaturnController.color == Color.green &&
               SaturnScript.InteractWithSaturnCase.color == Color.green &&
               N64Script.InteractWithN64Console.color == Color.green &&
               N64Script.InteractWithN64Controller.color == Color.green &&
               N64Script.InteractWithN64Cartridge.color == Color.green &&
               PS2Script.InteractWithPS2Console.color == Color.green &&
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
               XboxScript.InteractWithXboxCase.color == Color.green &&
               PS3Script.InteractWithPS3Console.color == Color.green &&
               PS3Script.InteractWithPS3Controller.color == Color.green &&
               PS3Script.InteractWithPS3Case.color == Color.green &&
               Xbox360Script.InteractWithXbox360Console.color == Color.green &&
               Xbox360Script.InteractWithXbox360Controller.color == Color.green &&
               Xbox360Script.InteractWithXbox360Case.color == Color.green &&
               WiiScript.InteractWithWiiConsole.color == Color.green &&
               WiiScript.InteractWithWiiController.color == Color.green &&
               WiiScript.InteractWithWiiCase.color == Color.green &&
               PS4Script.InteractWithPS4Console.color == Color.green &&
               PS4Script.InteractWithPS4Controller.color == Color.green &&
               PS4Script.InteractWithPS4Case.color == Color.green &&
               XboxOneScript.InteractWithXboxOneConsole.color == Color.green &&
               XboxOneScript.InteractWithXboxOneController.color == Color.green &&
               XboxOneScript.InteractWithXboxOneCase.color == Color.green &&
               SwitchScript.InteractWithSwitchConsole.color == Color.green &&
               SwitchScript.InteractWithSwitchController.color == Color.green &&
               SwitchScript.InteractWithSwitchCase.color == Color.green &&
               PS5Script.InteractWithPS5Console.color == Color.green &&
               PS5Script.InteractWithPS5Controller.color == Color.green &&
               PS5Script.InteractWithPS5Case.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesConsole.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesController.color == Color.green &&
               XboxSeriesScript.InteractWithXboxSeriesCase.color == Color.green;
    }
}
