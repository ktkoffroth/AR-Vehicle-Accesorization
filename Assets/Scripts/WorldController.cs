using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class WorldController : MonoBehaviour
{
    
    // public references and variables
    public CanvasGroup objectPlacerUI, accessoryPlacerUI;
    public ObjectPlacer objectPlacer;
    public AccessoryPlacer accessoryPlacer;
    public PlayerInputController playerInputController;
    public AROcclusionManager arOcclusionManager;

    // private references and variables
    private WorldBaseState currentState;
    
    // Public State instances
    public readonly WorldTargetPlaceState TargetPlaceState = new WorldTargetPlaceState();
    public readonly WorldAccessoryPlaceState AccessoryPlaceState = new WorldAccessoryPlaceState();
    public readonly WorldTargetSelectState TargetSelectState = new WorldTargetSelectState();

    // Start is called before the first frame update
    void Awake()
    {
        // TODO: Load Target and Accessory files from documents folder, add to accessory list, and generate target/accessory selection panels
        // TODO: Index of UI element, accessory object, and control boolean should match
    }

    void Start()
    {
        // Disable all UI/Scripts except for default
        objectPlacerUI.alpha = 0;
        objectPlacerUI.interactable = false;
        objectPlacer.enabled = false;
        accessoryPlacerUI.alpha = 0;
        accessoryPlacerUI.interactable = false;
        accessoryPlacer.enabled = false;
        
        // Declare Default Current State, Transition to Starting State
        currentState = TargetSelectState;
        TransitionToState(TargetSelectState);
    }

    public void TransitionToState(WorldBaseState state)
    {
        currentState.LeaveState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    public void Next()
    {
        // if we're in the Target Place State, move to the Accessory Place State
        if (currentState.Equals(TargetPlaceState))
        {
            TransitionToState(AccessoryPlaceState);
        }
        else // Else we're in the Accessory Place State, Move to Target Place States
        {
            TransitionToState(TargetPlaceState);
        }
    }

    public void Back()
    {
        // if we're in the Accessory Place State, move to Target Place State
        if (currentState.Equals(AccessoryPlaceState))
        {
            TransitionToState(TargetPlaceState);
        }
    }
}
