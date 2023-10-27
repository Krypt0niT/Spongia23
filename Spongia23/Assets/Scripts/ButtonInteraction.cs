using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteraction : MonoBehaviour
{
    public bool SmoothTransition;
    public BackgroundIdentifier BackgroundIdentifier;
    public string SceneName;
    public Item Item;

    public ButtonType ButtonType;

    private Animation animation;

    private void Start()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,0);
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        animation = GetComponent<Animation>();
    }

    public void Interact()
    {
        if (ButtonType == ButtonType.Travel)
        {
            BackgroundIdentifier.MoveCameraToBackground(SmoothTransition);
        }
        if (ButtonType == ButtonType.Monolog) 
        {
            print("monolog");
        }
        if (ButtonType == ButtonType.ItemFunction)
        {
            if (this.transform.parent.name == "AbawuwuWheel")
            {
                ItemFunctions.UseAbawuwuWheel(this);
            }
            print("use item");
        }
        if (ButtonType == ButtonType.Portal)
        {
            SceneManager.LoadScene(SceneName);
        }
        if (ButtonType == ButtonType.PickUp)
        {
            PickUpItem();
            GameObject.Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
    
    public void HoverStart()
    {
        animation.Stop();
        animation.clip = animation.GetClip("ShowHighlight");

        animation.Play();
    }

    public void HoverEnd()
    {
        animation.Stop();
        animation.clip = animation.GetClip("HideHighlight");
        animation.Play();
    }

    private void PickUpItem()
    {
        var emptyInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().FirstOrDefault(x => x.GetItem() == null);
        if (emptyInventorySlot == null) 
        {
            //niaky efekt ze nemame miesto
            return;
        }
        emptyInventorySlot.SetItem(Item);
    }
}

