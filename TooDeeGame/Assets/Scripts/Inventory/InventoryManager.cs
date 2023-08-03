using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject open, close, orientation;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass[] startingItems;
    [SerializeField] private GameObject cursor, hover;
    [SerializeField] private TextMeshProUGUI hoverName, hoverDesc;
    [SerializeField] private KeyCode toggleInventory;
    [SerializeField] private GameObject equipButton, sellButton;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject mainItem;
    public GameObject hand;
    private bool inventoryEnabled;
    private GameObject[] slots;
    private SlotClass[] items;
    private Transform endPosition;
    private SlotClass selectedSlot;

    private void Start()
    {
        inventoryEnabled = false;
        // currentPosition = orientation.transform;
        // endPosition = close.transform;

        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
            items[i] = new SlotClass();
        }

        for (int i = 0; i < startingItems.Length; i++)
        {
            AddItem(startingItems[i]);   
        }

        endPosition = close.transform;
        DeselectSlot();

        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (items[i].GetItem() != null)
            {
                slots[i].SetActive(true);
                slots[i].GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
            }
            else
            {
                slots[i].SetActive(false);
                slots[i].GetComponent<Image>().sprite = null;
            }
            
        }

    }

    public bool AddItem(ItemClass _item)
    {
        if (IsInventoryFull())
        {
            return false;
        }

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == null)
            {
                items[i].ChangeItem(_item);
                break;
            }
            
        }

        UpdateUI();
        return true;
    }

    private bool IsInventoryFull()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == null)
                return false;
        }

        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleInventory))
            ToggleInventory();

        if (orientation.transform != endPosition.transform)
            MoveInventory();


        if (!inventoryEnabled)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelectSlot();
        }

        if (selectedSlot == null)
        {
            UpdateDisplay(GetClosestSlot());
        }
    }

    private void MoveInventory()
    {
        orientation.transform.position = Vector2.Lerp(orientation.transform.position, endPosition.position, Time.deltaTime * 10);
    }

    public void ToggleInventory()
    {
        inventoryEnabled = !inventoryEnabled;
        if (inventoryEnabled)
        {
            endPosition = open.transform;
        }
        else
        {
            DeselectSlot();
            endPosition = close.transform;
        }
    }

    private void UpdateDisplay(SlotClass slot = null)
    {
        if (slot == null)
        {
            hover.SetActive(false);
            return;
        }

        if (slot.GetItem() == null)
        {
            hover.SetActive(false);
        }
        else
        {
            hover.SetActive(true);
            hoverName.text = slot.GetItem().itemName;
            hoverDesc.text = slot.GetItem().GetDescription();
        }


    }

    private void SelectSlot()
    {
        SlotClass closest = GetClosestSlot();

        if (closest == null)
        {
            return;
        }
        else if (closest.GetItem() == null)
        {
            return;
        }

        selectedSlot = closest;
        UpdateDisplay(selectedSlot);
        cursor.transform.position = GetClosestSlotPos().transform.position;
        cursor.SetActive(true);
        equipButton.SetActive(true);
        sellButton.SetActive(true);
    }

    private void DeselectSlot()
    {
        equipButton.SetActive(false);
        sellButton.SetActive(false);
        cursor.SetActive(false);
        selectedSlot = null;
        hover.SetActive(false);
    }

    private SlotClass GetClosestSlot()
    {
        SlotClass curItem = items[0];
        float closestSlot = Vector2.Distance(slots[0].transform.position, Input.mousePosition);

        for (int i = 1; i < slots.Length - 1; i++)
        {
            float dist = Vector2.Distance(slots[i].transform.position, Input.mousePosition);
            if (dist < closestSlot)
            {
                closestSlot = dist;
                curItem = items[i];
            }
            
        }

        if (closestSlot > 100)
        {
            return null;
        }

        return curItem;
    }
    private GameObject GetClosestSlotPos()
    {
        GameObject curSlot = slots[0];
        float closestSlot = Vector2.Distance(slots[0].transform.position, Input.mousePosition);

        for (int i = 1; i < slots.Length - 1; i++)
        {
            float dist = Vector2.Distance(slots[i].transform.position, Input.mousePosition);
            if (dist < closestSlot)
            {
                closestSlot = dist;
                curSlot = slots[i];
            }
            
        }

        if (closestSlot > 100)
        {
            return null;
        }

        return curSlot;
    }

    public void SellItem(SlotClass _item)
    {
        if (_item == null)
            return;
            
        // give coins
        _item.Clear();
        DeselectSlot();
        UpdateUI();
    }
    public void EquipItem(SlotClass _item)
    {
        if (_item == null)
            return;

        ItemClass returnItem = mainItem.gameObject.GetComponent<ActiveSlot>().ChangeItem(_item.GetItem());
        if (returnItem == null)
        {
            _item.Clear();
        }
        else
        {
            _item.ChangeItem(returnItem);
        }
        DeselectSlot();
        UpdateUI();
    }

    public void SellSelectedItem()
    {
        SellItem(selectedSlot);
    }

    public void EquipSelectedItem()
    {
        EquipItem(selectedSlot);
    }





}
