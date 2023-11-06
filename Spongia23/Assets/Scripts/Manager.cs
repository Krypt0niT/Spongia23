using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Manager : MonoBehaviour
{
    [SerializeField] public GameStats stats;
    void Start()
    {
        stats = new GameStats();
        DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindObjectsOfType<Manager>().Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        //GameStart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            stats.TotalClicks += 1;        
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("ShakesAndFidget");
        foreach (Transform transform in this.gameObject.transform)
        {
            transform.gameObject.SetActive(true);
        }
    }
    
    public void ApplySetting()
    {
        var settings = this.GetComponent<Settings>();

        var musicAudioSources = FindObjectsOfType<AudioSource>(true).Where(x => x.gameObject.name == "Music").ToList();
        var effectsAudioSources = FindObjectsOfType<AudioSource>(true).Where(x => x.name != "Music").ToList();

        var videoPlayers = FindObjectsOfType<VideoPlayer>().ToList();


        musicAudioSources.ForEach(x => x.volume = settings.MusicVolume);
        effectsAudioSources.ForEach(x => x.volume = settings.SoundEffectsVolume);

        videoPlayers.ForEach(x => x.enabled = settings.AnimatedBackgroud);
    }
}
