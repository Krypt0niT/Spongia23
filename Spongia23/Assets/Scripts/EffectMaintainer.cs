using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMaintainer : MonoBehaviour
{
    public bool Available;
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Maintain()
    {
        if (!Available) return;
        var main = particleSystem.main;
        main.prewarm = true;
        main.startDelay = 0;

        particleSystem.Play();
    }
}
