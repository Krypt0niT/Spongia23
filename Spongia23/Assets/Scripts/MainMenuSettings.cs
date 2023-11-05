using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{
    private string enviromentFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    private string saveFolder;
    private string saveFile;

    private void Start()
    {
        saveFolder = Path.Combine(enviromentFolder, "ChunkerVerse");
        saveFile = saveFolder + "\\Settings.json";
    }

    public void Back()
    {
        GameObject.FindObjectOfType<MainMenu>(true).gameObject.SetActive(true);
        this.gameObject.SetActive(false);
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
    }

    public void Load()
    {
        var settings = GameObject.FindObjectOfType<Settings>();
        JsonUtility.FromJsonOverwrite(saveFile, settings);
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
