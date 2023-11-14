using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SpongiaEnd : MonoBehaviour
{
    public GameObject Text;

    public TextMeshProUGUI TimeObject;
    public TextMeshProUGUI Clicks;
    public ParticleSystem ParticleSystem;

    public void Play()
    {
        StartCoroutine(Effects());
    }

    private IEnumerator Effects()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().Play();
        FindObjectOfType<Manager>().SpongiaPlaying = true;
        transform.Find("Black").GetComponent<SpriteRenderer>().enabled = true;
        transform.Find("Black").GetComponent<Animation>().Play();

        GameObject.Find("Inventory").SetActive(false);

        yield return new WaitForSeconds(8.5f);

        Text.SetActive(true);
        GameObject.FindObjectOfType<Manager>().GameEnded = true;

        ParticleSystem.Play();
        
        var cas = (int)GameObject.FindObjectOfType<Manager>().stats.TotalTime;
        var minuty = cas / 60;
        var sekundy = cas % 60;
        if (sekundy >= 10)
        {
            TimeObject.text = "Čas: " + minuty + ":" + sekundy;
        }
        else
        {
            TimeObject.text = "Čas: " + minuty + ":0" + sekundy;
        }
        
        Clicks.text = "Počet kliknutí: " + GameObject.FindObjectOfType<Manager>().stats.TotalClicks;
        FindObjectOfType<Manager>().SpongiaPlaying = false;

    }
}
