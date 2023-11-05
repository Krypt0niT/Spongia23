using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

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
}
