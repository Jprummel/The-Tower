using UnityEngine;

public class AdManager : MonoBehaviour {

	void Awake () {
        GameDistribution.OnResumeGame += ResumeGame;
        GameDistribution.OnPauseGame += PauseGame;
	}

    public void ShowAd()
    {
        GameDistribution.Instance.ShowAd();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void OnDestroy()
    {
        GameDistribution.OnResumeGame += ResumeGame;
        GameDistribution.OnPauseGame -= PauseGame;
    }
}