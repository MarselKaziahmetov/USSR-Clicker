using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementWithClick : MonoBehaviour
{
    public IncrementWithClick Instance { get; private set; }

    [SerializeField] public int currentMoney = 0;
    [SerializeField] public int incrementCount = 1;
    [SerializeField] public Text moneyText;
    [SerializeField] public Text moneyReward;

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

   /* public int CurrentMoney
    {
        get
        {
            return PlayerPrefs.GetInt("Money", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Money", value);
        }
    }

    public int IncrementCount
    {
        get
        {
            return incrementCount;
        }
        set
        {
            incrementCount = value;
        }
    }*/

    public void ScoreIncrementation()
    {
        currentMoney += incrementCount;

        moneyText.text = currentMoney.ToString();
    }

    public void Upgrade(ref int upgradeCost, ref int upgradeLevel, Text upgradeCostLabel, Text upgradeLevelLabel)
    {
        if (currentMoney >= upgradeCost)
        {
            incrementCount++;
            currentMoney -= upgradeCost;
            
            upgradeCost *= 2;
            upgradeLevel++;

            upgradeCostLabel.text = upgradeCost.ToString();
            upgradeLevelLabel.text = upgradeLevel + "/100";
        }
    }
}
