using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;



public class LevelCompleted : MonoBehaviour
{
    public GameObject levelCompletedCanva;
    public GameObject scoreBoardCanva;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI currentLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        levelCompletedCanva.SetActive(true);
        scoreBoardCanva.SetActive(false);
        Time.timeScale = 0f;

        if (LevelDesigner.ind+1 > PlayerPrefs.GetInt("LevelToReach", 1))
        {
            PlayerPrefs.SetInt("LevelToReach", LevelDesigner.ind+1);
        }

        currentScore.text = playerStats.instance.colorScore.ToString();
        currentLevel.text = "Level " + LevelDesigner.ind;

        if (LevelDesigner.ind % 5 == 0 && LevelDesigner.ind != 0)
            AdMobManager._AdMobInstance.showInterstitial();

    }

    public void NextLevel()
    {
        
        if (!gameManager.levelCompleted)
        {
            gameManager.levelCompleted = true;
            gameManager.instance.EndLevel();
            
        }
        
        
    }

    public void Home()
    {
        gameManager.instance.FadeToLevel(0);
    }
}
