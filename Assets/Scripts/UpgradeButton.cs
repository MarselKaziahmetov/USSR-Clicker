using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private int upgradeCost = 5;
    [SerializeField] private int upgradeLevel = 0;
    [SerializeField] private Text upgradeCostLabel;
    [SerializeField] private Text upgradeLevelLabel;
    [SerializeField] private IncrementWithClick prototype;

    public void OnClick()
    {
        prototype.Instance.Upgrade(ref upgradeCost, ref upgradeLevel, upgradeCostLabel, upgradeLevelLabel);
        prototype.Instance.moneyText.text = prototype.Instance.currentMoney.ToString();
        prototype.Instance.moneyReward.text = prototype.Instance.incrementCount.ToString();
    }
}
