using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : LevelController
{
    [SerializeField] TextMeshProUGUI _currentTime = null;
    public float _timeLeft = 90.0f;

    private void Update()
    {
        CheckIfPaused();
        CountDown();
    }

    void CheckIfPaused()
    {
        _isPaused = CheckPausedState();
    }

    void CountDown()
    {
        if (!_isPaused)
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