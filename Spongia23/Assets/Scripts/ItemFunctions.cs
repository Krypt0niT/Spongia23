using System.Linq;
using UnityEngine;

public class ItemFunctions : MonoBehaviour
{
    public static void UseAbawuwuWheel(ButtonInteraction buttonInteraction)
    {
        var selectedInventorySlot = GameObject.FindObjectsOfType<InventorySlot>().Where(x => x.Selected).FirstOrDefault();
        if (selectedInventorySlot == null) return;

        var item = selectedInventorySlot.GetItem();
        if (item.Type == ItemType.Hubka)
        {
            var itemCollection = GameObject.FindObjectOfType<ItemCollection>();
            var topanky = itemCollection.Items.First(x => x.Type == ItemType.Topanky);
            //spin animation
            selectedInventorySlot.RemoveItem();
            selectedInventorySlot.SetItem(topanky);
            selectedInventorySlot.SetInactive();
        }

    }
}
