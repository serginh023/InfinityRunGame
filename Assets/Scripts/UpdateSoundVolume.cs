using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSoundVolume : MonoBehaviour
{
    List<AudioSource> soundList = new List<AudioSource>();
    // Start is called before the first frame update
    public void Start()
    {
        AudioSource[] allAS = GameObject.FindWithTag("gameData").GetComponentsInChildren<AudioSource>();
        for(int i = 1; i < allAS.Length; i++)
            soundList.Add(allAS[i]);

        Slider soundSlider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("soundVolume"))
        {
            soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
            UpdateSoundVol(soundSlider.value);
        }
        else
        {
            soundSlider.value = .5f;
            UpdateSoundVol(soundSlider.value);
        }
    }

    public void UpdateSoundVol(float newVolume)
    {
        PlayerPrefs.SetFloat("soundVolume", newVolume);
        foreach (AudioSource m in soundList)
            m.volume = newVolume;
    }
}
