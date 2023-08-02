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
    [SerializeField] private GameObject cursor;
    private KeyCode toggleInventory;
    public GameObject hand;
    private bool inventoryEnabled;
    private GameObject[] slots;
    private SlotClass[] items;
    private Transform currentPosition, endPosition;
    private SlotClass selectedSlot;

    private void Start()
    {
        inventoryEnabled = true;
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

        selectedSlot = null;
        cursor.SetActive(false);

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
        if (!inventoryEnabled)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelectSlot();
        }
    }

    private void SelectSlot()
    {
        selectedSlot = GetClosestSlot();

        if (GetClosestSlot() == null)
        {
            DeselectSlot();
            return;
        }
        if (GetClosestSlot().GetItem() == null)
        {
            DeselectSlot();
            return;
        }

        cursor.transform.position = GetClosestSlotPos().transform.position;
        cursor.SetActive(true);
    }

    private void DeselectSlot()
    {
        cursor.SetActive(false);
        selectedSlot = null;
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



}
