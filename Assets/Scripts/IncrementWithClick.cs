using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementWithClick : MonoBehaviour
{
    [SerializeField] public int currentScore = 0;
    [SerializeField] private int incrementCount = 1;
    [SerializeField] private Text scoreText;

    public void ScoreIncrementation()
    {
        currentScore += incrementCount;

        scoreText.text = currentScore.ToString();
    }
}
