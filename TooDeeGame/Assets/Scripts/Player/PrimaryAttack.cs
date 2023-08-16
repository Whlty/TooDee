using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private List<GameObject> hit = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IDamagable>() == null)
            return;
        else if (hit.Contains(other.gameObject))
            return;

        hit.Add(other.gameObject);
        float damage = playerManager.statsManager.damage.GetValue();
        other.GetComponent<IDamagable>().TakeDamage(damage, playerManager.gameObject);
        playerManager.OnHitTarget(other.gameObject);

        Debug.Log("hit " + other.gameObject);

    }


}
