using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // public so I don't have to iterate through a list every itemUpdate
    public Stat damage;
    public Stat critChance;
    public Stat maxHealth;
    [SerializeField] private PlayerManager playerManager;

    public void ChangeItem(ItemClass _item, ItemClass oldItem)
    {
        // fail safe
        if (_item != null)
        {
            damage.AddModifier(_item.damage);
            critChance.AddModifier(_item.critChance);
        }

        if (oldItem != null)
        {
            if (oldItem != null)
            {
                damage.RemoveModifier(oldItem.damage);
                critChance.RemoveModifier(oldItem.critChance);
            }
        }

        // comment out when not using
        playerManager.debugMenu.UpdateUI(this); 
    }


}
