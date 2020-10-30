using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : LevelController
{
    [SerializeField] TextMeshProUGUI _currentTime = null;
    public float _timeLeft = 90.0f;

    public bool _paused = false;

    private void Update()
    {
        CountDown();
    }

    void CountDown()
    {
        if (!_paused)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0)
            {
                GameOver();
            }
            DisplayTimeLeft();
        }
    }

    void DisplayTimeLeft()
    {
        _currentTime.text = "Time Left: " + _timeLeft.ToString();
    }

    void GameOver()
    {
        LoadScene("LoseScreen");
    }
}