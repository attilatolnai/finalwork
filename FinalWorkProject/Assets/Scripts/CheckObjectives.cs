using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class CheckObjectives : MonoBehaviour
{
    //DebugText
    public TMP_Text CompletedText;

    //CANVAS
    public GameObject DoorCanvas;
    public AtariScript AtariScript;
    public NESScript NESScript;
    /*
    public GenesisScript GenesisScript;
    public SNESScript SNESScript;
    */

    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;

    private void Start()
    {

        // Disable DoorCanvas
        DoorCanvas.SetActive(true);

        // Disable InfoCanvas
        InfoCanvas.SetActive(false);

        // Set initial InfoCanvas components
        ItemDescriptionImage.sprite = null;
        ItemDescriptionName.text = "???";
        ItemDescriptionText.text = "???";

    }

    private void Update()
    {
        //Check if all objectives have been completed
        if (CheckAllObjectivesDone()){
            CompletedText.text = "Congratulations! You completed Room 1!";
        }
        /*
        if (CheckAllObjectivesDoneGen4()){
            CompletedText.text = "Congratulations! You completed Room 2!";
        }
        */
    }

    private bool CheckAllObjectivesDone()
    {
        // Check if all objectives are done
        return AtariScript.InteractWithAtariConsole.color == Color.green &&
               AtariScript.InteractWithAtariController.color == Color.green &&
               AtariScript.InteractWithAtariCartridge.color == Color.green &&
               NESScript.InteractWithNESConsole.color == Color.green &&
               NESScript.InteractWithNESController.color == Color.green &&
               NESScript.InteractWithNESCartridge.color == Color.green;
    }
    /*
    private bool CheckAllObjectivesDoneGen4()
    {
        // Check if all objectives are done
        return GenesisScript.InteractWithGenesisConsole.color == Color.green &&
               GenesisScript.InteractWithGenesisController.color == Color.green &&
               GenesisScript.InteractWithGenesisCartridge.color == Color.green &&
               SNESScript.InteractWithSNESConsole.color == Color.green &&
               SNESScript.InteractWithSNESController.color == Color.green &&
               SNESScript.InteractWithSNESCartridge.color == Color.green;
    }
    */
}
