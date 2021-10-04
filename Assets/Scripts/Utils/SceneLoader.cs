using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private static SceneLoader instance;
    public static SceneLoader Instance => GetInstance();

    [SerializeField]
    private LoadingScreen loadingScreen;

    private static SceneLoader GetInstance(){
        if(instance == null){
            var gobj = new GameObject("Generated Scene Loader");
            instance = gobj.AddComponent<SceneLoader>();
        }
        return instance;
    }

    private void Awake() {
        if(instance != null){
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName){

        if (loadingScreen == null)
        {
            SceneManager.LoadScene(sceneName);
            return;
        }

        loadingScreen.OpenLoadingScreen(() => {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation.completed += (op) => {
                loadingScreen.CloseLoadingScreen();
            };
        });
    }

}
