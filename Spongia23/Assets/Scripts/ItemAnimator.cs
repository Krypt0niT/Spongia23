using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemAnimator : MonoBehaviour
{
    private Animation animation;
    private bool ShouldPlay;

    private void Start()
    {
        animation = transform.GetChild(0).GetComponent<Animation>();
    }

    private void Update()
    {
        if (ShouldPlay)
        {
            if (!animation.isPlaying)
            {
                animation.Play();
            }
        }   
    }

    public void Enter()
    {
        ShouldPlay = true;
    }

    public void Left()
    {
        ShouldPlay = false;
    }
}
