using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{
    public MainMenu MainMenu;

    private string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ChunkerVerse";
    private string saveFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ChunkerVerse" + "\\Settings.json";

    private void Start()
    {
        Load();
    }

    public void Back()
    {
        MainMenu.gameObject.SetActive(true);
        var thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        thisButton.transform.parent.gameObject.SetActive(false);
    }

    public void Save()
    {
        DirectoryCheck();

        // save to settings
        var settings = GameObject.FindObjectOfType<Settings>();
        settings.MusicVolume = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
        settings.SoundEffectsVolume = GameObject.Find("SoundEffectsSlider").GetComponent<Slider>().value;
        settings.AnimatedBackgroud = GameObject.Find("AnimationTogler").GetComponent<Toggle>().isOn;
        settings.ParticleSystem = GameObject.Find("ParticleTogler").GetComponent<Toggle>().isOn;

        SaveSettings();
        FindObjectOfType<Manager>().ApplySetting();
    }

    public void Load()
    {
        var settings = GameObject.FindObjectOfType<Settings>();
        var json = File.ReadAllText(saveFile);
        JsonUtility.FromJsonOverwrite(json, settings);
    }
    

    private void DirectoryCheck()
    {
        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
        }
    }

    private void SaveSettings()
    {
        var settings = GameObject.FindObjectOfType<Settings>();
        var jsonData = JsonUtility.ToJson(settings);
        File.WriteAllText(saveFile, jsonData);
    }
}
