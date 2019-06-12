using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject ScoreCanvasUI;
    public GameObject soundOff;
    
 

    public static int currentLevelIndex;
    private void OnEnable()
    {
        Time.timeScale = 0f;
        if (AudioManager.instance.Sound().isActiveAndEnabled)
        {
            soundOff.SetActive(false);
        }
        else soundOff.SetActive(true);
        //pauseMenuUI.SetActive(true);
    }

    public void Toggle()
    {
        pauseMenuUI.SetActive(true);
    }

   

    public void Home()
    {
        pauseMenuUI.SetActive(false);
        
        ScoreCanvasUI.SetActive(false);
        
        gameManager.instance.FadeToLevel(0);
        Time.timeScale = 1f;

    }

    public void Sound()
    {        
            AudioManager.instance.Sound().enabled = !AudioManager.instance.Sound().isActiveAndEnabled;
            soundOff.SetActive(!soundOff.activeSelf);
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void Play()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        int designInd=0;
        if (LevelDesigner.instance != null)
            designInd = LevelDesigner.ind;

        gameManager.instance.FadeToLevel(SceneManager.GetActiveScene().buildIndex, designInd);
        //int index=0;

        //if (LevelDesigner.instance != null)
        //    index = LevelDesigner.ind;

        //gameManager.instance.FadeToLevel(SceneManager.GetActiveScene().buildIndex);

        //if (index!=0)
        //{
           
        //    LevelDesigner.ind = index;
        //    LevelDesigner.instance.DesignLevel(index);
        //}
           
        Time.timeScale = 1f;
    }

    public void Back()
    {
        
        gameManager.instance.FadeToLevel(SceneManager.GetActiveScene().buildIndex-1);
        Time.timeScale = 1f;

    }




}
