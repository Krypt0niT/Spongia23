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

    public void Play()
    {
        StartCoroutine(Effects());
    }

    private IEnumerator Effects()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().Play();

        transform.Find("Black").GetComponent<SpriteRenderer>().enabled = true;
        transform.Find("Black").GetComponent<Animation>().Play();

        GameObject.Find("Inventory").SetActive(false);
        yield return new WaitForSeconds(8.5f);
        Text.SetActive(true);
        GameObject.FindObjectOfType<Manager>().GameEnded = true;

        
        var cas = (int)Time.time;
        var minuty = cas / 60;
        var sekundy = cas % 60;
        TimeObject.text = "Čas: " + minuty + ":" + sekundy;
        Clicks.text = "Počet kliknutí: " + GameObject.FindObjectOfType<Manager>().stats.TotalClicks;
    }
}
