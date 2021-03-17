using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //public ObjectPlacer objectPlacer;
    private bool _position, _rotation, _touch;
    public Controls Controls;

    private void Awake()
    {
        Controls = new Controls();
    }

    private void OnEnable()
    {
        Controls.Enable();
    }

    private void OnDisable()
    {
        Controls.Disable();
    }

    private void Start()
    {
        // Setup callback for general Touch Press
        Controls.ObjectPlace.TouchPress.canceled += ctx => onRelease(ctx);
        
        // Setup callback for Position and Rotation Buttons
        Controls.ObjectPlace.Position.started += ctx => onPositionStart(ctx);
        Controls.ObjectPlace.Position.canceled += ctx => onPositionStop(ctx);
        Controls.ObjectPlace.Rotation.started += ctx => onRotationStart(ctx);
        Controls.ObjectPlace.Rotation.canceled += ctx => onRotationStop(ctx);

    }

    private void FixedUpdate()
    { 
        if (_position) 
        {
            // put Object Placer Method Here
          Debug.Log("Position Pressed"); 
        }
        else if (_rotation)
        {
            // Put Object Placer Method Here
            Debug.Log("Rotation Pressed");
        }
    }

    public void onPositionStart(InputAction.CallbackContext context)
    {
       _position = true;
    }
    
    public void onPositionStop(InputAction.CallbackContext context)
    {
       _position = false;
    }
    
    public void onRotationStart(InputAction.CallbackContext context)
    {
       _rotation = true;
    }
    
    public void onRotationStop(InputAction.CallbackContext context)
    {
        _rotation = false;
    }
    
    public void onRelease(InputAction.CallbackContext context)
    {
        Debug.Log("onRelease");
        Controls.ObjectPlace.TouchPress.Disable();
    }
}
