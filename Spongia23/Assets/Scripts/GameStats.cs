using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameStats
{
    public int TotalClicks;
    public float TotalTime;

    public GameStats()
    {
        TotalClicks = 0;
        TotalTime = 0;
    }
}
