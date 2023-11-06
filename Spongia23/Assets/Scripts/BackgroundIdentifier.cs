using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BackgroundIdentifier : MonoBehaviour
{
    public bool IsActive;
    public ParticleSystem[] Particles;

    private void Start()
    {
        TurnOffParticles();
    }

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

        var backgroundIdentifiers = GameObject.FindObjectsOfType<BackgroundIdentifier>().ToList();

        //set activity
        backgroundIdentifiers.ForEach(x => x.IsActive = false);
        IsActive = true;

        TurnOffParticles();
    }

    private void TurnOffParticles()
    {
        var backgroundIdentifiers = GameObject.FindObjectsOfType<BackgroundIdentifier>().ToList();
        backgroundIdentifiers.ForEach(x => x.Particles.ToList().ForEach(x => x.Stop()));

        if (FindObjectOfType<Settings>().ParticleSystem)
        {
            Particles.ToList().ForEach(x => x.Play());
        }
    }
}
