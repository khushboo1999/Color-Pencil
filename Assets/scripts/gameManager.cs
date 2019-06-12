using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameManager : MonoBehaviour
{

    public Animator anim;
    public static bool levelCompleted = false;
    
    public string LevelSceneName = "Levels";
    [HideInInspector]
    public Image CurrentSprite;
    [HideInInspector]
    public static int colorScore;

    private int levelIndex;
    private  int DesignIndex;
    public static bool rewardVidPlayed = false;
    public static gameManager instance;

    private int levelToUnlock;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
        }
         
    }

    

    public void EndLevel()
    {
        
        
            levelToUnlock = SceneManager.GetActiveScene().buildIndex;

            DesignIndex = ++LevelDesigner.ind;
            //if (DesignIndex > PlayerPrefs.GetInt("LevelToReach", 1))
            //{
            //    PlayerPrefs.SetInt("LevelToReach", DesignIndex);
            //}
            FadeToLevel(3, DesignIndex);
           
        
    }


    public void FadeToLevel(int index,int dIndex)
    {
        levelIndex = index;
        DesignIndex = dIndex;
        anim.SetTrigger("fade_out");
    }

    public void FadeToLevel(int index)
    {
        levelIndex = index;
        anim.SetTrigger("fade_out");
        
    }

    public void OnFadeComplete()
    {
       
        SceneManager.LoadScene(levelIndex);

        if (LevelDesigner.instance != null)
            LevelDesigner.ind = DesignIndex;
       // Debug.Log(DesignIndex);
       // LevelDesigner.instance.DesignLevel(DesignIndex);
        levelCompleted = false;
        Time.timeScale = 1f;

    }

    public void PlayGame()
    {
        FadeToLevel(1,0);

    }

    public void Quit(string buttonName)
    {
        
       
        Application.Quit();
    }

    public Image InfoForFace()
    {
        return CurrentSprite;

    }

    public void RewardVidPlayed(int Score)
    {
        rewardVidPlayed = true;
        colorScore = Score;
    }
    
}

