using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneLoader : MonoBehaviour {

    public string ActiveScene;
    public static SceneLoader s_Instance;
    
	void Awake () {
		if(s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadScene(string sceneName)
    {
        ActiveScene = sceneName;
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadSceneWithFade(string sceneName)
    {
        ScreenEffects.s_OnFadeCompleted += () => LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (ScreenEffects.s_Instance != null)
            ScreenEffects.s_Instance.FadeOut(0.5f);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}