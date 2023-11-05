using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsGameObject;
    public GameObject InfoGameObject;


    public void Play()
    {

    }

    public void Settings()
    {
        SettingsGameObject.SetActive(true);
        this.gameObject.SetActive(false);

        //load setting
        var settings = GameObject.FindObjectOfType<Settings>();
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = settings.MusicVolume;
        GameObject.Find("SoundEffectsSlider").GetComponent<Slider>().value = settings.SoundEffectsVolume;
        GameObject.Find("AnimationTogler").GetComponent<Toggle>().isOn = settings.AnimatedBackgroud;
        GameObject.Find("ParticleTogler").GetComponent<Toggle>().isOn = settings.ParticleSystem;
    }

    public void Info()
    {
        InfoGameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
