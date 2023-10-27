using System.Linq;
using UnityEngine;

public class ItemFunctions : MonoBehaviour
{
    public static void UseAbawuwuWheel(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.MinceDoKolesa)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var topanky = itemCollection.Items.First(x => x.Type == ItemType.Topanky);
            //spin animation
            ReplaceItemInInventory(selectedInventorySlot, topanky);
        }
        if (item.Type == ItemType.Hubka)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var pokeball = itemCollection.Items.First(x => x.Type == ItemType.Pokeball);
            //spin animation
            ReplaceItemInInventory(selectedInventorySlot, pokeball);
        }
    }

    public static void UsePortal(ButtonInteraction buttonInteraction)
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

    private static void ReplaceItemInInventory(InventorySlot inventorySlot, Item item)
    {
        inventorySlot.RemoveItem();
        inventorySlot.SetItem(item);
        inventorySlot.SetInactive();
    }
}
