using System.Collections;
using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName ="item/melee")]
public class MeleeClass : ItemClass
{
    public float damage;
    public override void Use(PlayerManager caller)
    {
        Debug.Log("use melee");

    }

    public override string GetDescription()
    {
        StringBuilder sb = new();
        sb.Append(itemDesc);
        sb.Append("\n");
        if (damage != 0)
        {
            sb.Append("\n");
            sb.Append("Damage: ");
            sb.Append(damage);
        }
        if (cooldown != 0)
        {
            sb.Append("\n");
            sb.Append("Cooldown: ");
            sb.Append(cooldown);
        }

        return sb.ToString();
    }
    public override ItemClass GetItem() { return null; }
    public override MeleeClass GetMelee() { return this; }
    

}
