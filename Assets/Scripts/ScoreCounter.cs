using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    private int mainScore;

    #region Coins


    #endregion

    #region Health

    public void ShowHealth(int health)
    {
        healthText.text = $"{health}";
    }

    #endregion

    #region Score

    public void AddScore(int score)
    {
        mainScore += score;
        scoreText.text = $"{mainScore}";
    }

    #endregion
}
