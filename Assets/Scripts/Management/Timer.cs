using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : LevelController
{
    [SerializeField] TextMeshProUGUI _currentTime = null;
    public LevelController levelController = null;
    public float _timeLeft = 90.0f;

    bool _timerPaused = false;

    private void Awake()
    {
        levelController = GetComponent<LevelController>();
    }

    private void Update()
    {
        CountDown();
        CheckIfPaused();
    }

    public void ChangeTime(float timeChange)
    {
        _timeLeft += timeChange;
    }

    public void ChangeTimerPauseState(bool pauseState)
    {
        _timerPaused = pauseState;
    }

    void CheckIfPaused()
    {
        _timerPaused = levelController.CheckPausedState();
    }

    void CountDown()
    {
        if (!_timerPaused)
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