using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject plane;

    void Start()
    {
        // get/init components
        rayManager = FindObjectOfType<ARRaycastManager>();
        plane = transform.GetChild(0).gameObject;
        
        // hide placement plane
        plane.SetActive(false);
    }

    void FixedUpdate()
    {
        // Shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        
        // If we hit an AR plane, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!plane.activeInHierarchy)
                plane.SetActive(true);
        }
    }
}
