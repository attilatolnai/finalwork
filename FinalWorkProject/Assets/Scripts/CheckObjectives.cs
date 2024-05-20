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
    public AtariScript atariScript;
    public NESScript nesScript;

    //INFOCANVAS
    public GameObject InfoCanvas;
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionName;
    public TMP_Text ItemDescriptionText;
    public Button ItemDescriptionReturnBtn;

    private void Start()
    {

        // Disable DoorCanvas
        DoorCanvas.SetActive(false);

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
            DoorCanvas.SetActive(true);
        }
    }

    private bool CheckAllObjectivesDone()
    {
        // Check if all objectives are done
        return atariScript.InteractWithAtariConsole.color == Color.green &&
               atariScript.InteractWithAtariController.color == Color.green &&
               atariScript.InteractWithAtariCartridge.color == Color.green &&
               nesScript.InteractWithNESConsole.color == Color.green &&
               nesScript.InteractWithNESController.color == Color.green &&
               nesScript.InteractWithNESCartridge.color == Color.green;
    }
}
