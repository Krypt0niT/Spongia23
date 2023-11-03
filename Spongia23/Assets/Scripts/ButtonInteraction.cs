using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteraction : MonoBehaviour
{
    public bool SmoothTransition;
    public BackgroundIdentifier BackgroundIdentifier;
    public string SceneName;
    public Item Item;
    public bool HasMonolog;
    public ButtonType ButtonType;

    private Animation animation;
    private ItemFunctions itemFunctions;
    private Monolog monolog;

    private void Start()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,0);
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        itemFunctions = GameObject.FindObjectOfType<ItemFunctions>();
        animation = GetComponent<Animation>();

        if (HasMonolog)
        {
            var monologGameObject = transform.parent.Find("Monolog").gameObject;
            monolog = monologGameObject.GetComponent<Monolog>();
            monologGameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
        }
    }

    public void Interact()
    {
        if (HasMonolog)
        {
            if (!FindObjectsOfType<InventorySlot>().Any(x => x.Selected))
            {
                monolog.Play();
            }
        }

        if (ButtonType == ButtonType.Travel)
        {
            if (!FindObjectsOfType<InventorySlot>().Any(x => x.Selected))
                BackgroundIdentifier.MoveCameraToBackground(SmoothTransition);
        }

        if (ButtonType == ButtonType.Monolog) 
        {
            print("monolog");
        }

        if (ButtonType == ButtonType.Portal)
        {
            SceneManager.LoadScene(SceneName);
        }

        if (ButtonType == ButtonType.ItemFunction)
        {
            if (transform.parent.name == "AbawuwuWheel")
            {
                itemFunctions.UseAbawuwuWheel(this);
            }
            if (transform.parent.name == "Portal")
            {
                itemFunctions.UsePortal(this);
            }
            if (transform.parent.name == "Kotol")
            {
                itemFunctions.UseCauldron(this);
            }
            if (transform.parent.name == "Bowser")
            {
                itemFunctions.KillBowser(this);
            }
            if (transform.parent.name == "Pes")
            {
                itemFunctions.UseDog(this);
            }
            if (transform.parent.name == "Villager1")
            {
                itemFunctions.UseVillager1(this);
            }
            if (transform.parent.name == "Villager2")
            {
                itemFunctions.UseVillager2(this);
            }
            if (transform.parent.name == "Snorlax")
            {
                itemFunctions.UseSnorlax(this);
            }
            if (transform.parent.name == "DeadSnorlax")
            {
                itemFunctions.UseDeadSnorlax(this);
            }
            if (transform.parent.name == "Toad")
            {
                itemFunctions.UseToad(this);
            }
            print("use item");
        }

        if (ButtonType == ButtonType.PickUp)
        {
            PickUpItem();
        }

        if (ButtonType == ButtonType.ChangeGameObject)
        {
            GetComponent<GameObjectChange>().Change();
        }

        if (ButtonType == ButtonType.ConversationAndItem)
        {
            // do dialog
            var selectedItem = GameObject.FindObjectsOfType<InventorySlot>().FirstOrDefault(x => x.Selected);
            if (selectedItem == null) return;
            if (selectedItem.GetItem().Type == ItemType.Peniaze)
            {
                GetComponent<GameObjectChange>().Change();
                selectedItem.RemoveItem();
            }
        }
    }  
    
    public void HoverStart()
    {
        if (animation.IsPlaying("HideHighlight"))
            animation.PlayQueued("ShowHighlight");
        else
        {
            animation.Play("ShowHighlight");

        }
    }

    public void HoverEnd()
    {
        if (animation.IsPlaying("ShowHighlight"))
            animation.PlayQueued("HideHighlight");
        else
        {
            animation.Play("HideHighlight");

        }
    }

    public void PickUpItem()
    {
        var emptyInventorySlot = GameObject.FindObjectsOfType<InventorySlot>()
            .OrderBy(x => x.gameObject.name)
            .FirstOrDefault(x => x.GetItem() == null);

        if (emptyInventorySlot == null) 
        {
            //niaky efekt ze nemame miesto
            return;
        }
        emptyInventorySlot.SetItem(Item);
        GameObject.Destroy(this.gameObject.transform.parent.gameObject);
    }
}

