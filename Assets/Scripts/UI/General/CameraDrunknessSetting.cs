using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDrunknessSetting : MonoBehaviour
{

    public const string DRUNKNESS_SETTING_KEY = "Camera Drunkness";

    [SerializeField]
    private Slider slider;

    private void Start() {
        slider.value = PlayerPrefs.GetFloat(DRUNKNESS_SETTING_KEY, 1f);
        slider.onValueChanged.AddListener((value) => {
            PlayerPrefs.SetFloat(DRUNKNESS_SETTING_KEY, value);
        });
    }

}
