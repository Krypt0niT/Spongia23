using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIdentifier : MonoBehaviour
{
    public bool Active;

    public void MoveCameraToBackground()
    {
        var cameraFollow = GameObject.FindObjectOfType<CameraFollow>();
        cameraFollow.Target = transform;
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
