using UnityEngine;
using System.Linq;

public class GameIdentifier : MonoBehaviour
{
    public string SceneName;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        var gameIdentifiers = GameObject.FindObjectsOfType<GameIdentifier>(true);
        if (gameIdentifiers.Where(x => x.SceneName == SceneName).Count() > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
