using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public bool SmoothTransition;
    public BackgroundIdentifier BackgroundIdentifier;

    public void MoveBackground()
    {
        BackgroundIdentifier.MoveCameraToBackground();
    }
}
