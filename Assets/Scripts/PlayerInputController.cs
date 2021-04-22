using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputController : MonoBehaviour
{
    // Same-Level Unity Scripts
    public ObjectPlacer ObjectPlacer;

    // Public Script Behavior Control Variables
    public bool position, rotation, targetLock; // (ObjectPlacer)

    public bool lf, rf, lr, rr; // (AccessoryPlacer)
    //public List<bool> AccessoryBools = new List<bool>(); // (AccessoryPlacer)
    
    // Image variables for sprite swapping
    public Image targetLockImage;
    public Sprite lockSprite, unlockSprite;

    // Private variables/references
    private WorldController _worldController;
    
    private void Awake()
    {
        _worldController = gameObject.transform.parent.GetComponent<WorldController>();
    }

    // Advance one state in the FSM
    public void OnNext()
    {
        _worldController.Next();
    }
    
    // Go back one state in the FSM
    public void OnBack()
    {
        _worldController.Back();
    }
    
    // Flip position variable for (ObjectPlacer)
    public void OnPosition()
    {
        position = !position;
    }
    
    // Flip rotation variable (ObjectPlacer)
    public void OnRotation()
    {
        rotation = !rotation;
    }

    public void OnLf()
    {
        lf = !lf;
    }

    public void OnRf()
    {
        rf = !rf;
    }

    public void OnLr()
    {
        lr = !lr;
    }

    public void OnRr()
    {
        rr = !rr;
    }
    
    // Lock position of target, hide virtual target (ObjectPlacer)
    public void OnTargetLock()
    {
        targetLock = !targetLock;

        if (targetLock)
        {
            targetLockImage.sprite = unlockSprite;
        }
        else
        {
            targetLockImage.sprite = lockSprite;
        }
    }

}
