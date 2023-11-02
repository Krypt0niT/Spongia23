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
            buttonInteraction.ButtonType = ButtonType.Portal;
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
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var peniaze = itemCollection.Items.First(x => x.Type == ItemType.Peniaze);
            //insane animacia pre cauldron
            ReplaceItemInInventory(selectedInventorySlot, peniaze);
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
            //insane animacia pre trade
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
            //insane animacia pre trade
            ReplaceItemInInventory(selectedInventorySlot, peniaze);
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
            buttonInteraction.transform.parent.GetComponent<ChangeTexture>().Change();
            buttonInteraction.transform.parent.GetComponent<GameObjectChange>().Change();
        }
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

        animation.clip = animation.GetClip("AbawuwuWheel");
        animation.Play();
        inventorySlot.RemoveItem();
        yield return new WaitForSeconds(6.4f);
        ReplaceItemInInventory(inventorySlot, item);
        inventorySlot.SetItem(item);
        inventorySlot.SetInactive();
    }
}
