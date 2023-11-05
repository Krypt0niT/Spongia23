using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] sprites;
    public float TimeToSwap;

    private float timeTick = 0;
    private int index = 0;

    private void Update()
    {
        timeTick += Time.deltaTime;
        if (timeTick > TimeToSwap)
        {
            timeTick = 0;
            index++;
            if (index > sprites.Length - 1)
            {
                index = 0;
            }
            GetComponent<SpriteRenderer>().sprite = sprites[index];
        }
    }
}
