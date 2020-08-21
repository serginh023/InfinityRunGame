using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] m_panels;
    public GameObject[] m_buttons;


    public void LoadGameScene()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        m_panels = GameObject.FindGameObjectsWithTag("mmPanel");
        m_buttons = GameObject.FindGameObjectsWithTag("mmButton");

        foreach (GameObject p in m_panels)
            p.SetActive(false);
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) )
            QuitGame();
    }

    public void OpenPanel(Button btn)
    {
        btn.transform.GetChild(1).gameObject.SetActive(true);
        foreach (GameObject b in m_buttons)
            if(b != btn.gameObject)
                b.SetActive(false);

    }

    public void ClosePanel(Button btn)
    {
        btn.transform.parent.gameObject.SetActive(false);

        foreach (GameObject b in m_buttons)
            b.SetActive(true);
    }
}
