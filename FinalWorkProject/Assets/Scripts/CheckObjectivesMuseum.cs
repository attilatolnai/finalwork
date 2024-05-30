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
    public GameObject DoorCanvas;
    public GameObject TVCanvas;
    public GameObject TVCanvasAtari;
    public GameObject TVCanvasNES;
    public GameObject TVCanvasGenesis;
    public GameObject TVCanvasSNES;
    
    //SCRIPTS
    public AtariScript AtariScript;
    public NESScript NESScript;
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;

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

    private bool CheckSNESObjectivesDone()
    {
        return SNESScript.InteractWithSNESConsole.color == Color.green &&
               SNESScript.InteractWithSNESController.color == Color.green &&
               SNESScript.InteractWithSNESCartridge.color == Color.green;
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
               SNESScript.InteractWithSNESCartridge.color == Color.green;

    }
}
