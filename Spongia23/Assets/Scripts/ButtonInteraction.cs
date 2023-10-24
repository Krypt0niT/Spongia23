using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public bool SmoothTransition;
    public BackgroundIdentifier BackgroundIdentifier;
    public float AlphaSpeed = 10;
    public byte Alpha = 10;

    private Animation animation;

    private void Start()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,0);
        animation = GetComponent<Animation>();
    }

    public void MoveBackground()
    {
        BackgroundIdentifier.MoveCameraToBackground(SmoothTransition);
    }
    
    public void HoverStart()
    {
        animation.Stop();
        animation.clip = animation.GetClip("ShowHighlight");

        animation.Play();
    }

    public void HoverEnd()
    {
        animation.Stop();
        animation.clip = animation.GetClip("HideHighlight");
        animation.Play();
    }
}

