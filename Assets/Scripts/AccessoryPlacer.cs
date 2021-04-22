using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryPlacer : MonoBehaviour
{
    public List<GameObject> AccessoryList;
    public ObjectPlacer ObjectPlacer; 
    public PlayerInputController PlayerInputController;
    
    private List<GameObject> _accessoryList;
    private GameObject _tempObj;
    private void Awake()
    {
        // Instantiate Accessory List
        _accessoryList = new List<GameObject>();
        
        // Instantiate the accessory prefabs and add to list
        foreach (GameObject accessory in AccessoryList)
        {
            _tempObj = Instantiate(accessory, Vector3.zero, Quaternion.Euler(0, 0, 0));
           
            for (int i = 0; i < 9; i++)
            {
                _tempObj.transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
            _accessoryList.Add(_tempObj);
        }
        
        // Set onBeforeRender function, called just before the next frame is rendered
        Application.onBeforeRender += OnBeforeRender;
    }
    

    private void OnEnable()
    {
        // Transform Accessories to car position
        foreach (GameObject accessory in _accessoryList)
        {
            accessory.transform.position = ObjectPlacer.placedObject.transform.position;
            accessory.transform.rotation = ObjectPlacer.placedObject.transform.rotation;
        }
    }

    private void OnDisable()
    {
        // Hide the accessories
        foreach (GameObject accessory in _accessoryList)
        { 
            for (int i = 0; i < 9; i++)
            {
                accessory.transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
        }
    }

    private void Update() => PerformUpdate();
    
    private void OnBeforeRender() => PerformUpdate();
    
    private void PerformUpdate()
    {
        if (PlayerInputController.lf &&
            !_accessoryList[0].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[0].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
        }
        else if (PlayerInputController.rf && !_accessoryList[1].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[1].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
        }
        else if (PlayerInputController.lr && !_accessoryList[2].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[2].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
        }
        else if (PlayerInputController.rr && !_accessoryList[3].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[3].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
        }
        else if (!PlayerInputController.lf && _accessoryList[0].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[0].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
        }
        else if (!PlayerInputController.rf && _accessoryList[1].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[1].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
        }
        else if (!PlayerInputController.lr && _accessoryList[2].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[2].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
        }
        else if (!PlayerInputController.rr && _accessoryList[3].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[0].enabled)
        {
            for (int i = 0; i < 9; i++)
            {
                _accessoryList[3].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
        }
    }
}
