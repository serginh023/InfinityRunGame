using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMusicVolume : MonoBehaviour
{
    List<AudioSource> musicList = new List<AudioSource>();
    // Start is called before the first frame update
    public void Start()
    {
        AudioSource[] allAS = GameObject.FindWithTag("gameData").GetComponentsInChildren<AudioSource>();
        musicList.Add(allAS[0]);

        Slider musicSlider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("musicvolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicvolume");
            UpdateMusicVol(musicSlider.value);
        }
        else
        {
            musicSlider.value = .5f;
            UpdateMusicVol(musicSlider.value);
        }
    }

    public void UpdateMusicVol(float newVolume)
    {
        PlayerPrefs.SetFloat("musicvolume", newVolume);
        foreach(AudioSource m in musicList)
            m.volume = newVolume;
    }
}
