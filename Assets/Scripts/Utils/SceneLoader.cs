using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader Instance {get; private set;}

    [SerializeField]
    private LoadingScreen loadingScreen;

    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName){
        loadingScreen.OpenLoadingScreen(() => {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation.completed += (op) => {
                loadingScreen.CloseLoadingScreen();
            };
        });
    }

}
