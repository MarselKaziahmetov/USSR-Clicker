using UnityEngine;

public class Bank
{
    public static float currentMoney 
    {
        get => PlayerPrefs.GetFloat("CurrentMoney", 0);
        set => PlayerPrefs.SetFloat("CurrentMoney", value);
    }
}
