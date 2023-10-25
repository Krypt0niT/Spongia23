using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool Selected;

    [SerializeField] private Item item = null;

    private void Start()
    {
        ChangeIcon();
    }

    public void SelectInventorySlot()
    {
        var inventorySlots = GameObject.FindObjectsOfType<InventorySlot>();
        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.Selected = false;
            inventorySlot.GetComponent<Image>().color = new Color32(36, 36, 36, 255);
        }
        this.Selected = true;
        GetComponent<Image>().color = Color.black;
    }

    public void RemoveItem()
    {
        this.item = null;
        ChangeIcon();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        ChangeIcon();
    }

    public Item GetItem() 
    {
        return this.item;
    }

    private void ChangeIcon()
    {
        var image = transform.GetChild(0).gameObject.GetComponent<Image>();

        if (item != null)
        {
            image.sprite = item.GetComponent<Image>().sprite;
            image.color = new Color(1, 1, 1, 1);
        }
        else
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0);
        }
    }
}
