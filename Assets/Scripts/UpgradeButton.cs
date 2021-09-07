using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private float upgradeCost;
    [SerializeField] private int upgradeLevel;
    [SerializeField] private Text upgradeCostLabel;
    [SerializeField] private Text upgradeLevelLabel;
    [SerializeField] private IncrementWithClick prototype;

    public void Upgrade()
    {
        prototype.Instance.Upgrade(ref upgradeCost, ref upgradeLevel, upgradeCostLabel, upgradeLevelLabel);
    }
}
