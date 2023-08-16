using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private float totalMoney;
    [SerializeField] private float multiplierPercent = 100f, validPercent;
    [SerializeField] private TextMeshProUGUI moneyText;

    public void Start()
    {
        MultiplierCheck();
        UpdateText();
    }

    // prevent multiplier being negetive
    private void MultiplierCheck()
    {
        if (multiplierPercent <= 0)
        {
            validPercent = 0;
        }
        else
        {
            validPercent = multiplierPercent;
        }
    }
    public void GainMoney(float amount)
    {
        if (amount <= 0)
            return;

        MultiplierCheck();
        totalMoney += amount * (validPercent / 100f);
        UpdateText();
    }
    public bool SpendMoney(float amount)
    {
        if ((totalMoney - amount) >= 0)
        {
            totalMoney -= amount;
            UpdateText();
            return true;
        }

        return false;
    }
    public void RemoveMoney(float amount)
    {
        totalMoney -= amount;
        if (totalMoney <= 0)
        {
            totalMoney = 0;
        }
        UpdateText();
    }
    private void UpdateText()
    {
        moneyText.text = "$" + totalMoney.ToString("F0");
    }

    // can use if removing or gaining a percentage of money
    public float MoneyTotal()
    {
        return totalMoney;
    }

    public void ChangeMultiplier(float percentage)
    {
        multiplierPercent += percentage;

        // fail safe
        MultiplierCheck();

    }
    
}
