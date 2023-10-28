using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectChange : MonoBehaviour
{
    public GameObject GameObject;

    public void Change()
    {
        GameObject.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
