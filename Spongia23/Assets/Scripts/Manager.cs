using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindObjectsOfType<Manager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
