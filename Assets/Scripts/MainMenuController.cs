﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject m_panelHelp;

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
    }

    public void OpenHelp()
    {
        m_panelHelp.SetActive(true);
    }

    public void CloseHelp()
    {
        m_panelHelp.SetActive(false);
    }
}