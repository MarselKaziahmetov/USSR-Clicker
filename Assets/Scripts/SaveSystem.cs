using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] public Text globalMoneyText;
    [SerializeField] public Text moneyReward;
    [SerializeField] private Text upgradeCostLabel;
    [SerializeField] private Text upgradeLevelLabel;
    [SerializeField] private IncrementWithClick prototype;

    private void Awake()
    {
        LoadData();
        prototype.ActivitiesInteractebleCheck();
    }

    private void LoadData()
    {
        globalMoneyText.text = Bank.currentMoney.ToString();
        moneyReward.text = prototype.IncrementValue.ToString();
        upgradeCostLabel.text = prototype.UpgradeCost.ToString();
        upgradeLevelLabel.text = prototype.UpgradeLevel + "/100";
    }
}
