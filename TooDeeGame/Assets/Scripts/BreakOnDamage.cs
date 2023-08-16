using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnDamage : MonoBehaviour, IDamagable
{
    public float TakeDamage(float amount, GameObject attacker)
    {
        Debug.Log("hit");
        Destroy(this.gameObject);
        return 0;
    }
}
