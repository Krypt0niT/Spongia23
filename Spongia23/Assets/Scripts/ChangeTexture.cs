using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Sprite Sprite;
    public ParticleSystem Particle;
    public float time;

    public void Change()
    {
        if (Particle != null) Particle.Play();
        Invoke("ChangeTextur", time);
    }

    private void ChangeTextur()
    {
        GetComponent<SpriteRenderer>().sprite = Sprite;
    }
}
