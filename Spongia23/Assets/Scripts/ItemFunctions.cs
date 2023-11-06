using System.Collections;
using System.Linq;
using UnityEngine;

public class ItemFunctions : MonoBehaviour
{
    public void UseAbawuwuWheel(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.MinceDoKolesa)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var topanky = itemCollection.Items.First(x => x.Type == ItemType.Rukavice);
            StartCoroutine(SpinWheel(
                buttonInteraction.transform.parent.gameObject,
                selectedInventorySlot,
                topanky
                ));
        }
        if (item.Type == ItemType.Hubka)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var topanky = itemCollection.Items.First(x => x.Type == ItemType.Pokeball);
            StartCoroutine(SpinWheel(
                buttonInteraction.transform.parent.gameObject,
                selectedInventorySlot,
                topanky
                ));
        }
    }

    public void UsePortal(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Zapalovac)
        {
            //insane animation
            var buttonParent = buttonInteraction.transform.parent;
            buttonParent.GetComponent<ChangeTexture>().Change();
            buttonParent.transform.parent.Find("Platform").GetComponent<ChangeTexture>().Change();
            buttonParent.GetComponents<AudioSource>().Last().Play();
            buttonInteraction.ButtonType = ButtonType.Portal;
            buttonParent.transform.parent.GetComponentInChildren<EffectMaintainer>().GetComponent<ParticleSystem>().Play();
            buttonParent.transform.parent.GetComponentInChildren<EffectMaintainer>().Available = true;
        }
    }

    public void UseCauldron(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Rukavice)
        {
            var soundEffect = buttonInteraction.transform.parent.GetComponents<AudioSource>().First();
            soundEffect.Play();
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var peniaze = itemCollection.Items.First(x => x.Type == ItemType.Peniaze);
            GameObject.Find("boom").gameObject.GetComponent<ParticleSystem>().Play();
            ReplaceItemInInventory(selectedInventorySlot, peniaze);
        }
    }

    public void UseToad(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Diamant)
        {
            buttonInteraction.transform.parent.GetComponent<GameObjectChange>().Change();
            buttonInteraction.transform.parent.Find("Lock").gameObject.GetComponent<ChangeTexture>().Change();
            buttonInteraction.transform.parent.GetComponent<ChangeTexture>().Change();
            buttonInteraction.HasMonolog = false;
            buttonInteraction.transform.parent.Find("Monolog").gameObject.SetActive(false);
            selectedInventorySlot.RemoveItem();
        }
    }

    public void UseVillager1(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Zapalovac)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var emerald = itemCollection.Items.First(x => x.Type == ItemType.Emerald);
            GameObject.Find("BGS").gameObject.active = false;
            GameObject.Find("tradeparticle1").gameObject.GetComponent<ParticleSystem>().Play();
            ReplaceItemInInventory(selectedInventorySlot, emerald);
        }
    }

    public void UseVillager2(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Emerald)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var peniaze = itemCollection.Items.First(x => x.Type == ItemType.Mec);
            GameObject.Find("tradeparticle2").gameObject.GetComponent<ParticleSystem>().Play();
            ReplaceItemInInventory(selectedInventorySlot, peniaze);
        }
    }

    public void UseSnorlax(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Dog)
        {
            buttonInteraction.GetComponent<GameObjectChange>().GameObject.GetComponent<AudioSource>().Play();
            //insane animacia pre yneskodnenie
            buttonInteraction.GetComponent<GameObjectChange>().Change();
        }
    }

    public void UseDeadSnorlax(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Pokeball)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var peniaze = itemCollection.Items.First(x => x.Type == ItemType.PlnyPokeball);
            //insane animacia pre chytenie
            ReplaceItemInInventory(selectedInventorySlot, peniaze);
            Destroy(buttonInteraction.transform.parent.gameObject);
        }
    }

    public void UseDog(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Kost)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var dog = itemCollection.Items.First(x => x.Type == ItemType.Dog);

            GameObject.Find("Pes").gameObject.SetActive(false);
            GameObject.Find("BGD").gameObject.SetActive(false);
            GameObject.Find("heart").gameObject.GetComponent<ParticleSystem>().Play();
            //insane animacia pre ochocenie psa
            ReplaceItemInInventory(selectedInventorySlot, dog);
        }
    }

    public void KillBowser(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().FirstOrDefault(x => x.Selected);
        if (selectedInventorySlot == null)
        {
            return;
        }
        if (selectedInventorySlot.GetItem().Type == ItemType.Mec)
        {
            var changeComponents = buttonInteraction.transform.parent.GetComponents<GameObjectChange>();
            foreach (var component in changeComponents)
            {
                component.Change();
            }
            buttonInteraction.transform.parent.parent.Find("BowserDead").GetComponent<AudioSource>().Play();
            buttonInteraction.transform.parent.gameObject.SetActive(false); 
        }
    }

    public void UseWitch(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().FirstOrDefault(x => x.Selected);
        if (selectedInventorySlot == null)
        {
            return;
        }
        if (selectedInventorySlot.GetItem().Type == ItemType.PlnyPokeball)
        {
            var spongia = GameObject.Find("Špongia");

            spongia.GetComponent<SpongiaEnd>().Play();
        }
    }

    public void TakeLuckyBlock(ButtonInteraction buttonInteraction)
    {
        
        var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
        var item = itemCollection.Items.First(x => x.Type == ItemType.Hubka);
        //insane animacia pre ochocenie psa
        var emptyInventorySlot = GameObject.FindObjectsOfType<InventorySlot>()
            .OrderBy(x => x.gameObject.name)
            .First(x => x.GetItem() == null);

        emptyInventorySlot.SetItem(item);
        buttonInteraction.transform.GetComponentInParent<SpriteAnimator>().enabled = false;
        buttonInteraction.gameObject.SetActive(false); 
        GameObject.Find("luckyblockaudio").gameObject.GetComponent<AudioSource>().Play();
        buttonInteraction.transform.parent.GetComponent<ChangeTexture>().Change();
    }

    private void ReplaceItemInInventory(InventorySlot inventorySlot, Item item)
    {
        inventorySlot.RemoveItem();
        inventorySlot.SetItem(item);
        inventorySlot.SetInactive();
    }

    private IEnumerator SpinWheel(GameObject wheel, InventorySlot inventorySlot, Item item)
    {
        var animation = wheel.GetComponent<Animation>();
        var audioSources = wheel.GetComponents<AudioSource>();
        var backButton = GameObject.Find("abawuwuInside").transform.Find("back").gameObject;

        audioSources.Last().Stop();
        audioSources.First().Play();
        animation.clip = animation.GetClip("AbawuwuWheel");
        animation.Play();
        inventorySlot.RemoveItem();
        backButton.SetActive(false);

        yield return new WaitForSeconds(6.4f);
        
        backButton.SetActive(true);

        var emptyInventorySlot = GameObject.FindObjectsOfType<InventorySlot>()
            .OrderBy(x => x.gameObject.name)
            .First(x => x.GetItem() == null);

        emptyInventorySlot.SetItem(item);
        emptyInventorySlot.SetInactive();
    }
}
