using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject _pauseMenu = null;


    bool _isPaused = false;
    int _currentScore = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _pauseMenu.SetActive(false);
    }

    public void IncreaseScore(int increaseAmount)
    {
        _currentScore += increaseAmount;
    }
}
