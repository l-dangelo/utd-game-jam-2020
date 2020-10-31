using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject _pauseMenu = null;
    [SerializeField] GameObject _optionsMenu = null;
    [SerializeField] AudioSource _mainSong = null;    

    public bool _isPaused = false;

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
        _mainSong.Pause();
        _isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        _mainSong.Play();
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _optionsMenu.SetActive(false);
        _pauseMenu.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool CheckPausedState()
    {
        return _isPaused;
    }
}
