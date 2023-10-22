using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public bool SmoothTransition;
    public BackgroundIdentifier BackgroundIdentifier;
    public byte Alpha = 10;

    public void MoveBackground()
    {
        BackgroundIdentifier.MoveCameraToBackground(SmoothTransition);
    }
    
    public void HoverStart()
    {
        var color = (Color32)GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r,color.g,color.b, Alpha);
    }

    public void HoverEnd()
    {
        var color = (Color32)GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 0);
    }
}

