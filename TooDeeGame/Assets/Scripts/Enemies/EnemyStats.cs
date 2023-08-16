using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy/BasicStats")]
public class EnemyStats : ScriptableObject
{
    public string EnemyName;
    public int level;
    public float maxHealth, defense, speed, damage, attackDelay;
    public float onDeathXp, onDeathCoins, coinRange, xpRange;
    public float aggroRange, viewRange, attackRange;
}
