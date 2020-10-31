using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentTime = null;
    public LevelController levelController = null;
    public float _timeLeft = 60.0f;

    bool _timerIsPaused = false;

    private void Start()
    {
        //LevelController.levelController = 
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
        _timerIsPaused = pauseState;
    }

    void CheckIfPaused()
    {
      //  _timerIsPaused = CheckPausedState();
    }

    void CountDown()
    {
        if (!_timerIsPaused)
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
        SceneManager.LoadScene("LoseScreen");
    }
}