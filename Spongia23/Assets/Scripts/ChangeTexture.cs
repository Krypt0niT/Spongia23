using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Sprite Sprite;

    public void Change()
    {
        GetComponent<SpriteRenderer>().sprite = Sprite;
    }
}
