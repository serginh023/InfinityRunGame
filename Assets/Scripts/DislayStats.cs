using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DislayStats : MonoBehaviour
{
    public Text LastScoreText;
    public Text HighestScoreText;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("lastscore"))
            LastScoreText.text = PlayerPrefs.GetInt("lastscore").ToString();
        else
            LastScoreText.text = "0";

        if (PlayerPrefs.HasKey("highscore"))
            HighestScoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        else
            HighestScoreText.text = "0";
    }
}
