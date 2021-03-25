using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject placeObject;
    public PlacementIndicator placementIndicator;
    public Camera arCamera;
    
    private GameObject _placedObject;
    private bool _position, _rotation;
    private Transform _arCameraTransform;
    private Vector3 _posOffset;
    private Quaternion _rotOffset;

    void Start()
    {
        _placedObject = Instantiate(placeObject, Vector3.zero, Quaternion.Euler(0, 0, 0));
        _placedObject.SetActive(false);
    }

    private void Awake()
    {
        placementIndicator.gameObject.SetActive(true);
        Application.onBeforeRender += OnBeforeRender;
    }

    void Update() => PerformUpdate();
    
    void OnBeforeRender() => PerformUpdate();
    
    void PerformUpdate()
    {
        _posOffset = arCamera.transform.position - _placedObject.transform.position;
        _rotOffset = Quaternion.Euler(0,
            arCamera.transform.rotation.eulerAngles.y - _placedObject.transform.rotation.eulerAngles.y, 0);

        if (_position)
            Position();
        else if (_rotation)
            Rotation();
    }

    public void OnPosition()
    {
        _position = !_position;
    }

    public void OnRotation()
    {
        _rotation = !_rotation;
    }

    public void Position()
    {
        _placedObject.transform.position = arCamera.transform.position + _posOffset;
    }

    public void Rotation()
    {
        _placedObject.transform.rotation = Quaternion.Euler(0, arCamera.transform.rotation.eulerAngles.y + _rotOffset.eulerAngles.y, 0);
    }

    public void Touch()
    {
        _placedObject.transform.position = placementIndicator.transform.position;
        _placedObject.transform.rotation = placementIndicator.transform.rotation;
        _placedObject.SetActive(true);
        placementIndicator.gameObject.SetActive(false);
    }
}
