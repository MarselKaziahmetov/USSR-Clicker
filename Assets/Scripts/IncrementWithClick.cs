using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SaveSystem;

public class IncrementWithClick : MonoBehaviour
{
    public IncrementWithClick Instance { get; private set; }

    [Header("Activities Tag")]
    [SerializeField] public string tagForSave;
    
    [Header("Variables")]
    [SerializeField] private int incrementValue;
    [SerializeField] private int incrementIncrease;
    [SerializeField] private float timeToDo;
    [SerializeField] private float difficultMultiple;
    [SerializeField] private int upgradeCost;
    [SerializeField] private int upgradeLevel;
    
    [Header("Labels")]
    [SerializeField] public Text globalMoneyText;
    [SerializeField] public Text moneyReward;
    [SerializeField] private Text timerText;
    [SerializeField] private Text upgradeCostLabel;
    [SerializeField] private Text upgradeLevelLabel;

    [Header("Link for increment button")]
    [SerializeField] public Button incrementButton;

    private SaveSystem prototype;

    public float IncrementValue
    {
        get => PlayerPrefs.GetFloat(tagForSave + "IncrementValue", incrementValue);
        set => PlayerPrefs.SetFloat(tagForSave + "IncrementValue", value);
    }

    public float UpgradeCost
    {
        get => PlayerPrefs.GetFloat(tagForSave + "UpgradeCost", upgradeCost);
        set => PlayerPrefs.SetFloat(tagForSave + "UpgradeCost", value);
    }

    public int UpgradeLevel
    {
        get => PlayerPrefs.GetInt(tagForSave + "UpgradeLevel", upgradeLevel);
        set => PlayerPrefs.SetInt(tagForSave + "UpgradeLevel", value);
    }

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

    //Метод для события OnClick
    public void IncrementationButton()
    {
        StartCoroutine("MoneyAdditionWithTimer");
    }

    public void MoneyAddition()
    {
        Bank.currentMoney += IncrementValue;

        globalMoneyText.text = Bank.currentMoney.ToString();
    }

    public void ActivitiesInteractebleCheck()
    {
        if (UpgradeLevel == 0)
        {
            incrementButton.interactable = false;
        }
        else
        {
            incrementButton.interactable = true;
        }
    }

    public void Upgrade()
    {
        if (Bank.currentMoney >= UpgradeCost)
        {
            //Повышаем уровень и отображаем это в тексте
            UpgradeLevel++;
            upgradeLevelLabel.text = UpgradeLevel + "/100";
            
            ActivitiesInteractebleCheck();

            //Отнимаем сумму апгрейда от банка и отображаем это в тексте
            Bank.currentMoney -= UpgradeCost;
            globalMoneyText.text = Bank.currentMoney.ToString();

            if (UpgradeLevel % 10 == 0)
            {
                //Повышаем производительность активности и отображаем это в тексте
                IncrementValue *= 2;
                IncrementValue = Mathf.Round(IncrementValue);
                moneyReward.text = IncrementValue.ToString();

                //Повышаем цену апгрейда и отображаем это в тексте
                UpgradeCost *= 2;
                UpgradeCost = Mathf.Round(UpgradeCost);
                upgradeCostLabel.text = UpgradeCost.ToString();
            }
            else
            {
                //Повышаем производительность активности и отображаем это в тексте
                IncrementValue += incrementIncrease;
                IncrementValue = Mathf.Round(IncrementValue);
                moneyReward.text = IncrementValue.ToString();

                //Повышаем цену апгрейда и отображаем это в тексте
                UpgradeCost *= difficultMultiple;
                UpgradeCost = Mathf.Round(UpgradeCost);
                upgradeCostLabel.text = UpgradeCost.ToString();
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
