using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float currentTime;

    const int secondsInMinute = 60;

    private int minute;
    private int second;

    private void Start()
    {
        currentTime = 0;
    }

    private void FixedUpdate()
    {
        CalculateTime();
        ShowTime();
    }

    private void CalculateTime()
    {
        currentTime += Time.fixedDeltaTime;
        second = Mathf.RoundToInt(currentTime);
        if (second >= 60 * (minute + 1))
        {
            minute++;
        }
    }

    private void ShowTime()
    {
        string secondString = "";
        string minuteString = "";

        if (second < 10 + secondsInMinute * minute)
            secondString = $"0{second - secondsInMinute * minute}";
        else
            secondString = $"{second - secondsInMinute * minute}";

        if (minute < 10)
            minuteString = $"0{minute}";
        else
            minuteString = $"{minute}";


        timerText.text = $"{minuteString}:{secondString}";
    }
}