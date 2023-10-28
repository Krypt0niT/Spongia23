using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIdentifier : MonoBehaviour
{
    public void MoveCameraToBackground(bool smooth = false)
    {
        var cameraFollow = GameObject.FindObjectOfType<CameraFollow>();

        if (!smooth)
        {
            cameraFollow.enabled = false;
            var cameraTransform = GameObject.FindObjectOfType<Camera>().transform;
            var position = transform.position;
            cameraTransform.position = new Vector3(position.x, position.y, -10);
        }
        else
        {
            cameraFollow.enabled = true;
            cameraFollow.Target = transform;
        }
    }
}
