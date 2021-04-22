using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAccessoryPlaceState : WorldBaseState
{
    public override void EnterState(WorldController controller)
    {
        // Enable necessary UI elements and scripts
        controller.accessoryPlacerUI.alpha = 1;
        controller.accessoryPlacerUI.interactable = true;
        controller.accessoryPlacer.enabled = true;
        
        // Disable Occlusion
        controller.arOcclusionManager.enabled = false;
    }

    public override void LeaveState(WorldController controller)
    {
        // Disable necessary UI elements and scripts
        controller.accessoryPlacerUI.alpha = 0;
        controller.accessoryPlacerUI.interactable = false;
        controller.accessoryPlacer.enabled = false;
        
        // Re-enable Occlusion
        controller.arOcclusionManager.enabled = true;
    }
}
