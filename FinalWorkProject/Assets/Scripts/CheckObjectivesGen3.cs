using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using OculusSampleFramework;

public class CheckObjectivesGen3 : MonoBehaviour
{
    //DebugText
    public TMP_Text CompletedText;

    //CANVAS
    public GameObject DoorCanvas;
    public GameObject TVCanvas;
    public GameObject TVCanvasAtari;
    public GameObject TVCanvasNES;
    

    //SCRIPTS
    public AtariScript AtariScript;
    public NESScript NESScript;

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
        if (CheckAllObjectivesDone()){
            CompletedText.text = "Congratulations! You completed Room 1!";
            TVCanvas.SetActive(true);
        }
    }

    private bool CheckAtariObjectivesDone(){
        return AtariScript.InteractWithAtariConsole.color == Color.green &&
               AtariScript.InteractWithAtariController.color == Color.green &&
               AtariScript.InteractWithAtariCartridge.color == Color.green;
    }

    private bool CheckNESObjectivesDone()
    {
        return NESScript.InteractWithNESConsole.color == Color.green &&
               NESScript.InteractWithNESController.color == Color.green &&
               NESScript.InteractWithNESCartridge.color == Color.green;
    }

    private bool CheckAllObjectivesDone(){
        return AtariScript.InteractWithAtariConsole.color == Color.green &&
               AtariScript.InteractWithAtariController.color == Color.green &&
               AtariScript.InteractWithAtariCartridge.color == Color.green &&
               NESScript.InteractWithNESConsole.color == Color.green &&
               NESScript.InteractWithNESController.color == Color.green &&
               NESScript.InteractWithNESCartridge.color == Color.green;
    }
}
