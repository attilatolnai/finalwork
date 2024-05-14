using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class SwitchHands : MonoBehaviour
{
    public GameObject CustomRightHand;
    public GameObject CustomRightHand_AtariCartridge;
    public GameObject Atari_Cartridge; // Reference to the Atari_Cartridge GameObject
    
    private OVRGrabbable atariCartridgeGrabbable; // Reference to the OVRGrabbable component on the Atari_Cartridge GameObject
    private bool isAtariCartridgeGrabbed = false;

    private void Start()
    {
        // Ensure the custom hand is initially visible
        CustomRightHand.SetActive(true);
        CustomRightHand_AtariCartridge.SetActive(false);

        // Get the OVRGrabbable component from the Atari_Cartridge GameObject
        atariCartridgeGrabbable = Atari_Cartridge.GetComponent<OVRGrabbable>();
    }

    private void Update()
    {
        // Check for input to grab Atari cartridge
        if (atariCartridgeGrabbable.isGrabbed && !isAtariCartridgeGrabbed)
        {
            GrabAtariCartridge();
            Debug.Log("The Atari is grabbed");
        }

        // Check for input to release Atari cartridge
        if (!atariCartridgeGrabbable.isGrabbed && isAtariCartridgeGrabbed)
        {
            ReleaseAtariCartridge();
        }
    }

    private void GrabAtariCartridge()
    {
        // Hide the custom right hand and show the one with Atari cartridge
        CustomRightHand.SetActive(false);
        CustomRightHand_AtariCartridge.SetActive(true);
        isAtariCartridgeGrabbed = true;
    }

    private void ReleaseAtariCartridge()
    {
        // Show the custom right hand and hide the one with Atari cartridge
        CustomRightHand.SetActive(true);
        CustomRightHand_AtariCartridge.SetActive(false);
        isAtariCartridgeGrabbed = false;
    }
}






