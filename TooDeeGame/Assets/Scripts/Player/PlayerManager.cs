using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Easy way for player scripts to interact with each other, and easy to track.
public class PlayerManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public MoneyManager moneyManager;
    public PlayerMovement playerMovement;
    public StatsManager statsManager;
    public DebugMenu debugMenu;
    public TitleManager titleManager;
    public PlayerHand playerHand;
    public PrimaryAttack primaryAttack;

    // event system
    public event Action TakeDamage;
    public event Action PrimaryAttack;
    public event Action UseSpell;
    public event Action HitTarget;

    public void OnTakeDamage() { TakeDamage?.Invoke(); }
    public void OnPrimaryAttack() { PrimaryAttack?.Invoke(); }
    public void OnUseSpell() { UseSpell?.Invoke(); }
    public void OnHitTarget(GameObject target) { HitTarget?.Invoke(); }

}
