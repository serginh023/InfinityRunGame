using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    public static GameData singleton;

    int m_score;

    public Text scoreText = null;
    public Text highestScoreText = null;
    public GameObject musicSlider;
    public GameObject soundSlider;

    private void Awake()
    {
        GameObject[] gameDatas = GameObject.FindGameObjectsWithTag("gameData");

        if (gameDatas.Length > 1)

            Destroy(this.gameObject);    

        else DontDestroyOnLoad(this.gameObject);

        singleton = this;

        PlayerPrefs.SetInt("score", 0);

        musicSlider.GetComponent<UpdateMusicVolume>().Start();
        soundSlider.GetComponent<UpdateSoundVolume>().Start();
    }

    public void UpdateScore(int score)
    {
        m_score += score;
        PlayerPrefs.SetInt("score", m_score);
        if (scoreText == null)
            return;

        scoreText.text = "Score: " + StringPadding(m_score, 6);

    }

    public void UpdateHighestScore(int score)
    {
        if (highestScoreText == null)
            return;

        highestScoreText.text = "Highest Score: " + StringPadding(score, 6);
    }


    string StringPadding(int score, int numberOfZeros)
   {
        string text = score.ToString();

        for(int i = text.Length; i < numberOfZeros; i++)
            text = "0" + text;

        return text;
   }
}
