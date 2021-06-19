using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSelector : MonoBehaviour
{
    ///<summary>The plane selected.</summary>
    public static ARPlane playPlane;

    // Plane Manager
    private ARPlaneManager _planeManager;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectPlane(ARPlane target)
    {
        //Select the target plane.
        playPlane = target;

        //Remove EVERY OTHER plane.
        foreach (var plane in _planeManager.trackables)
        {
            if (plane != playPlane)
                Destroy(plane);
        }
        _planeManager.enabled = false;
    }
}
