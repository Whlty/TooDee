using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemClass item;

    public SlotClass()
    {
        item = null;
    }

    public SlotClass(ItemClass _item)
    {
        item = _item;
    }
    public SlotClass(SlotClass slot)
    {
        item = slot.item;
    }

    public void Clear()
    {
        this.item = null;
    }

    public ItemClass GetItem()
    {
        return item ?? default;
    }
    public void ChangeItem(ItemClass _item)
    {
        this.item = _item;
    }

}
