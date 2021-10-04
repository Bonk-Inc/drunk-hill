using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneSwitcher))]
public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private string[] levels;

    private const string CURRENT_LEVEL_PREF = "currentLevel";
    private SceneLoader sceneSwitcher;

    public event Action OnLastLevelFinished;

    private void Awake() {
        sceneSwitcher = SceneLoader.Instance;
        
        PlayerPrefs.GetInt(CURRENT_LEVEL_PREF, 0);
    }


    public void ToCurrentLevel() {
        int level = PlayerPrefs.GetInt(CURRENT_LEVEL_PREF, 0);

        if(LevelExists(level)) {
            sceneSwitcher.LoadScene(levels[level]);
        }
    }

    public void ToNextLevel() {
        int level = PlayerPrefs.GetInt(CURRENT_LEVEL_PREF, 0) + 1;

        if(LevelExists(level)) {
            
            PlayerPrefs.SetInt(CURRENT_LEVEL_PREF, level);
            sceneSwitcher.LoadScene(levels[level]);
        }
        else {
            OnLastLevelFinished?.Invoke();
        }
    }

    private bool LevelExists(int level) {
        return level < levels.Length;
    }

    [ContextMenu("Reset")]
    public void ResetLevels() {
        PlayerPrefs.DeleteKey(CURRENT_LEVEL_PREF);
    }
}
