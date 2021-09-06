using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementWithClick : MonoBehaviour
{
    public IncrementWithClick Instance { get; private set; }

    [SerializeField] public int incrementCount = 1;
    [SerializeField] private int incrementIncrease = 1;

    [SerializeField] public Text globalMoneyText;
    [SerializeField] public Text moneyReward;
    [SerializeField] public Text timerText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);
    }

    public void MoneyAddition()
    {
        Bank.currentMoney += incrementCount;

        globalMoneyText.text = Bank.currentMoney.ToString();
    }

    public void Upgrade(ref int upgradeCost, ref int upgradeLevel, Text upgradeCostLabel, Text upgradeLevelLabel)
    {
        if (Bank.currentMoney >= upgradeCost)
        {
            incrementCount += incrementIncrease;
            Bank.currentMoney -= upgradeCost;
            
            upgradeCost *= 2;
            upgradeLevel++;

            upgradeCostLabel.text = upgradeCost.ToString();
            upgradeLevelLabel.text = upgradeLevel + "/100";

            moneyReward.text = incrementCount.ToString();
        }
    }
}
