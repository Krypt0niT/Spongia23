using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        var gameScenes = GameObject.FindObjectsOfType<GameIdentifier>(true);
        var currentGame = gameScenes.First(x => x.SceneName == SceneManager.GetActiveScene().name);

        foreach (var gameScene in gameScenes)
        {
            gameScene.gameObject.SetActive(false);
        }
        currentGame.gameObject.SetActive(true);
        ReloadEffects();
    }

    private void ReloadEffects() 
    {
        var EffectsToReload = GameObject.FindObjectsOfType<EffectMaintainer>().ToList();
        foreach (var effect in EffectsToReload)
        {
            effect.Maintain();
        }
    }
}
