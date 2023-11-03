using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            stats.TotalClicks += 1;        
        }
    }
}
