using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ButtonInteraction : MonoBehaviour
{
    public bool SmoothTransition;
    public BackgroundIdentifier BackgroundIdentifier;
    public string SceneName;
    public Item Item;
    public bool HasMonolog;
    public ButtonType ButtonType;
    public GameObject[] toLoad;
    public GameObject[] toUnload;
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
            if (SceneManager.GetActiveScene().name == "Minecraft") 
            {
                foreach (var item in toLoad) if (!item.GetComponentInChildren<VideoPlayer>().isPlaying) item.GetComponentInChildren<VideoPlayer>().Play();
                foreach (var item in toUnload) item.GetComponentInChildren<VideoPlayer>().Stop();
            }
            TravelSpecialCases();
        }

        if (ButtonType == ButtonType.Monolog) 
        {
            print("monolog");
        }

        if (ButtonType == ButtonType.Portal)
        {
            if (transform.parent.name == "Portal")
            {
                //minecraft
                GameObject.Find("PortalSoundPlayer").GetComponents<AudioSource>().First().Play() ;
            }
            if (transform.parent.name == "Ovca")
            {
                //minecraft
                GameObject.Find("PortalSoundPlayer").GetComponents<AudioSource>().Last().Play();
            }
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
            if (transform.parent.name == "Witch")
            {
                itemFunctions.UseWitch(this);
            }
            print("use item");
        }

        if (ButtonType == ButtonType.PickUp)
        {
            PickUpItem();
        }

        if (ButtonType == ButtonType.ChangeGameObject)
        {
            var gameChangeComponent = GetComponent<GameObjectChange>();
            var audioSource = gameChangeComponent.GameObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            gameChangeComponent.Change();
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
                transform.parent.GetComponent<AudioSource>().Play();
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

    private void TravelSpecialCases()
    {
        if (transform.parent.name == "AbawuwuVan") 
        {
            var wheel = GameObject.Find("AbawuwuWheel").gameObject;
            wheel.GetComponents<AudioSource>().Last().Play();
            var wheelAnimation = wheel.GetComponent<Animation>();
            wheelAnimation.clip = wheelAnimation.GetClip("AbawuwuWheelIdle");
            wheelAnimation.Play();
        }
        if (transform.parent.name == "abawuwuInside")
        {
            var wheel = GameObject.Find("AbawuwuWheel").gameObject;
            wheel.GetComponents<AudioSource>().Last().Stop();
        }

        if (transform.parent.name == "CaroobchodImage")
        {
            var kotol = GameObject.Find("Kotol").gameObject;
            kotol.GetComponents<AudioSource>().Last().Play();
        }
        if (transform.parent.name == "Carodejnica")
        {
            var kotol = GameObject.Find("Kotol").gameObject;
            kotol.GetComponents<AudioSource>().Last().Stop();
        }
        
        if (gameObject.name == "LeftButton" && transform.parent.name == "studna")
        {
            var portal = GameObject.Find("Portal").gameObject;
            if (GameObject.Find("portalglow").GetComponent<EffectMaintainer>().Available)
            {
                portal.GetComponents<AudioSource>().Last().Play();
            }
        }
        if (gameObject.name == "RightButton" && transform.parent.name == "PortalBg")
        {
            var portal = GameObject.Find("Portal").gameObject;
            portal.GetComponents<AudioSource>().Last().Stop();
        }
    }
}

