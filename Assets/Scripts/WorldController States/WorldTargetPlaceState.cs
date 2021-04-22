using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTargetPlaceState : WorldBaseState
{
    public override void EnterState(WorldController controller)
    {
        // Enable necessary UI elements and scripts
        controller.objectPlacerUI.alpha = 1;
        controller.objectPlacerUI.interactable = true;
        controller.objectPlacer.enabled = true;
    }

    public override void LeaveState(WorldController controller)
    {
        // Disable necessary UI elements and scripts
        controller.objectPlacerUI.alpha = 0;
        controller.objectPlacerUI.interactable = false;
        controller.objectPlacer.enabled = false;
        
        // Clean up UI variables
        controller.playerInputController.position = false;
        controller.playerInputController.rotation = false;
        //controller.playerInputController.targetLock = false;
    }
}
