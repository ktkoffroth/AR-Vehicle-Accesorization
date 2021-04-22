using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject placeObject;
    public GameObject placedObject;
    public Camera arCamera;

    private GameObject _placementIndicator;
    private PlayerInputController _playerInputController;
    private Transform _arCameraTransform;
    private Vector3 _posOffset;
    private Quaternion _rotOffset;

    private void Awake()
    {
        // Setup our Target instance
        placedObject = Instantiate(placeObject, Vector3.zero, Quaternion.Euler(0, 0, 0));
        placedObject.SetActive(false);

        // Find and set inactive placementIndicator GamObject
        _placementIndicator = gameObject.transform.GetChild(0).gameObject;
        _placementIndicator.gameObject.SetActive(false);
        
        // Find PlayerInputController
        _playerInputController = FindObjectOfType<PlayerInputController>();

        // Set onBeforeRender function, called just before the next frame is rendered
        Application.onBeforeRender += OnBeforeRender;
    }

    private void OnEnable()
    {
        _placementIndicator.gameObject.SetActive(true);
        EnhancedTouchSupport.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        _placementIndicator.gameObject.SetActive(false);
        placedObject.GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        EnhancedTouchSupport.Disable();
    }

    private void FingerDown(Finger finger)
    {
        Touch();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        EnhancedTouchSupport.Disable();
    }

    void Update() => PerformUpdate();
    
    void OnBeforeRender() => PerformUpdate();
    
    void PerformUpdate()
    {
        _posOffset = arCamera.transform.position - placedObject.transform.position;
        _rotOffset = Quaternion.Euler(arCamera.transform.rotation.eulerAngles.x - placedObject.transform.rotation.eulerAngles.x,
            arCamera.transform.rotation.eulerAngles.y - placedObject.transform.rotation.eulerAngles.y, arCamera.transform.rotation.eulerAngles.z - placedObject.transform.rotation.eulerAngles.z);

        if (_playerInputController.position && !_playerInputController.targetLock)
            Position();
        else if (_playerInputController.rotation && !_playerInputController.targetLock)
            Rotation();
        
        // change layer of target
        if (_playerInputController.targetLock)
        {
            placedObject.GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
        }
        else
        {
            if (!placedObject.GetComponentsInChildren<MeshRenderer>()[0].enabled)
            {
                placedObject.GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
            }
        }
    }

    private void Position()
    {
        placedObject.transform.position = arCamera.transform.position + _posOffset;
    }

    private void Rotation()
    {
        placedObject.transform.rotation = Quaternion.Euler(arCamera.transform.rotation.eulerAngles.x + _rotOffset.eulerAngles.x,
            arCamera.transform.rotation.eulerAngles.y + _rotOffset.eulerAngles.y, arCamera.transform.rotation.eulerAngles.z + _rotOffset.eulerAngles.z);
    }

    private void Touch()
    {
        placedObject.transform.position = _placementIndicator.transform.position;
        placedObject.transform.rotation = _placementIndicator.transform.rotation;
        placedObject.SetActive(true);
        _placementIndicator.gameObject.SetActive(false);
    }
}
