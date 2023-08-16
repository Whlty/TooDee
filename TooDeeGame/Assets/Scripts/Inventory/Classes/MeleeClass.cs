using System.Collections;
using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName ="item/melee")]
public class MeleeClass : ItemClass
{

    public AttackAnimation attack;
    public enum AttackAnimation
    {
        swing, spin, poke, boomarang, hammerdown, wtf 
    }

    public override void Use(PlayerManager caller)
    {
        Animator anim = caller.playerHand.GetComponent<Animator>();
        anim.speed = 1f / cooldown; 
        anim.Play(attack.ToString(), -1);
    }
    public override ItemClass GetItem() { return null; }
    public override MeleeClass GetMelee() { return this; }
    

}
