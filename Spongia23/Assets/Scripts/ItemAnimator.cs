using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animation animation;
    private bool ShouldPlay;

    private void Start()
    {
        animation = GetComponent<Animation>();    
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
        
    }

    public void Left()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShouldPlay = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShouldPlay = false;
    }
}
