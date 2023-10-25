using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class InventorySlot : MonoBehaviour
{
    public bool Selected;

    [SerializeField] private Item item = null;

    private GameObject image;

    private void Start()
    {
        image = transform.GetChild(0).gameObject;
        ChangeIcon();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) 
        {
            SetInactive(this);
        }
        if (Selected)
        {
            image.transform.position = Input.mousePosition;
        }
    }

    public void SelectInventorySlot()
    {
        var inventorySlots = GameObject.FindObjectsOfType<InventorySlot>();
        foreach (var inventorySlot in inventorySlots)
        {
            SetInactive(inventorySlot);

        }
        SetActiveSelf();
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

    public void SetInactive()
    {
        Selected = false;
        GetComponent<Image>().color = new Color32(36, 36, 36, 255);
        image.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void SetInactive(InventorySlot inventorySlot)
    {
        inventorySlot.Selected = false;
        inventorySlot.GetComponent<Image>().color = new Color32(36, 36, 36, 255);
        image.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void SetActiveSelf()
    {
        this.Selected = true;
        GetComponent<Image>().color = Color.black;
    }

    private void ChangeIcon()
    {
        if (image == null) return;
        var imageComponent = this.image.GetComponent<Image>();
        if (item != null)
        {
            imageComponent.sprite = item.GetComponent<Image>().sprite;
            imageComponent.color = new Color(1, 1, 1, 1);
        }
        else
        {
            imageComponent.sprite = null;
            imageComponent.color = new Color(1, 1, 1, 0);
        }
    }
}
