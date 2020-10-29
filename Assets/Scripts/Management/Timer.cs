using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentTime = null;
    public float _timeLeft = 90.0f;

    void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0)
        {
            GameOver();
        }
        DisplayTimeLeft();
    }

    void GameOver()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void DisplayTimeLeft()
    {
        _currentTime.text = "Time Left: " + _timeLeft.ToString();
    }
}