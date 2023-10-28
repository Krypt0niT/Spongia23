using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool Selected;

    [SerializeField] private Item item = null;

    private GameObject image;
    private Canvas canvas;

    private void Start()
    {
        image = transform.GetChild(0).gameObject;
        canvas = transform.parent.GetComponent<Canvas>();
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
        
        if (!Selected)
        {
            var selectedSlot = inventorySlots.FirstOrDefault(x => x.Selected);
            if (selectedSlot != null && item == null)
            {
                SetItem(selectedSlot.GetItem());
                selectedSlot.RemoveItem();
                SetInactive(selectedSlot);
                SetInactive();
            }
            else
            {
                if (item != null)
                {
                    SetActiveSelf();
                }
            }
        }
        else SetInactive();
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
        ResetImagePosition(image);
    }

    private void SetInactive(InventorySlot inventorySlot)
    {
        inventorySlot.Selected = false;
        inventorySlot.GetComponent<Image>().color = new Color32(36, 36, 36, 255);
        ResetImagePosition(inventorySlot.transform.GetChild(0).gameObject);
    }

    private void SetActiveSelf()
    {
        var inventorySlots = GameObject.FindObjectsOfType<InventorySlot>();

        foreach (var inventorySlot in inventorySlots)
        {
            SetInactive(inventorySlot);
            inventorySlot.canvas.sortingOrder = -1;
        }
        this.Selected = true;
        canvas.sortingOrder = 0;
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

    private void ResetImagePosition(GameObject image)
    {
        image.transform.localPosition = new Vector3(0, 0, 0);
    }
}
