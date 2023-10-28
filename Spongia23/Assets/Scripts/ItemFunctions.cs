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
            var topanky = itemCollection.Items.First(x => x.Type == ItemType.Topanky);
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
        }
    }

    public void UseCauldron(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Topanky)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var peniaze = itemCollection.Items.First(x => x.Type == ItemType.Peniaze);
            //insane animacia pre cauldron
            ReplaceItemInInventory(selectedInventorySlot, peniaze);
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
