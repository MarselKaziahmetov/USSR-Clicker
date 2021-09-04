using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivitiesUpgrader : MonoBehaviour
{
    [SerializeField] private Text costOfUpgradeLabel;
    [SerializeField] private Text levelOfUpgradeLabel;

    [SerializeField] private double difficultyFactor = 1.5;
    [SerializeField] private double costOfUpgrade = 5;
    [SerializeField] private int levelOfUpgrade = 0;

    public void Upgrade()
    {
        LevelIncrement();
        CostIncrease();
    }

    private void LevelIncrement()
    {
        levelOfUpgrade++;

        levelOfUpgradeLabel.text = levelOfUpgrade + "/100";
    }

    private void CostIncrease()
    {
        costOfUpgrade *= 2.3;

        costOfUpgradeLabel.text = costOfUpgrade.ToString();
    }
}
