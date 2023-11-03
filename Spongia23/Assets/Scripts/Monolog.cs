using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolog : MonoBehaviour
{
    public AnimationClip ShowClip;
    public AnimationClip HideClip;

    private Animation monologAnimation;
    private bool monologShown;

    private void Start()
    {
        monologAnimation = GetComponent<Animation>();
    }

    public void Play()
    {
        if (!monologAnimation.isPlaying)
        {
            if (monologShown)
                monologAnimation.clip = HideClip;
            else
                monologAnimation.clip = ShowClip;

            monologAnimation.Play();
            monologShown = !monologShown;
        }
    }
}
