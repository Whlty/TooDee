using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damage, critChance, maxHealth;
    [SerializeField] private PlayerManager playerManager;

    private void Start()
    {
        UpdateUI(playerManager.statsManager);
    }
    public void UpdateUI(StatsManager stats)
    {
        Debug.Log(stats);

        damage.text = "DAMAGE: " + stats.damage.GetValue().ToString("F6");
        critChance.text = "CRITCHANCE: " + stats.critChance.GetValue().ToString("F6");
        maxHealth.text = "MAXHEALTH: " + stats.maxHealth.GetValue().ToString("F6");
    }
}
