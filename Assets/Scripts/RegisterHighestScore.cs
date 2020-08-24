using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterHighestScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData.singleton.highestScoreText = GetComponent<Text>();

        if (PlayerPrefs.HasKey("highscore"))
            GameData.singleton.UpdateHighestScore(PlayerPrefs.GetInt("highscore"));
        else
            GameData.singleton.UpdateHighestScore(0);
    }
}
