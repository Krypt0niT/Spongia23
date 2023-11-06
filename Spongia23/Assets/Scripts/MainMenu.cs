using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsGameObject;
    public GameObject InfoGameObject;

    public MainMenuSettings MainMenuSettings;

    private void Start()
    {
        MainMenuSettings.Load();
    }

    public void Play()
    {
        GameObject.FindObjectOfType<Manager>().GameStart();
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
        if (transform.parent.name == "PauseMenu")
        {
            var games = GameObject.FindObjectsOfType<GameIdentifier>().ToList();
            games.ForEach(x => SceneManager.MoveGameObjectToScene(x.gameObject, SceneManager.GetActiveScene()));
            SceneManager.LoadScene(0);
            this.transform.parent.gameObject.SetActive(false);
            return;
        }
        Application.Quit();
    }
}
