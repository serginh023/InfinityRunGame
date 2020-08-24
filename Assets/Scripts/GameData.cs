using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    public static GameData singleton;

    int m_score;

    public Text scoreText = null;


    private void Awake()
    {
        GameObject[] gameDatas = GameObject.FindGameObjectsWithTag("gameData");

        if (gameDatas.Length > 1)

            Destroy(this.gameObject);    

        else DontDestroyOnLoad(this.gameObject);

        singleton = this;

    }

    public void UpdateScore(int score)
    {
        m_score += score;
        
        if (scoreText == null)
            return;

        scoreText.text = "Score:\n" + m_score;

    }
}
