using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIdentifier : MonoBehaviour
{
    public bool Active;
    private Vector3 cameraPosition;

    private void Start()
    {
        Vector3 position = transform.position;
        cameraPosition = new Vector3(position.x, position.y, -10);
    }

    public void MoveCameraToBackground()
    {
        var camera = GameObject.FindObjectOfType<Camera>();
        camera.transform.position = cameraPosition;
        ResetActiveBackgrounds();
        Active = true;
    }

    private void ResetActiveBackgrounds()
    {
        var Backgrounds = GameObject.FindObjectsOfType<BackgroundIdentifier>();
        foreach (var bg in Backgrounds)
        {
            bg.Active = false;
        }
    }
}
