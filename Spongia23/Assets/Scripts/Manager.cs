using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Manager : MonoBehaviour
{
    [SerializeField] public GameStats stats;

    public bool GameEnded = false;
    public bool SpongiaPlaying = false;
    public GameObject PauseMenu;

    void Start()
    {
        stats = new GameStats();
        DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindObjectsOfType<Manager>().Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(PauseMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            stats.TotalClicks += 1;
            if (GameEnded)
            {
                var games = GameObject.FindObjectsOfType<GameIdentifier>(true).ToList();
                games.ForEach(x => SceneManager.MoveGameObjectToScene(x.gameObject, SceneManager.GetActiveScene()));
                GameObject.FindObjectsOfType<InventorySlot>(true).ToList().ForEach(x => x.RemoveItem());
                SceneManager.LoadScene(0);
                GameEnded = false;
            }

        }
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if (SpongiaPlaying) return;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
            }
        }
        stats.TotalTime += Time.deltaTime;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("ShakesAndFidget");
        foreach (Transform transform in this.gameObject.transform)
        {
            transform.gameObject.SetActive(true);
        }
        stats = new GameStats();
    }
    
    public void ApplySetting()
    {
        var settings = this.GetComponent<Settings>();

        var musicAudioSources = FindObjectsOfType<AudioSource>(true).Where(x => x.gameObject.name == "Music").ToList();
        var effectsAudioSources = FindObjectsOfType<AudioSource>(true).Where(x => x.name != "Music").ToList();

        var videoPlayers = FindObjectsOfType<VideoPlayer>().ToList();


        musicAudioSources.ForEach(x => x.volume = settings.MusicVolume);
        effectsAudioSources.ForEach(x => x.volume = settings.SoundEffectsVolume);

        if (settings.AnimatedBackgroud)
        {
            videoPlayers.ForEach(x => x.playbackSpeed = 1);
        }
        else
        {
            videoPlayers.ForEach(x => x.playbackSpeed = 0);
        }

        if (!settings.ParticleSystem)
        {
            var backgroundIdentifiers = GameObject.FindObjectsOfType<BackgroundIdentifier>().ToList();
            backgroundIdentifiers.ForEach(x => x.Particles.ToList().ForEach(x => x.Stop()));
        }
        else
        {
            var activeBackground = GameObject.FindObjectsOfType<BackgroundIdentifier>().ToList().FirstOrDefault(x => x.IsActive);
            activeBackground.Particles.ToList().Where(x => !x.isPlaying).ToList().ForEach(x => x.Play());
        }
    }
}
