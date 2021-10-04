using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{

    [SerializeField]
    private string settingName;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private float minDB = -80, maxDB = 0;

    private string playerPrefKey;

    private void Awake() {
        playerPrefKey = $"vol_{settingName}";

        slider.maxValue = LogToLinear(maxDB);
        slider.minValue = LogToLinear(minDB);
        
        float startValue;
        if(PlayerPrefs.HasKey(playerPrefKey)){
            startValue = PlayerPrefs.GetFloat(playerPrefKey);
        } else {
            mixer.GetFloat("volume", out startValue);
        }
        slider.value = LogToLinear(startValue);
        

        slider.onValueChanged.AddListener((val) => SetVolume());
    }

    private void SetVolume(){
        mixer.SetFloat("volume", LinearToLog(slider.value));
        PlayerPrefs.SetFloat(playerPrefKey, LinearToLog(slider.value));
    }

    private float LogToLinear(float log){
        return Mathf.Pow(10, (log / 20));
    }

    private float LinearToLog(float linear){
        return Mathf.Log10(linear)*20;
    }
}
