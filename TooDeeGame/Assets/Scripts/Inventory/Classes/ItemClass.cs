using System.Collections;
using UnityEngine;
using System.Text;
[CreateAssetMenu(menuName ="item/item")]
public class ItemClass : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;

    public virtual void Use(PlayerManager caller)
    {
        Debug.Log("Used item");
    }

    public virtual string GetDescription()
    {
        StringBuilder sb = new();
        sb.Append(itemDesc);
        return sb.ToString();
    }

    public virtual ItemClass GetItem() { return this; }
    public virtual MeleeClass GetMelee() { return null; }
    

}
