using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _pausedUI;
    public bool IsGameOver;
    
    public bool IsGamePaused
    {
        get => Time.timeScale <= 0.0f ? true : false;
    }
    public void GameOver()
    {
        PauseGame(true);
        PopUpGameOverUI();
        IsGameOver = true;
    }
    private void Awake()
    {
        instance = this;
    }
    private void ContinueGame()
    {
        PauseGame(false);
        HideGameOverUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
         {
            if(IsGamePaused == false && Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame(false);
                HidePausedUI();
            }
            else
            {
                PauseGame(true);
                PopUpPauseUI();
            }

        }
    }
  

    private void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0.0f : 1.0f;
    }


    private void PopUpGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }

    private void PopUpPauseUI()
    {
        _pausedUI.SetActive(true);
    }
    private void HideGameOverUI()
    {
        _gameOverUI.SetActive(false);
    }
    private void PopUpPausedUI()
    {
        _pausedUI.SetActive(true);
    }

    private void HidePausedUI()
    {
        _pausedUI.SetActive(false);
    }
}
