using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectChange : MonoBehaviour
{
    public GameObject GameObject;
    public bool DestroySelf = false;

    public void Change()
    {
        GameObject.SetActive(!GameObject.activeInHierarchy);
        if (DestroySelf)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
