using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementWithClick : MonoBehaviour
{
    public IncrementWithClick Instance { get; private set; }

    [SerializeField] public float incrementCount;
    [SerializeField] private float incrementIncrease;
    [SerializeField] private float timeToDo;
    [SerializeField] private float difficultMultiple;

    [SerializeField] private Text globalMoneyText;
    [SerializeField] private Text moneyReward;
    [SerializeField] private Text timerText;

    [SerializeField] private Button incrementButton;

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

    //����� ��� ������� OnClick
    public void IncrementationButton()
    {
        StartCoroutine("MoneyAdditionWithTimer");
    }

    public void MoneyAddition()
    {
        Bank.currentMoney += incrementCount;

        globalMoneyText.text = Bank.currentMoney.ToString();
    }

    public void Upgrade(ref float upgradeCost, ref int upgradeLevel, Text upgradeCostLabel, Text upgradeLevelLabel)
    {
        if (Bank.currentMoney >= upgradeCost)
        {
            //�������� ������� � ���������� ��� � ������
            upgradeLevel++;
            upgradeLevelLabel.text = upgradeLevel + "/100";

            //�������� ����� �������� �� ����� � ���������� ��� � ������
            Bank.currentMoney -= upgradeCost;
            globalMoneyText.text = Bank.currentMoney.ToString();

            if (upgradeLevel % 10 == 0)
            {
                //�������� ������������������ ���������� � ���������� ��� � ������
                incrementCount *= 2;
                incrementCount = Mathf.Round(incrementCount);
                moneyReward.text = incrementCount.ToString();

                //�������� ���� �������� � ���������� ��� � ������
                upgradeCost *= 2;
                upgradeCost = Mathf.Round(upgradeCost);
                upgradeCostLabel.text = upgradeCost.ToString();
            }
            else
            {
                //�������� ������������������ ���������� � ���������� ��� � ������
                incrementCount += incrementIncrease;
                incrementCount = Mathf.Round(incrementCount);
                moneyReward.text = incrementCount.ToString();

                //�������� ���� �������� � ���������� ��� � ������
                upgradeCost *= difficultMultiple;
                upgradeCost = Mathf.Round(upgradeCost);
                upgradeCostLabel.text = upgradeCost.ToString();
            }
        }
    }

    IEnumerator MoneyAdditionWithTimer()
    {
        incrementButton.interactable = false;

        yield return new WaitForSeconds(timeToDo);

        MoneyAddition();

        incrementButton.interactable = true;
    }
}
