using UnityEngine;

public class GameIdentifier : MonoBehaviour
{
    public string SceneName;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
