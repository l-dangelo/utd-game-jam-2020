using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : LevelController
{
    [SerializeField] TextMeshProUGUI _currentTime = null;
    public LevelController levelController = null;
    public float _timeLeft = 90.0f;

    private void Awake()
    {
        levelController = GetComponent<LevelController>();
    }

    private void Update()
    {
        CheckIfPaused();
        CountDown();
    }

    void CheckIfPaused()
    {
        _isPaused = levelController.CheckPausedState();
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